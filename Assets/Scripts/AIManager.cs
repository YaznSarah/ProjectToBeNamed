using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIManager : MonoBehaviour
{
    private GameObject _player;
    public float minDist = 10f;
    public float speed;
    private Animator _animator;
    public bool isMoving;
    public float maxDist = 4f;


    // Start is called before the first frame update
    void Start()
    {
        _player = GameObject.FindWithTag("Player");
        _animator = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {   

        Debug.Log("HEy");
        Vector3 dist = (_player.transform.position - transform.position);
         if (dist.sqrMagnitude < minDist)
        {
            if (dist.sqrMagnitude > maxDist) {
                transform.position = Vector3.MoveTowards(transform.position, _player.transform.position, speed * Time.deltaTime);
                isMoving = true;
                transform.LookAt(_player.transform);
            }
        }
        else
        {
            isMoving = false;
        }

        _animator.SetBool("isMoving",isMoving);
        
    }
}