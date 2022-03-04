using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class AnimationTrigger : MonoBehaviour
{
    public Animator animator;
    [SerializeField]
    GameObject capsule;
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        { 

            capsule.isStatic = false;
            TransitionAnimation();
        }
    }
    public void TransitionAnimation()
    {

        if (!animator.GetBool("Toggle"))
        {
            animator.SetBool("Toggle", true);
        }
        else animator.SetBool("Toggle", false);
    }
    public void AnimationStart()
    {
        if (!animator.GetBool("Start"))
        {
            animator.SetBool("Start", true);
        }
        else
        {
            animator.SetBool("start", false);
        }
    }
    
}
