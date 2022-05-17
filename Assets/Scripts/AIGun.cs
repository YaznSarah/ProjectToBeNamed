using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIGun : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject _weapon;
    private AIManager _ai;
    private Vector3 _holsterLocation;
    private Vector3 _holsterRotation;
    public float damage = 10f;
    public float range = 100f;

    public Transform bulletStartingPosition;
    public GameObject bullet;

    [HideInInspector]
    float fireRate = 0f;

    void storePositions()
    {
        Vector3 initialLocation = _weapon.transform.localPosition;
        Vector3 initialRotation = _weapon.transform.localEulerAngles;
        _holsterLocation = initialLocation;
        _holsterRotation = initialRotation;
    }

    void Start()
    {
        _weapon = gameObject;
        storePositions();
        _ai = GetComponentInParent<AIManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_ai.isMoving)
        {
            //if the firerate is at 0, then fire using the AIGun script
                if (fireRate <= 0f)
                {   
                    if(GameObject.FindWithTag("Player").GetComponent<PlayerLife>().finished) return;
                    Shoot();
                    fireRate = 1.5f;
                }
                else
                {
                    fireRate -= Time.deltaTime;
                }

            _weapon.transform.localPosition = new Vector3(1.7581f, 1.4732f, 1.1357f);
            _weapon.transform.localEulerAngles = new Vector3(2.147f, 15.318f, 2.474f);
        }
        else
        {
            _weapon.transform.localPosition = _holsterLocation;
            _weapon.transform.localEulerAngles = _holsterRotation;
        }
    }

    public void Shoot()
    {
        //check if the firerate is ok, then instantiate a bullet and add velocity to it
        GameObject bulletClone = Instantiate(bullet, bulletStartingPosition.position, transform.rotation);

        Vector3 direction = GameObject.FindWithTag("Player").transform.position - bulletStartingPosition.position;
        Vector3 newvector = Vector3.Normalize(direction);

        bulletClone.GetComponent<Rigidbody>().velocity = newvector * 40;
        Destroy(bulletClone, 2f);
    }
}