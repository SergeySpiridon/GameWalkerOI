using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UIElements;
using System.Threading;

public class Points : MonoBehaviour
{
    [SerializeField] private List<GameObject> points = new List<GameObject>();
    [SerializeField] private List<GameObject> _pointsRedResult;
    
    [SerializeField] private int[] _pointsRed2 = new int[] { 7, 11, 16, 20, 23, 29, 30, 34, 40, 61, 65, 66 };  // - такие названия, потому что переменные закешировались

    [SerializeField] private int[] _pointsGreen1 = new int[] { 8, 19, 22, 28, 32, 41, 42, 45, 50, 52, 57, 58 };
    [SerializeField] private List<GameObject> list;
  // [SerializeField] public Transform PointEnd { get; private set; }

    private void Awake()
    {

    }
    public List<GameObject> GetPoint(int pointStart, int pointEnd) // - передаем список точек. Принимаем сумму "кубика" ((класс есть, но самого нету, мне показалось так интереснее, нежели делать его анимацию
    {
        list = new List<GameObject>(); // - каждый раз выделяем память под новый список, чтобы персонажи не ходили по одним и тем же точкам + новым
        if (pointEnd > points.Count-1) // - если было передано количество поинтов большее чем существует, превращаем переданную конечную точку в последнюю и отправляем событие об этом
        {
            pointEnd = points.Count;
            EventManager.WiningEvent();

        }

        for (int i = pointStart; i < pointEnd; i++)
        {
            list.Add(points[i]);
        }
        if (_pointsGreen1.Any(x => x == (pointEnd)) ? true : false) // сравниваем конечную переданную точку с массивом зеленых, если есть, то передаем событие о добавке хода
        {
            EventManager.GreenTaked();

        }

        return list;

    }
    public List<GameObject> GetPointRed(int cubeSum) // - Схоже
    {
        _pointsRedResult = new List<GameObject>();
        if (!_pointsRed2.Any(x => x == (cubeSum)) ? true : false)
            return _pointsRedResult;
        for (int i = cubeSum - 2; i > cubeSum - 4; i--)
        {
            _pointsRedResult.Add(points[i]);
        }
        EventManager.RedTaked();
        return _pointsRedResult;
    }
}
