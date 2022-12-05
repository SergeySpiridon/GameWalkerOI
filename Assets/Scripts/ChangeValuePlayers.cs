using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Rendering;

//Тестовый скрипт
public class ChangeValuePlayers : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;
    public int ValuePlayers { get; private set; }
    private void Start()
    {
        ValuePlayers = 2;
        _text.text = ValuePlayers.ToString();
    }
    public void ClickOnButtonLeft()
    {
        if (ValuePlayers > 2)
            ValuePlayers--;
        _text.text = ValuePlayers.ToString();

    }
    public void ClickOnButtonRight()
    {
        if (ValuePlayers < 4)
            ValuePlayers++;
        _text.text = ValuePlayers.ToString();
    }
}
