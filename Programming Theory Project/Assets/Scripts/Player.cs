using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

// INHERITANCE (parent)
// Base class for all Player. It will handle movement order given through the PlayerController script.

public abstract class Player : MonoBehaviour

{
    // ENCAPSULATION
    public float m_speed {get;} = 50;
    public float m_rotateSpeed {get;} = 30;

    public bool isTarget;

    void Update()
    {
        if (isTarget)
        {
            Move(m_speed, m_rotateSpeed);
        }
        OutOfBound();
    }

    // ABSTRACTION
    // use keyboard control gameObject to move different directions
    public virtual void Move(float speed, float rotateSpeed)
    {
        float verticalInput = Input.GetAxis("Vertical");
        float horizontalInput = Input.GetAxis("Horizontal");
        // moving forward / backward
        transform.Translate(Vector3.forward * speed * verticalInput * Time.deltaTime);
        // turn left / right
        transform.Rotate(Vector3.up, rotateSpeed * horizontalInput * Time.deltaTime);
        if (verticalInput != 0)
        {
            transform.GetComponent<Animator>().SetFloat("Speed_f", 1);
        }
        else 
        {
            transform.GetComponent<Animator>().SetFloat("Speed_f", 0);
        }
    }

    // ABSTRACTION
    // transport to other side if they across beyond the boundries
    private void OutOfBound()
    {
        float upBound = 225;
        float downBound = -225;
        float leftBound = -225;
        float rightBound = 225;
        
        if (transform.position.x < leftBound)
        {
            transform.position = new Vector3 (rightBound, transform.position.y, transform.position.z);
        }
        else if (transform.position.x > rightBound)
        {
            transform.position = new Vector3 (leftBound, transform.position.y, transform.position.z);
        }
        else if (transform.position.z < downBound)
        {
            transform.position = new Vector3 (transform.position.x, transform.position.y, upBound);
        }
        else if (transform.position.z > upBound)
        {
            transform.position = new Vector3 (transform.position.x, transform.position.y, downBound);
        }
    }

    // ABSTRACTION
    public virtual string GetName()
    {
        return "Player";
    }

    // ABSTRACTION
    public virtual Color GetColor()
    {
        return new Color (0, 0, 0);
    }

}
