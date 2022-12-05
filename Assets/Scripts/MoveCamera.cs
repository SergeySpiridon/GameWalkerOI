using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using static UnityEngine.GraphicsBuffer;

public class MoveCamera : MonoBehaviour
{
    
    [SerializeField] private GameObject _pointCenter;
    [SerializeField] private GameObject _activePLayer;
    [SerializeField] private GameObject _pointBack;
    [SerializeField] private Vector3[] _pos;
    [SerializeField] private GameObject _lookAtObject;
    [SerializeField] private GameObject _lookAtNextObject;
    private Tweener _tween;
    [SerializeField]private Vector3 _targetLastPosition;
    [SerializeField] private GameObject target;
    private float timer;
    private Vector3 direction;

    [SerializeField] private GameObject _nextPlayer;
    [SerializeField] private GameObject _winPoint;
    void Start()
    {


        EventManager.ActivePlayers += TargetPlayer;

    }


    void Update()
    {
      
        try
        {
            if (_activePLayer.transform.position == null); // - заглушка 
          
        }
        catch 
        {
            return;
        }

        if (_targetLastPosition != _activePLayer.transform.position)   // - преследуем активного игрока
        {
            transform.DOLookAt(_lookAtObject.transform.position,0.5f);
            _tween.ChangeEndValue(_activePLayer.transform.position, true).SetEase(Ease.Linear).Restart(); // начать движение с той точки, где мы стоим
            _targetLastPosition = _activePLayer.transform.position;
        }
        else if(ManagerPlayers.TriggerWin == true)   // - идем в трактор при победе
        {
            DOTween.Sequence()
                .Append(transform.DOMove(_winPoint.transform.position, 2f))
                .Insert(0, transform.DOLookAt(_activePLayer.transform.position, 2f));  

        }
        else
        {
            timer += Time.deltaTime;
            if(timer > 3f) // - после 3-х секунд как персонаж достиг своей точки, переходим к другому
            {
                DOTween.Sequence()
                .Append(transform.DOMove(_nextPlayer.transform.position, 4f))
                .Insert(0, transform.DOLookAt(_lookAtNextObject.transform.position, 4f));  // -- Какой-то баг

            }
            else
            {
                transform.LookAt(_lookAtObject.transform.position);

            }
            //  else
            //     _pos = new Vector3[] { _pointBack.transform.position, _nextPlayer.transform.position }; // -- изменить


        }

    }
    private void TargetPlayer(GameObject playerActive, GameObject playerNext) // - передаем активного и следущего игрока через событие
    {
        timer = 0;
        _lookAtObject = playerActive;
        _lookAtNextObject = playerNext;
        _activePLayer = playerActive.gameObject.transform.GetChild(0).gameObject;
        _nextPlayer = playerNext.gameObject.transform.GetChild(0).gameObject;
        
        TweenAnim(_activePLayer); 
    }

    private void TweenAnim(GameObject player)  // - анимация прислежевания 
    {

        _targetLastPosition = player.transform.position;
        _tween = transform.DOMove(player.transform.position, 3f).SetAutoKill(false); //-запретить уничтожении анимации
  
        
    }
    private void OnDestroy()
    {
        EventManager.ActivePlayers -= TargetPlayer;
    }
}
