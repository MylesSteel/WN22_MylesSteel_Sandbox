using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class TwoObjectsMove : MonoBehaviour
{
    
    [SerializeField] NavMeshAgent _agent;
    // Update is called once per frame
    private void Start()
    {
        _agent.updatePosition = false;
        //_agent.updateRotation = false;
    }
    private void OnAnimatorMove()
    {
        transform.position = _agent.nextPosition;
        //transform.LookAt(_agent.nextPosition, Vector3.up);
    }
}
