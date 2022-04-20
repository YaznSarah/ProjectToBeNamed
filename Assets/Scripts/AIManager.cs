using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIManager : MonoBehaviour
{
    public GameObject player;
    public float minDist = 10f;
    public float speed;
    private Animator _animator;
    private bool _isMoving;


    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 dist = (player.transform.position - transform.position);
        if (dist.sqrMagnitude < minDist)
        {
            _isMoving = true;
            transform.position =
                Vector3.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
            _isMoving = true;
            transform.LookAt(player.transform);
        }
        else
        {
            _isMoving = false;
        }

        if (_isMoving)
        {
            _animator.SetBool("isMoving",_isMoving);
        }
    }
}