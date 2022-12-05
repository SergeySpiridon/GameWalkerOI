using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
//using static UnityEditor.Progress;
using UnityEngine.SceneManagement;

public class ChoiseCanvas : MonoBehaviour
{
    [SerializeField] private Canvas _canvasStart;
    [SerializeField] private Canvas _canvasChoise;
    [SerializeField] private int _iteratorClick = 1;
    [SerializeField] private MoveCameraToPoints _activeCharacter;
    [SerializeField] private List<GameObject> _listActiveCharacters = new List<GameObject>();
    [SerializeField] private TMP_Text _buttonChoiseText;
   
    private void Update()
    {
        CheckAdd();
    }
    public void ButtonBackToStartCanvas()
    {
        _canvasStart.gameObject.SetActive(true);
        _canvasChoise.gameObject.SetActive(false);
        EventManager.CameraMoving(0);
        _iteratorClick = 1;

    }
    public void ButtonLeftClick()
    {
        _iteratorClick--;
        if (_iteratorClick < 1)
        {
            _iteratorClick++;
            return;

        }

        EventManager.CameraMoving(_iteratorClick);
    }
    public void ButtonRightClick()
    {
        
        _iteratorClick++;

        if (_iteratorClick > 4)
        {
            _iteratorClick--;
            return;

        }
        EventManager.CameraMoving(_iteratorClick);

    }
    private void CheckAdd()
    {
        if (_listActiveCharacters.Contains(_activeCharacter.ActiveCharacter))
            _buttonChoiseText.text = "Оставить";
        else
            _buttonChoiseText.text = "Выбрать";

   //     ListActiveCharacters.Contains(_activeCharacter.ActiveCharacter) ? _buttonChoiseText.text = "Оставить" : _buttonChoiseText.text = "Выбрать";
    }
    private void RemoveAtCharacter()
    {
        _listActiveCharacters.Remove(_activeCharacter.ActiveCharacter);
    }
    private void AddListCharacter()
    {
        _listActiveCharacters.Add(_activeCharacter.ActiveCharacter);
    }

    public void ButtonChoiseClick() // - если в списке есть активный игрок, то мы удаляем его из списка при клике, если нет, то добавляем
    {


        if (_listActiveCharacters == null || !_listActiveCharacters.Contains(_activeCharacter.ActiveCharacter))
        {
            AddListCharacter();
        }
        else
            RemoveAtCharacter();

      
    }
    public void StartGameClick()
    {
        if (_listActiveCharacters.Count > 1)
        {
            ListCharacter.DontDestroyListActiveCharacters.AddRange(_listActiveCharacters);
           
            SceneManager.LoadScene("SampleScene");
         
        }
    }

    private void OnDestroy()
    {
        //EventManager.AddingCharacters -= AddListCharacter;

    }
}
