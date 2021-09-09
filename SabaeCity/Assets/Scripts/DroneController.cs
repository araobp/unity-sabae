using UnityEngine;

public class DroneController : MonoBehaviour
{
    const float RX_FAST = 50F;
    const float RY_FAST = 30F;
    const float X_FAST = 60F;
    const float Y_FAST = 30F;

    const float RX_SLOW = 5F;
    const float RY_SLOW = 5F;
    const float X_SLOW = 25F;
    const float Y_SLOW = 6F;

    private Camera m_Camera;
    private bool m_FastMode = true;
    private bool m_ToggleBehindCamera = false;

    // Start is called before the first frame update
    void Start()
    {
        m_Camera = transform.Find("Camera").GetComponent<Camera>();
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
            m_FastMode ^= true;
        }

        if (Input.GetKeyDown(KeyCode.Joystick1Button4))  // LB
        {
            m_ToggleBehindCamera ^= true;
            if (m_ToggleBehindCamera)
            {
                m_Camera.transform.Translate(new Vector3(0F, 0F, -1.3F));
            }
            else
            {
                m_Camera.transform.Translate(new Vector3(0F, 0F, 1.3F));
            }
        }

        if (m_FastMode)
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
            m_Camera.fieldOfView -= 20F * dPadX * deltaTime;
        }

        if (dPadY != 0)
        {
            m_Camera.transform.Rotate(new Vector3(-20F * dPadY * deltaTime, 0f, 0f));
        }
    }
}