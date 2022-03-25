using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Normal.Realtime;
using System;
public class AgentChase : MonoBehaviour
{
    [SerializeField] GameObject _player;      //do it with a tag later
    [SerializeField] NavMeshAgent _agent;
    [SerializeField] Realtime _rt;
    [SerializeField] RealtimeTransform _rtTransform;
    [SerializeField] GameObject _enemy;
    [SerializeField] Animator _attack;
    Vector3 _target;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(_enemy.transform.position, _player.transform.position) < 100) //add tag for war on empty
        {
            _agent.SetDestination(_player.transform.position);
            _attack.SetBool("move", true);
           {
            if (Vector3.Distance(_enemy.transform.position, _player.transform.position) < 2)
            {
                _attack.SetBool("attack", true);

            }
            if (Vector3.Distance(_enemy.transform.position, _player.transform.position) > 2)
            {
                _attack.SetBool("attack", false);
            _attack.SetBool("move", true);
            }
        }
        }
       // else
        

    }
    
}
