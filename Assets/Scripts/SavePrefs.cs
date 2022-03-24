using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SavePrefs : MonoBehaviour
{
    ChangeUI ui;

    //int intToSave;
    //float floatToSave;
    //string stringToSave;

    private void Awake()
    { 
        ui = GetComponent<ChangeUI>();
        //intToSave = ui.intToSave;
        //floatToSave = ui.floatToSave;
        //stringToSave = ui.stringToSave;
       
    }


    private void Start()
    {
     LoadGame();
    }


   
  // saves playerpref keys and values
    public void SaveGame()
    {
        ui.UpdateInfo();
        //intToSave = Mathf.RoundToInt(ui.intSlider.value);
        //floatToSave = ui.floatSlider.value;
        //stringToSave = ui.nameString.text;
        PlayerPrefs.SetInt("SavedInteger", ui.intToSave);
        PlayerPrefs.SetInt("SavedInteger2", 5);
        PlayerPrefs.SetFloat("SavedFloat", ui.floatToSave);
        PlayerPrefs.SetString("SavedString", ui.stringToSave);
        PlayerPrefs.Save();
        ui.dataText.text = "Your number is " + ui.intToSave.ToString();
        Debug.Log("Game data saved!");
    }
    //loads values from playerprefs
   public void LoadGame()
    {
        //check to see if key/value has been saved
        if (PlayerPrefs.HasKey("SavedInteger"))
        {
            ui.intToSave = PlayerPrefs.GetInt("SavedInteger");
            ui.floatToSave = PlayerPrefs.GetFloat("SavedFloat");
            ui.stringToSave = PlayerPrefs.GetString("SavedString");
          
            ui.dataText.text = "Hello " + ui.stringToSave + ". Your integer was " + ui.intToSave.ToString() + " and your float was " + ui.floatToSave.ToString();
            Debug.Log("Game data loaded!");
        }
        else
        { Debug.LogError("There is no save data!"); }
        StartCoroutine(UpdateUI());
    }

   
    public void ResetData()
    {
        PlayerPrefs.DeleteAll();
        ui.intToSave = 0;
        ui.floatToSave = 0.0f;
        ui.stringToSave = "";
        ui.dataText.text = "Your number is " + ui.intToSave.ToString();
       StartCoroutine( UpdateUI());
       
        Debug.Log("Data reset complete");
    }

   
    IEnumerator UpdateUI()
    {
         
        ui.intText.text = ui.intToSave.ToString();
        yield return new WaitForSeconds(0.1f);
        ui.floatText.text = ui.floatToSave.ToString();
            yield return new WaitForSeconds(0.1f);
        ui.intSlider.value = ui.intToSave;
            yield return new WaitForSeconds(0.1f);
        ui.floatSlider.value = ui.floatToSave;
        Debug.Log(ui.floatToSave);
        //preamble.text = "Enter Name";

    }
}
