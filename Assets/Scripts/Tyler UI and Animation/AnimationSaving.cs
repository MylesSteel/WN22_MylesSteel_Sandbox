using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationSaving : MonoBehaviour
{
    public Animator _danceFloor;
    public int _start, _char, _obj;
    [SerializeField] string parameter;
    
    //set starting states of state machine which will use int values per function to determine when to change bool states. ss = start/stop c = character and o = object
    void Awake()
    {
        _start = 0;
        _char = 1;
        _obj = 1;
    }

    public void CharacterAnimationTransition()
    {
        if (_char == 1)
        {
            _danceFloor.SetBool(parameter, false);
            _char = 0;
        }
        else if (_char == 0)
        {
            _danceFloor.SetBool(parameter, true);
            _char = 1;
        }
    }
    public void ObjectAnimationTransition()
    {
        if (_obj == 1)
        {
            _danceFloor.SetBool(parameter, false);
            _obj = 0;
            Debug.Log(_obj);
        }
        else if (_obj == 0)
        {
            _danceFloor.SetBool(parameter, true);
            _obj = 1;
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
            _danceFloor.SetBool(parameter, true);
        }
        else if (_char == 0)
        {
            _danceFloor.SetBool(parameter, false);
        }
    }  
    public void LoadObject()
    {
        if (_obj == 1)
        {
            _danceFloor.SetBool(parameter, true);
        }
        else if (_obj == 0)
        {
            _danceFloor.SetBool(parameter, false);
        }
    }
}
