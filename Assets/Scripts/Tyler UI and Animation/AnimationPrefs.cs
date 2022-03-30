using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationPrefs : MonoBehaviour
{
    [SerializeField] AnimationSaving uiC;
    [SerializeField] AnimationSaving uiO;

    private void Awake()
    {
        //ui = GetComponent<AnimationSaving>();
    }
    // Start is called before the first frame update
    void Start()
    {
        LoadGame();
    }

 
    //save all int values used to determine bool states of state machine
    public void SaveGame()
    {
       

        PlayerPrefs.SetInt("characterState", uiC._char);

        PlayerPrefs.SetInt("objectState", uiO._obj);
        PlayerPrefs.Save();

        Debug.Log("Data Saved");
    }

    public void LoadGame()
    {
        if (PlayerPrefs.HasKey("characterState"))
        {
            
            uiC._char = PlayerPrefs.GetInt("characterState");
            uiC.LoadCharacter();

            uiO._obj = PlayerPrefs.GetInt("objectState");
            uiO.LoadObject();

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
        
        uiC._char = 1;
        uiC._danceFloor.SetBool("change", false);

        uiO._obj = 1;
        uiO._danceFloor.SetBool("change", false);


        Debug.Log("Data Reset");
    }
}
