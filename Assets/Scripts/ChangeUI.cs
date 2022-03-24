using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ChangeUI : MonoBehaviour
{
    public int intToSave;
    public float floatToSave;
    public string stringToSave;
    //public bool boolToSave;

    public TextMeshProUGUI floatText;
    public TextMeshProUGUI intText;
    public TextMeshProUGUI dataText;
    //public TextMeshProUGUI preamble;

    public Slider floatSlider, intSlider;
    //public Toggle inputBool;
    public TMP_InputField nameString;

    //bool onShowObject = false;
    //Color saveObjectColor = Color.blue;
  

    public void ChangeSliderValue()
    {
        floatToSave = floatSlider.value;
        intToSave = Mathf.RoundToInt(intSlider.value);
        intText.text = intToSave.ToString();
        floatText.text = floatToSave.ToString();
    }

    public void UpdateInfo()
    {
        //boolToSave = inputBool;
        intToSave = Mathf.RoundToInt(intSlider.value);
        floatToSave = floatSlider.value;
        stringToSave = nameString.text;
        dataText.text = stringToSave;
    }
    public void DisplayInfo()
    {
        intText.text = intToSave.ToString();
        floatText.text = floatToSave.ToString();
        intSlider.value = (float)intToSave;
        floatSlider.value = floatToSave;
        Debug.Log("Both slider updated");
    }
    
    public void QuiteGame()
    {
       // UnityEditor.EditorApplication.isPlaying = false;
    }

}
