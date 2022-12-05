using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager
{
    public static event Action RedTake;
    public static event Action GreenTake;
    public static event Action<bool> ThrowCube;
    public static event Action<int> ActivePlayer;
    public static event Action<GameObject,GameObject> ActivePlayers;
    public static event Action<int> CameraMove;
    public static event Action<GameObject> AddingCharacters;
    public static event Action WinEvent;
    public static void RedTaked()
    {
        RedTake?.Invoke();
    }
    public static void GreenTaked()
    {
        GreenTake?.Invoke();
    }
    public static void ActivedPlayer(int cube)
    {
        ActivePlayer?.Invoke(cube);
    }
    public static void ThrewCube(bool able)
    {
        ThrowCube?.Invoke(able);
    }
    public static void ActivePlayersSetup(GameObject activePlayer, GameObject nextPlayer)
    {
        ActivePlayers?.Invoke(activePlayer, nextPlayer);
    }
    public static void CameraMoving(int point)
    {
        CameraMove?.Invoke(point);
    }
    public static void AddCharacter(GameObject character)
    {
        AddingCharacters?.Invoke(character);    
    }
    public static void WiningEvent()
    {
        WinEvent?.Invoke();
    }
}
