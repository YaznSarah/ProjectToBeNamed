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

    [HideInInspector]
    public bool isMoving;
    
    public Transform head;
    private Transform playerHead;
    public float maxDist = 4f;
    
    public float baseLife = 3f;
    private float life;
    public Image healthBar;

    private bool isFreezed;

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

    public void Freeze(float seconds) {
        isFreezed = true;
        //start coroutine unFreeze
        StartCoroutine(unfreeze(seconds));
    }

    //create a routine that set isFreezed to false in n seconds
    IEnumerator unfreeze(float seconds) {
        yield return new WaitForSeconds(seconds);
        isFreezed = false;
    }

    // Update is called once per frame
    void Update()
    {   

        Vector3 dist = (_player.transform.position - transform.position);
        Vector3 dir = (playerHead.transform.position - head.position).normalized;

        isMoving = false;

        //check with a ray if the player can be seen
        RaycastHit hit;
        if (Physics.Raycast(head.position, dir, out hit, minDist))
        {   
            if (hit.collider.gameObject.CompareTag("Player"))
            {
                if (dist.sqrMagnitude < minDist * minDist) {
                    
                    transform.LookAt(_player.transform);
                    //move towards the player
                    if(dist.sqrMagnitude < maxDist * maxDist) {
                        isMoving = true;
                        _animator.SetBool("isMoving",true);
                        return;
                    }
                    
                    if(!isFreezed) {
                        isMoving = true;
                        transform.position = Vector3.MoveTowards(transform.position, _player.transform.position, speed * Time.deltaTime);
                    }
                }
            }
        }

        _animator.SetBool("isMoving", isMoving);

        
        
    }
}