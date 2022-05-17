using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckIfPlayerFlee : MonoBehaviour
{
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Trigger win");
            other.gameObject.GetComponent<PlayerLife>().triggerGameOver();
        }
    }
}