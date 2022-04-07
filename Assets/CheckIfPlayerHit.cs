using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckIfPlayerHit : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {   
        Debug.Log("aa");
        if (other.gameObject.tag == "Player")
        {   
            Debug.Log("Trigger win");
        }
    }
}
