using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AIManager : MonoBehaviour
{
    private GameObject _player;
    private float _minDist = 60f;  
    private float _maxDist = 4f;
    public float speed;
    private Animator _animator;
    public bool isMoving;
  


    // Start is called before the first frame update
    void Start()
    {
        _player = GameObject.FindWithTag("Player");
        _animator = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        _animator.SetBool("isMoving", isMoving);
        Vector3 dist = (_player.transform.position - transform.position);
        if (dist.sqrMagnitude < _minDist)
        {
            Debug.Log(dist.sqrMagnitude);
            if (dist.sqrMagnitude > _maxDist) {
                isMoving = true;
                transform.LookAt(_player.transform);
            }
        }
        else
        {
            isMoving = false;
        }

    }
}