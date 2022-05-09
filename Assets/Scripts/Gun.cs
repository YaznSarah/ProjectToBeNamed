using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{

    public float damage = 10f;
    public float range = 100f;
    public float fireRate = 15f;
    public int numberOfShots = 5;

    public Transform bulletStartingPosition;
    public GameObject bullet;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if(Input.GetButtonDown("Fire1")) {
            numberOfShots--;
            if(numberOfShots == 0) {
                GameObject.FindWithTag("Player").GetComponent<PlayerInput>().destroyWeapon();
                Destroy(gameObject);
            }
            //go on the player playerInput script and destroy the gun
            Shoot();
        }

    }

    void Shoot() {
        
        //check if the firerate is ok, then instantiate a bullet and add velocity to it
        
        GameObject bulletClone = Instantiate(bullet, bulletStartingPosition.position, transform.rotation);
        bulletClone.GetComponent<Rigidbody>().velocity = transform.forward * 40;
        Destroy(bulletClone, 2f);

    }
}
