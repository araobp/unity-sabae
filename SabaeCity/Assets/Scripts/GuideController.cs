using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuideController : MonoBehaviour
{
    public GameObject spots;
    public float rotationSpeed = 2F;

    Transform m_walker;
    Transform m_cameraCrew;

    Vector3 m_originalWalkerPos;
    Vector3 m_originalCameraCrewPos;

    Animator m_animator;
    bool m_turningLeft = false;
    bool m_turningRight = false;

    // Sightseeing spots
    Transform m_spot1;
    Transform m_spot2;
    Transform m_spot3;
    Transform m_spot4;
    Transform m_spot5;
    List<Transform> m_spots = new List<Transform>();
    int idx = 0;

    // Start is called before the first frame update
    void Start()
    {
        m_walker = transform.Find("Walker");
        m_cameraCrew = transform.Find("CameraCrew");
        m_originalWalkerPos = m_walker.transform.localPosition;
        m_originalCameraCrewPos = m_cameraCrew.transform.localPosition;

        m_animator = m_walker.GetComponent<Animator>();

        // Sightseeing spots
        m_spot1 = spots.transform.Find("spot_sign_1");
        m_spot2 = spots.transform.Find("spot_sign_2");
        m_spot3 = spots.transform.Find("spot_sign_3");
        m_spot4 = spots.transform.Find("spot_sign_4");
        m_spot5 = spots.transform.Find("spot_sign_5");
        m_spots.Add(m_spot1);
        m_spots.Add(m_spot2);
        m_spots.Add(m_spot3);
        m_spots.Add(m_spot4);
        m_spots.Add(m_spot5);

    }

    void Update()
    {
        float deltaTime = Time.deltaTime;

        // Control walker

        float leftAnalogX = Input.GetAxis("LeftAnalogX");
        float rightAnalogY = Input.GetAxis("RightAnalogY");

        if (leftAnalogX <= -0.1F)
        {
            TurnLeft();
        }
        else if (leftAnalogX >= 0.1F)
        {
            TurnRight();
        }
        else if (leftAnalogX < 0.1F && leftAnalogX > -0.1F)
        {
            TurnStop();
        }

        if (rightAnalogY >= 0.1F)
        {
            Walk();
        }
        else if (rightAnalogY < 0.1F)
        {
            Stop();
        }

        if (m_turningLeft)
        {
            m_walker.Rotate(0, -rotationSpeed * deltaTime * 50F, 0);
        }
        if (m_turningRight)
        {
            m_walker.Rotate(0, rotationSpeed * deltaTime * 50F, 0);
        }

        // Sightseeing spots

        if (Input.GetKeyDown(KeyCode.Joystick1Button4))  // LB
        {
            NextSpot();
        }

    }

    bool IsStateName(string name)
    {
        return m_animator.GetCurrentAnimatorStateInfo(0).IsName(name);
    }

    //----- Walker control -----

    public void Walk()
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

    public void Stop()
    {
        if (IsStateName("Walking"))
        {
            m_animator.SetTrigger("Stop");
            m_turningRight = false;
            m_turningLeft = false;
        }
    }

    public void TurnLeft()
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

    public void TurnRight()
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

    public void TurnStop()
    {
        if (IsStateName("Walking"))
        {
            m_turningLeft = false;
            m_turningRight = false;
        }
    }

    //----- Sightseeing spots -----

    void RelocateTo(Transform spot)
    {
        m_walker.localPosition = m_originalWalkerPos;
        m_cameraCrew.localPosition = m_originalCameraCrewPos;

        float direction = spot.eulerAngles.y + 180F;
        transform.eulerAngles = new Vector3(0F, direction, 0F);
        Vector3 newPos = spot.position - spot.right.normalized * 1.7F;
        transform.position = new Vector3(newPos.x, newPos.y + 0.8F, newPos.z);
    }

    public void NextSpot()
    {
        idx++;
        if (idx > 4) idx = 0;
        RelocateTo(m_spots[idx]);
    }
}
