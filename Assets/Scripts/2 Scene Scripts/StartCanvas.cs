using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class StartCanvas : MonoBehaviour
{
    [SerializeField] private Canvas _canvasStart;
    [SerializeField] private Canvas _canvasChoise;
    [SerializeField] private GameObject _panel;
    public void StartButton()
    {
        _canvasStart.gameObject.SetActive(false);
        _canvasChoise.gameObject.SetActive(true);
        EventManager.CameraMoving(1);
    }

    public void HowToPlayButton()
    {
        _panel.SetActive(true);
        StartCoroutine(TimerShowPanel());
    }

    public void ExitButtonClick()
    {
        Application.Quit();
    }
    private IEnumerator TimerShowPanel()
    {
        yield return new WaitForSeconds(5f);
        _panel.SetActive(false);
    }
   
}
