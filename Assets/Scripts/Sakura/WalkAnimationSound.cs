using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkAnimationSound : MonoBehaviour
{ 
    [SerializeField] AudioSource _walkSound;

    // Start is called before the first frame update
    private void FootStepSound() // function to be called in animation event. not sure if this is working. 
    {
        
        _walkSound.volume = Random.Range(0.95f, 0.99f);
        _walkSound.pitch = Random.Range(0.65f, 0.80f);
        _walkSound.Play();
    }
    private void FallSound()
    {
        _walkSound.volume = Random.Range(1.05f, 1.1f);
        _walkSound.pitch = Random.Range(0.5f, 0.6f);
        _walkSound.Play();

    }

}
