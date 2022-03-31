using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class SaveAnimationData : MonoBehaviour
{
    public Animator _danceFloor;
    public int _start, _char, _obj;
    
    public TextMeshProUGUI _charDataText;
    public TextMeshProUGUI _objDataText;

    //set starting states of state machine which will use int values per function to determine when to change bool states. ss = start/stop c = character and o = object
    void Awake()
    {
        _start = 0;
        _char = 1;
        _obj = 1;
        _charDataText.text = _char.ToString();
        _objDataText.text = _obj.ToString();
    }

    public void CharacterAnimationTransition()
    {
        if (_char == 1)
        {
            _danceFloor.SetBool("change", false);
            _char = 0;
            _charDataText.text = _char.ToString();
        }
        else if (_char == 0)
        {
            _danceFloor.SetBool("change", true);
            _char = 1;
            _charDataText.text = _char.ToString();
        }
    }
    public void ObjectAnimationTransition()
    {
        if (_obj == 1)
        {
            _danceFloor.SetBool("change", false);
            _obj = 0;
            _objDataText.text = _obj.ToString();
            Debug.Log(_obj);
        }
        else if (_obj == 0)
        {
            _danceFloor.SetBool("change", true);
            _obj = 1;
            _objDataText.text = _obj.ToString();
            Debug.Log(_obj);
        }
    }

    public void StartAnimation()
    {
        if (_start == 0)
        {
            _danceFloor.SetBool("change", true);
            _start = 1;
        }
    }
    public void StopAnimation()
    {
        if (_start == 1)
        {
            _danceFloor.SetBool("change", false);
            _start = 0;
        }
    }
    
    public void LoadCharacter()
    {
        if (_char == 1)
        {
            _danceFloor.SetBool("change", true);
            _charDataText.text = _char.ToString();

        }
        else if (_char == 0)
        {
            _danceFloor.SetBool("change", false);
            _charDataText.text = _char.ToString();

        }
    }  
    public void LoadObject()
    {
        if (_obj == 1)
        {
            _danceFloor.SetBool("change", true);
            _objDataText.text = _obj.ToString();
        }
        else if (_obj == 0)
        {
            _danceFloor.SetBool("change", false);
            _objDataText.text = _obj.ToString();
        }
    }
}
