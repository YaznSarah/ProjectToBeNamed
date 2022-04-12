using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIManager : MonoBehaviour
{   

    public GameObject player;
    public float minDist = 10f;
    public float speed;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update() {
 
         if ((player.transform.position - transform.position).sqrMagnitude < minDist)
         {
             transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
             transform.LookAt(player.transform);
         }
     }

}
