using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DanceOnOff : MonoBehaviour
{
    public Animator dance;
    public int _X = 0;

    public void ChangeInt()
    {
        
        if (_X == 0)
        {
            _X = 1;
            ChangeAnimation();
        }
        else
        {
            _X = 0;
            ChangeAnimation();
        }
    } 
    public void ChangeAnimation()
    {
        if (_X == 0)
        {
            dance.SetBool("dance", false);
          
        } 
        if (_X == 1)
        {
            dance.SetBool("dance", true);
        }
    }
}
