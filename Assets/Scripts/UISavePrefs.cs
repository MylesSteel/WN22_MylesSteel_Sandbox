using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UISavePrefs : MonoBehaviour
{
    public Animator _danceController;
    public int _intSave = 0;
    //public string _stringSave;

    public TextMeshProUGUI _intText;
    public Slider _intSlider;
    //public TextMeshProUGUI _dataText;

    public void Awake()
    {
        _intSlider.value = 0;
    }
    public void Start()
    {
        LoadGame();
        //_dataText.text = "Move the slider to change the dance floor!";
    }  
    public void SaveGame()
    {
        PlayerPrefs.SetInt("SavedInteger", _intSave);
        Debug.Log("Game data saved!");
    } 
    public void LoadGame()
    {
        if (PlayerPrefs.HasKey("SavedInteger"))
        {
            _intSave = PlayerPrefs.GetInt("SavedInteger");
        }
        else
        { Debug.LogError("There is no save data!"); }
        StartCoroutine(UpdateUI());
    } 
    public void ResetData()
    {
        PlayerPrefs.DeleteAll();
        _intSave = 0;
        _intSlider.value = _intSave;

        StartCoroutine(UpdateUI());
        Debug.Log("data has been reset");
    }
    public void ChangeIntSlider()
    {
        _intSave = Mathf.RoundToInt(_intSlider.value); //round up to int
        _intText.text = _intSave.ToString();
        Debug.Log("Changed slider info");
        _danceController.SetInteger("change", _intSave);
    }

    public void UpdateState()
    {
        _intSave = Mathf.RoundToInt(_intSlider.value);
        //_dataText.text = _stringSave;
    }
    public void DisplayToUI()
    {
        _intSlider.value = _intSave;
        _intText.text = _intSave.ToString();
        Debug.Log("Display info called");
    }
    public void AnimationSwitch(int Switch)
    {
        _danceController.SetInteger("change", _intSave);

        if (_intSave == 0)
        {
            _danceController.SetInteger("change", _intSave);
        }
        else _danceController.SetInteger("change", _intSave);
    }
    IEnumerator UpdateUI()
    {
        _intSlider.value = _intSave;
        yield return new WaitForSeconds(0.1f);

        _intText.text = _intSave.ToString();
        yield return new WaitForSeconds(0.1f);

    }
}
