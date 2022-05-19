using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitSomeone : MonoBehaviour
{
    public float type = 1f;

    //If the object hits another object with the Enemy tag, destroy it
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            //find game object with the tag "Player" and call the give life function
            if (type == 1f)
            {
                GameObject.FindWithTag("Player").GetComponent<PlayerLife>().giveLife(10);
                other.gameObject.GetComponent<AIManager>().GetHit();
            }
            else
            {
                GameObject.FindWithTag("Player").GetComponent<PlayerLife>().freezeLife(2);
                other.gameObject.GetComponent<AIManager>().Freeze(4);
            }

            Destroy(gameObject);

            //check if gameobject layer is ground
        }
        else if (other.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            Destroy(gameObject);
        }
    }

    public void setType(float newType)
    {
        type = newType;
    }
}