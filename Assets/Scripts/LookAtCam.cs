using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtCam : MonoBehaviour
{
    void Update()
    {
        //get object of tag MainCamera
        GameObject cam = GameObject.FindWithTag("MainCamera");
        Vector3 v = cam.transform.position - transform.position;
        v.x = v.z = 0.0f;
        transform.LookAt(cam.transform.position - v);
        transform.Rotate(0, 180, 0);
    }
}