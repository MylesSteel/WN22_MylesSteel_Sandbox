using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableGiant : MonoBehaviour
{
    [SerializeField] GameObject _giant;
    

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            _giant.SetActive(true);
        }
    }
}
// prefab of VR Player does not populate player tag because it is a clone. have to figure out how to set each of the three clones as players.
//in the agent chase script (players)