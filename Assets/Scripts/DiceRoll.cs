using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceRoll : MonoBehaviour
{
    [SerializeField] private int _rollResult;
    [SerializeField] private bool _ableToThrow;
    private void Start()
    {
        EventManager.ThrowCube += AbleToThrow;
    }
    void Update()
    {
        if (_ableToThrow)
            if (Input.GetKeyDown(KeyCode.Space))
            {
                _ableToThrow = false;
                _rollResult = Random.Range(2, 7);
                EventManager.ActivedPlayer(_rollResult);

                //EventManager.ActivedPlayer();
            }
    }
    private void AbleToThrow(bool ableToThrow) // - разрешает бросить кубик
    {
        _ableToThrow = ableToThrow;
    }
    private void OnDestroy()
    {
        EventManager.ThrowCube -= AbleToThrow;
    }
}
