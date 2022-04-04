using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkAnimationSound : MonoBehaviour
{ 
    [SerializeField] AudioSource _walkSound;

    // Start is called before the first frame update
    private void FootStepSound()
    {
        _walkSound.Play();
    }

}
