using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AIManager : MonoBehaviour
{
    private GameObject _player;
    public float minDist = 80f;
    public float speed;
    private Animator _animator;
    public bool isMoving;
    public Transform head;
    private Transform playerHead;
    public float maxDist = 4f;
    public float baseLife = 3f;
    private float life;
    public Image healthBar;


    // Start is called before the first frame update
    void Start()
    {
        life = baseLife;
        healthBar.fillAmount = 1;
        _player = GameObject.FindWithTag("Player");
        _animator = GetComponentInChildren<Animator>();
         //get the children named PlayerHead from the player gameobject
        playerHead = _player.transform.GetChild(0).gameObject.transform.GetChild(0);
    }

    public void GetHit() {
        life--;
        if(life <= 0) {
            Destroy(gameObject);
        } else {
            healthBar.fillAmount = life / baseLife;
        }
    }

    // Update is called once per frame
    void Update()
    {   

        Vector3 dist = (_player.transform.position - transform.position);
        Vector3 dir = (playerHead.transform.position - head.position).normalized;

        //check with a ray if the player can be seen
        RaycastHit hit;
        if (Physics.Raycast(head.position, dir, out hit, minDist))
        {   
            Debug.Log(hit.collider.gameObject.tag);
            if (hit.collider.gameObject.CompareTag("Player"))
            {
                if (dist.sqrMagnitude > maxDist) {

                Debug.Log("Player seen");
                isMoving = true;
                transform.LookAt(_player.transform);
                //move towards the player
                transform.position = Vector3.MoveTowards(transform.position, _player.transform.position, speed * Time.deltaTime);
                }
            }
            else
            {
                isMoving = false;
            }
        }
        //  if (dist.sqrMagnitude < minDist)
        // {
        //     if (dist.sqrMagnitude > maxDist) {
        //         transform.position = Vector3.MoveTowards(transform.position, _player.transform.position, speed * Time.deltaTime);
        //         isMoving = true;
        //         transform.LookAt(_player.transform);
        //     }
        // }
        // else
        // {
        //     isMoving = false;
        // }

        _animator.SetBool("isMoving",isMoving);
        
    }
}