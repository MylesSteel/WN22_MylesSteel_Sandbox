using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Normal.Realtime;
using System;
public class AgentChase : RealtimeComponent<SyncAnimationModel> //MonoBehaviour
{
    SyncAnimation _rtAni;
    [SerializeField] GameObject _player;      //do it with a tag later
    [SerializeField] NavMeshAgent _agent;
    [SerializeField] Realtime _rt;
    [SerializeField] RealtimeTransform _ownAnimation;
    [SerializeField] GameObject _enemy;
    [SerializeField] Animator _attack;
    public bool _isLocal = true;
    public bool _isStunned = false;
    public bool _inRange = false;
    Vector3 _target;
    // Start is called before the first frame update
    private void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
        //_agent.updatePosition = false;
       // _agent.updateRotation = false;
        _rtAni = GetComponent<SyncAnimation>();
        //FaceTarget();
        if (!_ownAnimation.isOwnedRemotelySelf)
        {
            _ownAnimation.RequestOwnership();
        }
        else
        {
            _agent.enabled = false;
            _isLocal = false;
        }
    }
    void FaceTarget() // attempting to set giant transform location to nav agent.steeringtarget. this is used to get the immidiate destination 
                      // while the agent is moving to the next destination. it like the look at function may just be in the wrong function. 
    {
        var turnTowardNavSteeringTarget = _agent.steeringTarget;

        Vector3 direction = (turnTowardNavSteeringTarget - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5); //idk why this has delta time.
    }
    private void OnAnimatorMove()
    {
       // transform.
       // transform.position = _agent.nextPosition;
        //_inRange = true;
      //  transform.LookAt(_player.transform, Vector3.up);    //does this need to be somewhere else?_agent.nextPosition
    }
    protected override void OnRealtimeModelReplaced(SyncAnimationModel previousModel, SyncAnimationModel currentModel)
    {
        if (previousModel != null)
        {
            previousModel.walkDidChange -= WalkDidChange;
            previousModel.attackDidChange -= AttachDidChange;
        }
        if (currentModel != null)
        {
            if (currentModel.isFreshModel)
            {
                model.attack = false;
                model.walk = false;
            }
            currentModel.walkDidChange += WalkDidChange;
            currentModel.attackDidChange += AttachDidChange;
        }
    }

    private void AttachDidChange(SyncAnimationModel model, bool value)
    {
        _attack.SetBool("attack", true);
    }

    private void WalkDidChange(SyncAnimationModel model, bool value)
    {
        _attack.SetBool("move", true);
    }

    // Update is called once per frame
    void Update()
       
    {
        //if (_inRange == true)
        //{
        //    _agent.speed = 1.25f;
        //}
        //else
        //{
        //    _agent.speed = 1.25f;
        //}
        if (_isStunned == true)
        {
            _attack.SetBool("fall", true);
            //_attack.SetBool("attack", false);
            //_inRange = false;
            _agent.speed = 0f;
            //_attack.SetBool("move", false);

        }
        if (Vector3.Distance(_enemy.transform.position, _player.transform.position) < 25 && _isStunned == false && _isLocal) //add tag for war on empty
        {
            _agent.SetDestination(_player.transform.position);
            //_inRange = true;
            _agent.speed = 1.25f;
            _attack.SetBool("fall", false);
            model.walk = true; // _attack.SetBool("move", true);
            //_rtAni.SetWalkBool();
           
            if (Vector3.Distance(_enemy.transform.position, _player.transform.position) < 2 && model.walk)
            {
                model.attack = true; // _attack.SetBool("attack", true);
                //_attack.SetBool("move", false);
                _agent.speed = 0f;
                //_inRange = false;
                //_enemy.transform.position = _agent.nextPosition;
                //_rtAni.SetWalkBool();
               // _rtAni.SetAttackBool();
                
            }
            if (Vector3.Distance(_enemy.transform.position, _player.transform.position) > 2) // return to walking. attack animation has exit time.
            {
                model.attack = false;
                _attack.SetBool("attack", false);
               // _attack.SetBool("move", true);
                _agent.speed = 1.25f;
                //_inRange = true;
                //_rtAni.SetAttackBool();
                //_rtAni.SetWalkBool();

            }
           
        }
        //if (Vector3.Distance(_enemy.transform.position, _player.transform.position) > 25 && _isStunned == false) // idle state
        //{

        //    _attack.SetBool("fall", false);
        //    _attack.SetBool("attack", false);
        //    _attack.SetBool("move", false);
        //    _agent.speed = 0f;
        //    //_inRange = false;
           
        //}
        

       // else
        

    }
    
}
//for each loop clients to find distance in update. create buffer time so that chase occurse on the closest client after a delay. May require two for each loops.