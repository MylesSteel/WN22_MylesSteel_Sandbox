using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnAtRandom : MonoBehaviour
{
    [SerializeField] public Transform[] spawnPoints;
    public GameObject obj;
    


    void Start()
    {
           int randNum = Random.Range(0, spawnPoints.Length);
            Instantiate(obj, spawnPoints[randNum].transform);
    }

}