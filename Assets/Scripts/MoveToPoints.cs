using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using UnityEngine.UIElements;
using DG.Tweening;
public class MoveToPoints : MonoBehaviour
{
    [SerializeField] private Points _point;
    // [SerializeField] private DiceRoll _diceRoll;
    [SerializeField] private int _diceRollResult;
    [SerializeField] private int _placeValue = 0;
    [SerializeField] private List<GameObject> _points;
    [SerializeField] private List<GameObject> _pointsRed;
    //  [SerializeField] private float _speed;
    [SerializeField] private int _step;
    [SerializeField] private float time = 0f;
    [SerializeField] private Animator _animator;
    
   
  //  [SerializeField] private Transform _pointFinal;

    private void Start()
    {
    
        _animator = GetComponent<Animator>();
 

    }

    public void Update()
    {

        
        if (_points.Count > 0) // - обычные точки
        {
            MoveToPoint(ref _points);
        }
        else if (_pointsRed.Count > 0) // - если попались красные
        {
            MoveToPoint(ref _pointsRed);
        }
        else // - передаем событие о разрешении броска кубика
        {
            EventManager.ThrewCube(true);
        }

    }

    private void MoveToPoint(ref List<GameObject> pointsMove)
    {

        if (pointsMove.Count > 0)
        {
            time += Time.deltaTime;

            _animator.SetTrigger("JumpTrigger");
            _animator.ResetTrigger("IdleTrigger");
            //Доделать
            // PM - не нравится как я сделал переход между клетками. Я думал о SLerp, но решил имитировать прыжок анимацией. DOJump же работает некорректно, если точки задаются в процессе выполнения программы.
            if (time > 0.2f) // - задержка сделана для имитации прыжка, можно и без нее. Но поначалу нужна была для корректной работы DOJump, но в какой-то момент все сломалось
            {
                // transform.DOJump(pointsMove[_step].transform.position, 2, 1, 3).SetEase(Ease.InOutQuint);
              //  transform.DOJump(new Vector3 (0,2,2), 2, 1, 3).SetEase(Ease.InOutQuint);
                 
                 transform.position = Vector3.MoveTowards(transform.position, pointsMove[_step].transform.position, 4f * Time.deltaTime);
                transform.DOLookAt(pointsMove[_step].transform.position, 0.5f);

                if (transform.position == pointsMove[_step].transform.position)
                {

                    _step++;
                    time = 0;

                }
                if (_step >= pointsMove.Count)
                {
                    _step = 0;
                    pointsMove.Clear();


                    _animator.ResetTrigger("JumpTrigger");
                    _animator.SetTrigger("IdleTrigger");
                }
            }
        }
    }
    public void GoToPoint(int placeBefore, int placeAfter)
    {

        _points.AddRange(_point.GetComponent<Points>().GetPoint(placeBefore, placeAfter));

        _pointsRed.AddRange(_point.GetComponent<Points>().GetPointRed(placeAfter));

    }
    
}
