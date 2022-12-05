using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerPlayers : MonoBehaviour
{
    public static bool TriggerToDestroy { get; set; }
    public static bool TriggerWin { get; private set; }

    [SerializeField] private List<int> _listSumRolls = new List<int>();
    [SerializeField] private int _roll;
    [SerializeField] private ChangeValuePlayers _valuePlayers;
   // [SerializeField] private GameObject _players;
    [SerializeField] private List<GameObject> _listPlayers;
    [SerializeField] private Transform _pointStart;
    [SerializeField] private GameObject _crown;
   // [SerializeField] private MoveCamera _moveCamera;
    //��������
    [SerializeField] protected int PlayerQueue { get; private set; }
    [SerializeField] private bool _greenDetect = false;

    private void Awake()
    {
        //�� 1 ����� ���������� ��� ���������, ���� �� ����� ��������������, �� ���������� �������, ������� ���� ��������� ����������� ����������, 
        TriggerToDestroy = false;
        foreach (var item in ListCharacter.DontDestroyListActiveCharacters)
        {
            Debug.Log(item);
        }
        InstantiatePlayers();
      //  TriggerToDestroy = true;
    }

    private void Start()
    {
        PlayerQueue = 0;
        TriggerToDestroy = true;
        TriggerWin = false;
        EventManager.ActivePlayer += ActivePlayer;
        EventManager.RedTake += MinusRed;
        EventManager.GreenTake += GiveMove;
        EventManager.WinEvent += Win;

        foreach (var player in _listPlayers)
        {
            player.GetComponent<MoveToPoints>().enabled = false;
        }
    }
   
    public void InstantiatePlayers()
    {
        for (int i = 0; i < ListCharacter.DontDestroyListActiveCharacters.Count; i++)
        {

            //������� ����� ������� ��� 2 ���������� ����� �������, �� ����� �� ���������, ��� ���������� � ������� ������-�� �����������. �������� ����� ���� ������� ���������, ����� ������� ������������ ��������.
            _listPlayers.Add(Instantiate(ListCharacter.DontDestroyListActiveCharacters[i],_pointStart.transform.position, Quaternion.identity));
            _listSumRolls.Add(0);
        }
    }
    private void ActivePlayer(int roll) // - �� ������� ���������� � ��������� ���������, ����� ������������
    {
        if (TriggerWin)
            return;

        _roll = roll;
    
        _listPlayers[PlayerQueue].GetComponent<MoveToPoints>().enabled = true;

        _listSumRolls[PlayerQueue] += _roll;
        _listPlayers[PlayerQueue].GetComponent<MoveToPoints>().GoToPoint(_listSumRolls[PlayerQueue] - _roll, _listSumRolls[PlayerQueue]); //�������� ����� "������ - �������� �����" � ����� "������"

        if (_greenDetect)
        {
            _greenDetect = false;
            return;
        }

        PlayerQueue++;
        if (PlayerQueue == _listPlayers.Count)  // - ������ ������
        {
            EventManager.ActivePlayersSetup(_listPlayers[PlayerQueue - 1], _listPlayers[0]);

            PlayerQueue = 0;
        }
        else
            EventManager.ActivePlayersSetup(_listPlayers[PlayerQueue - 1], _listPlayers[PlayerQueue]);

        _listPlayers[PlayerQueue].GetComponent<MoveToPoints>().enabled = false;
 
    }

    private void MinusRed() // ���� ��������� �� ������� ������, ���������� ������ ����� ������ �� 3
    {
        _listSumRolls[PlayerQueue] -= 3;
    }

    private void GiveMove() // ���� ���, ���� ��������� �� ������� ������
    {
        _greenDetect = true;
    }
    private void Win() //- ����� ��������� �����
    {

        Debug.Log("������ " + _listPlayers[PlayerQueue].name);
        _crown.gameObject.SetActive(true);
        TriggerWin = true;
    }

    private void OnDestroy()
    {
        EventManager.ActivePlayer -= ActivePlayer;
        EventManager.RedTake -= MinusRed;
        EventManager.GreenTake -= GiveMove;
        EventManager.WinEvent -= Win;
    }
}
