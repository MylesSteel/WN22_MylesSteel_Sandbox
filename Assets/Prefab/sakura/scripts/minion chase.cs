using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Normal.Realtime;
using UnityEngine.AI;

public class minionchase : MonoBehaviour
{
    [SerializeField] GameObject _player;
    [SerializeField] NavMeshAgent _agent;
    [SerializeField] GameObject _enemy;        // the ghost npc
    [SerializeField] RealtimeTransform _rtTrans;
    [SerializeField] AudioSource _ghostSound;
    public bool _isLocal = true;

    private void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
        if (!_rtTrans.isOwnedRemotelySelf)
        {
            _rtTrans.RequestOwnership();
        }
        else
        {
            _agent.enabled = false;
            _isLocal = false;
        }
    }
    private void Update()
    {
        if (Vector3.Distance(_enemy.transform.position, _player.transform.position) < 25)
        {
            _agent.SetDestination(_player.transform.position);
            if (Vector3.Distance(_enemy.transform.position, _player.transform.position) >.05f)
            {
                _ghostSound.Play();
                Destroy(_enemy);
                //player health -1
            }
        }
    }
}
