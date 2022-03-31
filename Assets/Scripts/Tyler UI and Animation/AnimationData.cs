using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationData : MonoBehaviour
{
    [SerializeField] SaveAnimationData _charUI;
    [SerializeField] SaveAnimationData _objUI;

    void Start()
    {
        LoadGame();
    }

 
    //save int value of either animator to apply to bool state. 
    public void SaveGame()
    {
       

        PlayerPrefs.SetInt("characterState", _charUI._char);

        PlayerPrefs.SetInt("objectState", _objUI._obj);
        PlayerPrefs.Save();

        Debug.Log("Data Saved");
    }

    public void LoadGame()
    {
        if (PlayerPrefs.HasKey("characterState"))
        {

            _charUI._char = PlayerPrefs.GetInt("characterState");
            _charUI.LoadCharacter();

            _objUI._obj = PlayerPrefs.GetInt("objectState");
            _objUI.LoadObject();

            Debug.Log("Data Loaded");
        }
        else
        {
            Debug.Log("No data to load");
        }
    }

    public void ResetData()
    {
        PlayerPrefs.DeleteAll();

        _charUI._char = 1;
        _charUI._danceFloor.SetBool("change", false);

        _objUI._obj = 1;
        _objUI._danceFloor.SetBool("change", false);


        Debug.Log("Data Reset");
    }
    public void QuitGame()
    {
        UnityEditor.EditorApplication.isPlaying = false;
    }
}
