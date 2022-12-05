using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ListCharacter : MonoBehaviour
{
    [SerializeField] public static List<GameObject> DontDestroyListActiveCharacters { get; private set; } = new List<GameObject>();
    private float _timer;
    private void Start()
    {
        DontDestroyOnLoad(gameObject);
    }
    private void FixedUpdate()
    {
     // ��������� �������� �� 2 �����. ���� �� �� ���������, �� ������ ����� ������ � ������ ����� ��������������� ��������� ����������.
     // ����� ��������� ������� �� 1 �����, �� ����� ������������. ��� ����� ��������
        if(ManagerPlayers.TriggerToDestroy)
        {
            _timer += Time.deltaTime;
            if(_timer > 1f)
            {
                gameObject.transform.GetChild(0).gameObject.SetActive(false);
                gameObject.transform.GetChild(1).gameObject.SetActive(false);
                gameObject.transform.GetChild(2).gameObject.SetActive(false);
                gameObject.transform.GetChild(3).gameObject.SetActive(false);
            }
           
        }
        //else
        //{
        //    if (_timer > 1f)
        //    {
        //        gameObject.transform.GetChild(0).gameObject.SetActive(true);
        //        gameObject.transform.GetChild(1).gameObject.SetActive(true);
        //        gameObject.transform.GetChild(2).gameObject.SetActive(true);
        //        gameObject.transform.GetChild(3).gameObject.SetActive(true);
        //    }
        //}
    }
}
