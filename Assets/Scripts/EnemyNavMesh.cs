using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyNavMesh : MonoBehaviour
{
    private NavMeshAgent _navMeshAgent;
    private Transform _targetTransform;
    private void Awake()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _targetTransform = GameObject.FindWithTag("Player").transform;
    }

    private void Update()
    {
        _navMeshAgent.destination = _targetTransform.position;
    }
}
