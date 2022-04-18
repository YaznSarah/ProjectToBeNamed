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
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if ((player.transform.position - transform.position).sqrMagnitude < minDist)
        {
            _isMoving = true;
            transform.position =
                Vector3.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
            transform.LookAt(player.transform);
        }
        else
        {
            _isMoving = false;
        }
    }
}