using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkAnimationSound : MonoBehaviour
{
    [SerializeField] AudioSource _audioTrigger;
    
        

    // Start is called before the first frame update
    private void FootStepSound() // function to be called in animation event. not sure if this is working. 
    {
        _audioTrigger.volume = Random.Range(0.95f, 0.99f);
        _audioTrigger.pitch = Random.Range(0.9f, 0.99f);
        _audioTrigger.Play();
    }
    private void FallSound()
    {
        _audioTrigger.volume = Random.Range(1.05f, 1.1f);
        _audioTrigger.pitch = Random.Range(0.5f, 0.6f);
        _audioTrigger.Play();
    }
}
