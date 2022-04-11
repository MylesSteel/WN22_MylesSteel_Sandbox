using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationSound : MonoBehaviour
{
    [SerializeField] AudioSource _audioTrigger;
    public AudioClip _fall1;
    public AudioClip _fall2;
    public AudioClip _fall3;
    public AudioClip _stomp;


    // Start is called before the first frame update
    private void FootStepSound() // function to be called in animation event. not sure if this is working. 
    {
        _audioTrigger.volume = Random.Range(0.95f, 0.99f);
        _audioTrigger.pitch = Random.Range(0.9f, 0.99f);
        _audioTrigger.Play();
    }
    private void FallSound1()
    {
        _audioTrigger.volume = Random.Range(1.05f, 1.1f);
        _audioTrigger.pitch = Random.Range(0.5f, 0.6f);
        _audioTrigger.PlayOneShot(_fall1);
    }
    private void FallSound2()
    {
        _audioTrigger.volume = Random.Range(1.05f, 1.1f);
        _audioTrigger.pitch = Random.Range(0.5f, 0.6f);
        _audioTrigger.PlayOneShot(_fall2);
    }
    private void FallSound3()
    {
        _audioTrigger.volume = Random.Range(1.05f, 1.1f);
        _audioTrigger.pitch = Random.Range(0.5f, 0.6f);
        _audioTrigger.PlayOneShot(_fall3);
    }
    private void StompSound()
    {
        _audioTrigger.volume = Random.Range(1.1f, 1.3f);
        _audioTrigger.pitch = Random.Range(0.85f, 0.99f);
        _audioTrigger.PlayOneShot(_stomp);
    }
}
