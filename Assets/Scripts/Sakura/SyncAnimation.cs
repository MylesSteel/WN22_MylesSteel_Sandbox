using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Normal.Realtime;
using System;

public class SyncAnimation : RealtimeComponent<SyncAnimationModel>
{
    private SyncAnimationModel _aniModel;
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
    private SyncAnimationModel modelWalk
    {
        set
        {
            if (_aniModel != null)
            {
                _aniModel.walkDidChange -= WalkChanged;
            }
        }
    }
    private SyncAnimationModel modelAttack
    {
        set
        {
            if (_aniModel != null)
            {
                _aniModel.attackDidChange -= AttackChanged;
            }
        }
    }
    private void WalkChanged(SyncAnimationModel model, bool value)
    {
        ToggleWalk();
    }
    private void AttackChanged(SyncAnimationModel model, bool value)
    {
        ToggleAttack();
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
}
