using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{

    public float damage = 10f;
    public float range = 100f;
    public float fireRate = 15f;
    public int numberOfShots = 5;
    public Transform weapon;

    public Transform bulletStartingPosition;
    public GameObject bullet;


    // Update is called once per frame
    void Update()
    {

        if(Input.GetButtonDown("Fire1") && 
            gameObject.GetComponent<PlayerInput>().showWeapon) {
            numberOfShots--;
            if(numberOfShots == 0) {
                gameObject.GetComponent<PlayerInput>().destroyWeapon();
                numberOfShots = 5;
            }
            //go on the player playerInput script and destroy the gun
            Shoot();
        }

    }

    void Shoot() {
        
        //check if the firerate is ok, then instantiate a bullet and add velocity to it
        GameObject bulletClone = Instantiate(bullet, bulletStartingPosition.position, weapon.rotation);
        bulletClone.GetComponent<Rigidbody>().velocity = weapon.forward * 40;
        bulletClone.GetComponent<HitSomeone>().setType(gameObject.GetComponent<PlayerInput>().weaponType);
        Destroy(bulletClone, 2f);

    }
}
