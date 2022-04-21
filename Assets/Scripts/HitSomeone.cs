using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitSomeone : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //If the object hits another object with the Enemy tag, destroy it
    void OnTriggerEnter(Collider other)
    {   
        if (other.gameObject.tag == "Enemy")
        {
            //find game object with the tag "Player" and call the give life function
            GameObject.FindWithTag("Player").GetComponent<PlayerLife>().giveLife(10);
            Destroy(other.gameObject);
            Destroy(gameObject);

        }
    }
}
