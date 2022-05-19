using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class EnemyNavMesh : MonoBehaviour
{
    private NavMeshAgent _navMeshAgent;
    private Transform _targetTransform;
    private AIManager _aiManager;
    private void Awake()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _aiManager = GetComponent<AIManager>();
        _targetTransform = GameObject.FindWithTag("Player").transform;
    }

    private void Update()
    {
        if (_aiManager.isMoving)
        {
            _navMeshAgent.destination = _targetTransform.position;
        }
        else if(_aiManager.isDead)
        {
            _navMeshAgent.isStopped = true;
        }
    }
}
