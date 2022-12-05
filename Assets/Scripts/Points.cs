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
    
    [SerializeField] private int[] _pointsRed2 = new int[] { 7, 11, 16, 20, 23, 29, 30, 34, 40, 61, 65, 66 };  // - ����� ��������, ������ ��� ���������� ��������������

    [SerializeField] private int[] _pointsGreen1 = new int[] { 8, 19, 22, 28, 32, 41, 42, 45, 50, 52, 57, 58 };
    [SerializeField] private List<GameObject> list;
  // [SerializeField] public Transform PointEnd { get; private set; }

    private void Awake()
    {

    }
    public List<GameObject> GetPoint(int pointStart, int pointEnd) // - �������� ������ �����. ��������� ����� "������" ((����� ����, �� ������ ����, ��� ���������� ��� ����������, ������ ������ ��� ��������
    {
        list = new List<GameObject>(); // - ������ ��� �������� ������ ��� ����� ������, ����� ��������� �� ������ �� ����� � ��� �� ������ + �����
        if (pointEnd > points.Count-1) // - ���� ���� �������� ���������� ������� ������� ��� ����������, ���������� ���������� �������� ����� � ��������� � ���������� ������� �� ����
        {
            pointEnd = points.Count;
            EventManager.WiningEvent();

        }

        for (int i = pointStart; i < pointEnd; i++)
        {
            list.Add(points[i]);
        }
        if (_pointsGreen1.Any(x => x == (pointEnd)) ? true : false) // ���������� �������� ���������� ����� � �������� �������, ���� ����, �� �������� ������� � ������� ����
        {
            EventManager.GreenTaked();

        }

        return list;

    }
    public List<GameObject> GetPointRed(int cubeSum) // - �����
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
