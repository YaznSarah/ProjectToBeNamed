using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitPlayer : MonoBehaviour
{
    //If the object hits another object with the Enemy tag, destroy it
    void OnTriggerEnter(Collider other)
    {   

        if (other.gameObject.tag == "Player")
        {
            //find game object with the tag "Player" and call the give life function
            GameObject.FindWithTag("Player").GetComponent<PlayerLife>().giveLife(-10);
            Destroy(gameObject);

        }
    }
}
