using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public float speed = 12f;
    public float jumpHeight = 2f;
    public float sensi = .5f;
    public float _gravity = -20f;

    private Vector2 seeDir;
    public GameObject cam;

    public GameObject weapon;
    
    [HideInInspector]
    public bool showWeapon = false;
    [HideInInspector]
    public float weaponType = 1;

    public Transform groundPos;
    public LayerMask groundMask;
    public float groundDistance = 0.4f;

    private Vector3 _velocity;
    public CharacterController playerMovements;

    private bool _isGrounded;

    // Start is called before the first frame update
    void Start()
    {   
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void GiveWeapon(float newWeaponType)
    {
        showWeapon = true;
        weaponType = newWeaponType;
        weapon.SetActive(true);
    }

    public void destroyWeapon()
    {
        showWeapon = false;
        weapon.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseMenu pauseMenu = GameObject.Find("PauseMenu").GetComponent<PauseMenu>();
            pauseMenu.Pause();
            if(Input.GetKeyDown(KeyCode.Escape))
            {
               pauseMenu.Resume();
            }
        }
        
        _isGrounded = Physics.CheckSphere(groundPos.position, groundDistance, groundMask);

        if (_isGrounded && _velocity.y < -2f)
        {
            _velocity.y = -2f;
        }

        Vector3 movement = transform.right * Input.GetAxis("Horizontal") +
                           transform.forward * Input.GetAxis("Vertical");
        playerMovements.Move(movement * speed * Time.deltaTime);


        if (Input.GetButtonDown("Jump") && _isGrounded)
        {
            _velocity.y = Mathf.Sqrt(jumpHeight * -2f * _gravity * Time.deltaTime);
        }

        _velocity.y += _gravity * Time.deltaTime;

        playerMovements.Move(_velocity * Time.deltaTime);


        seeDir.x += Input.GetAxis("Mouse X") * sensi;
        seeDir.y += Input.GetAxis("Mouse Y") * sensi;
        transform.localRotation = Quaternion.Euler(0, seeDir.x, 0);

        if (seeDir.y > 90)
        {
            seeDir.y = 90;
        }
        else if (seeDir.y < -90)
        {
            seeDir.y = -90;
        }

        cam.transform.localRotation = Quaternion.Euler(-seeDir.y, 0, 0);

        if(showWeapon) {
            weapon.transform.localRotation = Quaternion.Euler(-seeDir.y, 0, 0);
        }
    }
}