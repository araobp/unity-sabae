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

    void Walk()
    {
        animator.SetTrigger("Walk");
    }

    void Stop()
    {
        animator.SetTrigger("Stop");
    }

    void TurnLeft()
    {
        turningLeft = true;
    }
    
    void TurnRight()
    {
        turningRight = true;
    }

    void TurnLeftStop()
    {
        turningLeft = false;
    }

    void TurnRightStop()
    {
        turningRight = false;
    }

    /***** Buttons *****/

    // 1
    public void ButtonAClick1()
    {

    }

    // 5
    public void ButtonATouchStart5()
    {

    }

    // 6
    public void ButtonATouchEnd6()
    {

    }

    // 2
    public void ButtonBClick2()
    {

    }

    // 7
    public void ButtonBTouchStart7()
    {

    }

    // 8
    public void ButtonBTouchEnd8()
    {

    }

    // 3
    public void ButtonXClick3()
    {

    }

    // 9
    public void ButtonXTouchStart9()
    {

    }

    // 10
    public void ButtonXTouchEnd10()
    {

    }

    // 4
    public void ButtonYClick4()
    {

    }

    // 11
    public void ButtonYTouchStart11()
    {

    }

    // 12
    public void ButtonYTouchEnd12()
    {

    }

    /***** Arrow Keys *****/

    // 13
    public void ArrowDownClick13()
    {

    }

    // 17
    public void ArrowDownTouchStart17()
    {

    }

    // 18
    public void ArrowDownTouchEnd18()
    {

    }

    // 14
    public void ArrowRightClick14()
    {

    }

    // 19
    public void ArrowRightTouchStart19()
    {
        TurnRight();
    }

    // 20
    public void ArrowRightTouchEnd20()
    {
        TurnRightStop();
    }

    // 15
    public void ArrowLeftClick15()
    {

    }

    // 21
    public void ArrowLeftTouchStart21()
    {
        TurnLeft();
    }

    // 22
    public void ArrowLeftTouchEnd22()
    {
        TurnLeftStop();
    }

    // 16
    public void ArrowUpClick16()
    {

    }

    // 23
    public void ArrowUpClickTouchStart23()
    {
        Walk();
    }

    // 24
    public void ArrowUpClickTouchEnd24()
    {
        Stop();
    }

}
