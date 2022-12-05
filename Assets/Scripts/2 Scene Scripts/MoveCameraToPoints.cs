using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class MoveCameraToPoints : MonoBehaviour
{

    [SerializeField] private Transform[] _points;
    [SerializeField] private GameObject[] _LookAtObjects;
    [SerializeField] private int _chek;
    [SerializeField] public GameObject ActiveCharacter { get; private set; }

    private void Start()
    {
        EventManager.CameraMove += GoToPoint;
    }
    private void GoToPoint(int point)
    {
        _chek = point;
        StartCoroutine(nameof(WaitSecondsAfterClick));
       
    }
    private void OnDestroy()
    {
        EventManager.CameraMove -= GoToPoint;

    }
    private IEnumerator WaitSecondsAfterClick()
    {
        yield return new WaitForSeconds(0.1f);

        DOTween.Sequence()
            .Append(transform.DOMove(_points[_chek].position, 3f))
            .Insert(1.5f, transform.DOLookAt(_LookAtObjects[_chek].transform.position, 2f));
        ActiveCharacter = _LookAtObjects[_chek];

        Debug.Log(_LookAtObjects[_chek].transform.position);    
    }
}
