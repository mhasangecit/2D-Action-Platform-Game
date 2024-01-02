using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bgFollow : MonoBehaviour
{
    public Camera cam;

    void Start()
    {
        
    }

    void FixedUpdate()
    {
        transform.position = new Vector3(cam.transform.position.x, cam.transform.position.y, -9.5f);
    }
}
