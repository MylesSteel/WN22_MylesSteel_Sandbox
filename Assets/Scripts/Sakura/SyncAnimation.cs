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
    public void Start()
    {
        
    }
    public void SetWalkBool()
    {
        //model.walk = true;
        ToggleWalk();
    }
    public void SetAttackBool()
    {
        //model.attack = true;
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
        if(_animator.GetBool("move") == true)
        {
            model.walk = true;

            
        }
        if (_animator.GetBool("move") == false)
        {
            model.walk = false; 
        }
    }  
    private void ToggleAttack()
    {
        if (_animator.GetBool("attack") == true)
        {
            model.attack = true;

            if (_animator.GetBool("attack") == false)
            {
                model.attack = false;
            }
        }
    }
}
