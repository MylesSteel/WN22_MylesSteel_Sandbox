using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StompAnimationSound : MonoBehaviour
{
    [SerializeField] AudioSource stomp;
    private void StompSound()
    {
        stomp.volume = Random.Range(1.1f, 1.3f);
        stomp.pitch = Random.Range(0.85f, 0.99f);
        stomp.Play();
    }
}
