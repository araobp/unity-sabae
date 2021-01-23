using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkerController : MonoBehaviour
{
    Animator animator;
    bool walking = false;
    bool turningLeft = false;
    bool turningRight = false;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        if (turningLeft || Input.GetKey(KeyCode.A))
        {
            transform.Rotate(0, -0.5F, 0);
        }
        if (turningRight || Input.GetKey(KeyCode.D))
        {
            transform.Rotate(0, 0.5F, 0);
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            if (!walking)
            {
                walking = true;
                Walk();
            }
        } else if (Input.GetKeyUp(KeyCode.W))
        {
            if (walking)
            {
                walking = false;
                Stop();
            }
        }
    }

    public void Walk()
    {
        animator.SetTrigger("Walk");
    }

    public void Stop()
    {
        animator.SetTrigger("Stop");
    }

    public void TurnLeft()
    {
        turningLeft = true;
    }
    
    public void TurnRight()
    {
        turningRight = true;
    }

    public void TurnLeftStop()
    {
        turningLeft = false;
    }

    public void TurnRightStop()
    {
        turningRight = false;
    }

}
