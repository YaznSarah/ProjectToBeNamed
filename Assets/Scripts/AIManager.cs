using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AIManager : MonoBehaviour
{
    private GameObject _player;
    private Animator _animator;
    private Transform playerHead;

    public float minDist = 30f;
    public float speed;

    [HideInInspector] public bool isMoving;
    public bool isDead;

    public Transform head;

    public float maxDist = 80f;

    public float baseLife = 3f;
    private float _life;
    public Image healthBar;

    private bool isFreezed;

    // Start is called before the first frame update
    void Start()
    {
        _life = baseLife;
        healthBar.fillAmount = 1;
        _player = GameObject.FindWithTag("Player");
        _animator = GetComponentInChildren<Animator>();
        //get the children named PlayerHead from the player gameobject
        playerHead = _player.transform.GetChild(0).gameObject.transform.GetChild(0);
    }

    public void GetHit()
    {
        _life--;
        if (_life <= 0)
        {
            isDead = true;
            isMoving = false;
            Object.Destroy(gameObject, 10f);
        }
        else
        {
            healthBar.fillAmount = _life / baseLife;
        }
    }

    public void Freeze(float seconds)
    {
        isFreezed = true;
        //start coroutine unFreeze
        StartCoroutine(unfreeze(seconds));
    }

    //create a routine that set isFreezed to false in n seconds
    IEnumerator unfreeze(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        isFreezed = false;
    }

    // Update is called once per frame
    void Update()
    {
        _animator.SetBool("isMoving", isMoving);
        Vector3 dist = (_player.transform.position - transform.position);
        
        //check with a ray if player can be seen
        Vector3 headDir = (playerHead.transform.position - head.position.normalized);
        RaycastHit hit;
        if ((dist.sqrMagnitude < minDist))
        {
            Debug.Log(dist.sqrMagnitude);
            if (dist.sqrMagnitude > maxDist)
            {
                isMoving = true;
                transform.LookAt(_player.transform);
            }
        }
        else
        {
            isMoving = false;
        }

        _animator.SetBool("isMoving", isMoving);
        _animator.SetBool("isDead", isDead);
    }
}