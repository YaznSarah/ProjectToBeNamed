using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{   

    public float speed;
    public float jumpForce;
    public float lastYpos;
    public float sensi = .5f;

    Vector2 seeDir;
    public GameObject cam;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        transform.Translate(movement * speed * Time.deltaTime);
        Debug.Log(movement * speed * Time.deltaTime);
        Debug.Log("VERTICAL : " + Input.GetAxis("Vertical"));

        if (Input.GetKeyDown("space")) {
            Debug.Log("HEY");
            if((lastYpos - transform.position.y) < .1f && (lastYpos - transform.position.y) > -.1f) {
                Debug.Log("OH");
                GetComponent<Rigidbody>().AddForce(Vector3.up * jumpForce);
            }
        }

        lastYpos = transform.position.y;

        seeDir.x += Input.GetAxis("Mouse X") * sensi;
        seeDir.y += Input.GetAxis("Mouse Y") * sensi;
        transform.localRotation = Quaternion.Euler(0, seeDir.x, 0);
        cam.transform.localRotation = Quaternion.Euler(-seeDir.y, 0, 0);
    }
}
