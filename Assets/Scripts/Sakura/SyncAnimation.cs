using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Normal.Realtime;
using System;

public class SyncAnimation : RealtimeComponent<SyncAnimationModel>
{
    public Realtime _realtime;
    public Animator _animator;

    public void SetWalkBool()
    {
        model.walk = true;
        ToggleWalk();
    }
    public void SetAttackBool()
    {
        model.attack = true;
        ToggleAttack();
    }

    private void ToggleAttack()
    {
        if (model.attack == true)
        {
            _animator.SetBool("attack,", true);
        }
        else
        {
            _animator.SetBool("attack", false);
            model.attack = false;
        }
    }

    void ToggleWalk()
    {
        if(model.walk == true)
        {
            _animator.SetBool("walk,", true);
        }
        else
        {
            _animator.SetBool("walk", false);
            model.walk = false;
        }
    }
}
