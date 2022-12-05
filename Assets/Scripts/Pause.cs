using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    [SerializeField] private Canvas _canvasMenu;
    private bool _isPause = true;
    private void Start()
    {
    //    DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        PauseStatus();
    }

    private void PauseStatus() // - �������� �� esp ��� �����
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            if(_isPause == true)
            {
                _canvasMenu.gameObject.SetActive(true);
                Time.timeScale = 0f;
                _isPause = false;
            }
            else
            {
                _canvasMenu.gameObject.SetActive(false);
                Time.timeScale = 1f;
                _isPause = true;

            }

        }
    }
    public void ClickOnButtonEnd() // - ������� �� ����. � �������, ��� ����� �������� � ����, �� ���� ��� (��������)
    {
        _canvasMenu.gameObject.SetActive(false);
        Time.timeScale = 1f;
        _isPause = true;
      //  ManagerPlayers.TriggerToDestroy = true;
     //   SceneManager.LoadScene("StartMenu");
        Application.Quit();

    }
  
}
