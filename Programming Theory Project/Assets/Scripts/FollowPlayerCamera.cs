using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayerCamera : MonoBehaviour
{
    
    // public GameObject mianCamera;
    private float rotateSpeed = 5;

    void Update()
    {
        if (Input.GetMouseButton(1))
        {
            Follow();
        }


    }
    // ABSTRACTION
    void Follow()
    {
        float horizontalInput = Input.GetAxis("Mouse X");
        transform.Rotate(Vector3.up, rotateSpeed * horizontalInput);
    }
}
