using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkerController : MonoBehaviour
{
    public float rotationSpeed = 2F;

    Animator m_animator;
    bool m_turningLeft = false;
    bool m_turningRight = false;

    // Start is called before the first frame update
    void Start()
    {
        m_animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            TurnLeft();
        }
        else if (Input.GetKeyUp(KeyCode.A))
        {
            TurnLeftStop();
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            TurnRight();
        }
        else if (Input.GetKeyUp(KeyCode.D))
        {
            TurnRightStop();
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            Walk();
        }
        else if (Input.GetKeyUp(KeyCode.W))
        {
            Stop();
        }

        if (m_turningLeft)
        {
            transform.Rotate(0, -rotationSpeed, 0);
        }
        if (m_turningRight)
        {
            transform.Rotate(0, rotationSpeed, 0);
        }
    }

    bool IsStateName(string name)
    {
        return m_animator.GetCurrentAnimatorStateInfo(0).IsName(name);
    }

    void Walk()
    {
        if (!IsStateName("Walking"))
        {
            m_animator.SetTrigger("Walk");
            if (m_turningLeft)
            {
                m_turningLeft = false;
            }
            if (m_turningRight)
            {
                m_turningRight = false;
            }
        }

    }

    void Stop()
    {
        if (IsStateName("Walking"))
        {
            m_animator.SetTrigger("Stop");
            m_turningRight = false;
            m_turningLeft = false;
        }
    }

    void TurnLeft()
    {
        if (IsStateName("Walking"))
        {
            m_turningLeft = true;
        }
        else
        {
            m_animator.SetTrigger("TurnLeft");
        }
    }

    void TurnRight()
    {
        if (IsStateName("Walking"))
        {
            m_turningRight = true;
        }
        else
        {
            m_animator.SetTrigger("TurnRight");
        }
    }

    void TurnLeftStop()
    {
        if (IsStateName("Walking"))
        {
            m_turningLeft = false;
        }
    }

    void TurnRightStop()
    {
        if (IsStateName("Walking"))
        {
            m_turningRight = false;
        }
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
        Walk();
    }

    // 12
    public void ButtonYTouchEnd12()
    {
        Stop();
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
