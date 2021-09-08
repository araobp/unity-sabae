using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneController : MonoBehaviour
{
    private Camera camera;

    private bool fastMode = true;

    private bool toggleBehindCamera = false;

    const float RX_FAST = 50F;
    const float RY_FAST = 30F;
    const float X_FAST = 60F;
    const float Y_FAST = 30F;

    const float RX_SLOW = 5F;
    const float RY_SLOW = 5F;
    const float X_SLOW = 15F;
    const float Y_SLOW = 6F;

    // Start is called before the first frame update
    void Start()
    {
        camera = transform.Find("Camera").GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        float deltaTime = Time.deltaTime;

        float rightAnalogX = Input.GetAxis("RightAnalogX");
        float rightAnalogY = Input.GetAxis("RightAnalogY");
        float leftAnalogX = Input.GetAxis("LeftAnalogX");
        float leftAnalogY = Input.GetAxis("LeftAnalogY");

        float dPadX = Input.GetAxis("DPadX");
        float dPadY = Input.GetAxis("DPadY");

        if (Input.GetKeyDown(KeyCode.Joystick1Button5))  // RB
        {
            fastMode ^= true;
        }

        if (Input.GetKeyDown(KeyCode.Joystick1Button4))  // LB
        {
            toggleBehindCamera ^= true;
            if (toggleBehindCamera)
            {
                camera.transform.Translate(new Vector3(0F, 0F, -1.3F));
            }
            else
            {
                camera.transform.Translate(new Vector3(0F, 0F, 1.3F));
            }
        }

        if (fastMode)
        {
            transform.Translate(new Vector3(-rightAnalogX * RX_FAST * deltaTime, 0, 0));
            transform.Translate(new Vector3(0, leftAnalogY * Y_FAST * deltaTime, 0));
            transform.Rotate(new Vector3(0, leftAnalogX * X_FAST * deltaTime, 0));
            transform.Translate(new Vector3(0, 0, -rightAnalogY * RY_FAST * deltaTime));
        }
        else
        {
            transform.Translate(new Vector3(-rightAnalogX * RX_SLOW * deltaTime, 0, 0));
            transform.Translate(new Vector3(0, leftAnalogY * Y_SLOW * deltaTime, 0));
            transform.Rotate(new Vector3(0, leftAnalogX * X_SLOW * deltaTime, 0));
            transform.Translate(new Vector3(0, 0, -rightAnalogY * RY_SLOW * deltaTime));
        }

        if (dPadX != 0)
        {
            camera.fieldOfView -= 20F * dPadX * deltaTime;
        }

        if (dPadY != 0)
        {
            camera.transform.Rotate(new Vector3(-20F * dPadY * deltaTime, 0f, 0f));
        }

        if (Input.GetKey(KeyCode.E))
        {
            camera.transform.Rotate(new Vector3(-0.1F, 0f, 0f));
        }
        else if (Input.GetKey(KeyCode.X))
        {
            camera.transform.Rotate(new Vector3(0.1F, 0f, 0f));
        }

        if (Input.GetKey(KeyCode.U))
        {
            camera.fieldOfView -= 0.1F;
        }
        else if (Input.GetKey(KeyCode.N))
        {
            camera.fieldOfView += 0.1F;
        }

        if (Input.GetKey(KeyCode.W))
        { //
            transform.Translate(new Vector3(0, 0.03F, 0));
        }
        else if (Input.GetKey(KeyCode.S))
        { //
            transform.Translate(new Vector3(0, -0.03F, 0));
        }

        if (Input.GetKey(KeyCode.L))
        {
            transform.Translate(new Vector3(-0.1F, 0, 0));
        }
        else if (Input.GetKey(KeyCode.J))
        {
            transform.Translate(new Vector3(+0.1F, 0, 0));
        }

        if (Input.GetKey(KeyCode.I))
        {
            transform.Translate(new Vector3(0, 0, -0.1F));
        }
        else if (Input.GetKey(KeyCode.K))
        {
            transform.Translate(new Vector3(0, 0, +0.1F));
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(new Vector3(0, 0.3F, 0));
        }
        else if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(new Vector3(0, -0.3F, 0));
        }

    }
}