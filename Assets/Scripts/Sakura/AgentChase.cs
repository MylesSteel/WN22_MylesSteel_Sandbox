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
    [SerializeField] RealtimeTransform _ownAnimation;
    [SerializeField] GameObject _enemy;
    [SerializeField] Animator _attack;
    public bool _isLocal = true;
    public bool _isStunned = false;
    Vector3 _target;
    // Start is called before the first frame update
    public void OnEnable()
    {
        if (_rt.clientID == 0)
        {
            _ownAnimation.RequestOwnership();
        }
        else
        {
            _agent.enabled = false;
            _isLocal = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(_enemy.transform.position, _player.transform.position) < 100 && _isStunned == false) //add tag for war on empty
        {
            _agent.SetDestination(_player.transform.position);
            _attack.SetBool("move", true);
           
            if (Vector3.Distance(_enemy.transform.position, _player.transform.position) < 2)
            {
                _attack.SetBool("attack", true);
                _agent.enabled = false;
            }
            if (Vector3.Distance(_enemy.transform.position, _player.transform.position) > 2)
            {
                _attack.SetBool("attack", false);
                _attack.SetBool("move", true);
                _agent.enabled = true;
            }
           
        }
        if (_isStunned == true)
        {
            _attack.SetBool("fall", true);
            _attack.SetBool("attack", false);
            _attack.SetBool("move", false);
            _agent.enabled = false;
        }

       // else
        

    }
    
}
//for each loop clients to find distance in update. create buffer time so that chase occurse on the closest client after a delay. May require two for each loops.