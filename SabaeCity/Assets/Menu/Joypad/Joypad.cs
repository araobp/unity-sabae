using System.Collections.Generic;
using UnityEngine;

public delegate void JoypadEventHandler(string evt);

public class Joypad : MonoBehaviour
{
    static int DECIMATION = 2;

    List<JoypadEventHandler> handlers = new List<JoypadEventHandler>();
    public void AddHandler(JoypadEventHandler handler)
    {
        handlers.Add(handler);
        Debug.Log(handler);
    }

    void Start()
    {
        //handlers = new List<JoypadEventHandler>();
    }

    int decimation = DECIMATION;

    void Fire(string evt, bool priority = true)
    {
        if (priority || decimation == 0)
        {
            foreach (var h in handlers)
            {
                h(evt);
            }
            if (decimation == 0)
            {
                decimation = DECIMATION;
            }
        }
        else
        {
            decimation--;
        }
    }

    float prevRightAnalogX;
    float prevRightAnalogY;
    float prevLeftAnalogX;
    float prevLeftAnalogY;
    float prevDPadX;
    float prevDPadY;
    float prevTrigger;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Joystick1Button0))
        {
            Fire("A");
        }
        else if (Input.GetKeyDown(KeyCode.Joystick1Button1))
        {
            Fire("B");
        }
        else if (Input.GetKeyDown(KeyCode.Joystick1Button2))
        {
            Fire("X");
        }
        else if (Input.GetKeyDown(KeyCode.Joystick1Button3))
        {
            Fire("Y");
        }
        else if (Input.GetKeyDown(KeyCode.Joystick1Button7))
        {
            Fire("START");
        }
        else if (Input.GetKeyDown(KeyCode.Joystick1Button6))
        {
            Fire("BACK");
        }
        else if (Input.GetKeyDown(KeyCode.Joystick1Button5))
        {
            Fire("TR");
        }
        else if (Input.GetKeyDown(KeyCode.Joystick1Button4))
        {
            Fire("TL");
        }
        else if (Input.GetKeyDown(KeyCode.Joystick1Button8))
        {
            Fire("THUMBL");
        }
        else if (Input.GetKeyDown(KeyCode.Joystick1Button9))
        {
            Fire("THUMBR");
        }

        float rightAnalogX = (int)(Input.GetAxis("RightAnalogX") * 128);
        float rightAnalogY = (int)(Input.GetAxis("RightAnalogY") * 128);
        float leftAnalogX = (int)(Input.GetAxis("LeftAnalogX") * 128);
        float leftAnalogY = (int)(Input.GetAxis("LeftAnalogY") * 128);
        float dPadX = Input.GetAxis("DPadX");
        float dPadY = Input.GetAxis("DPadY");
        float trigger = Input.GetAxis("Trigger");

        if (rightAnalogX == 0)
        {
            if (prevRightAnalogX != 0) Fire("RX:0");
        }
        else
        {
            Fire($"RX:{rightAnalogX}", false);
        }

        if (rightAnalogY == 0)
        {
            if (prevRightAnalogY != 0) Fire("RY:0");
        }
        else
        {
            Fire($"RY:{rightAnalogY}", false);
        }

        if (leftAnalogX == 0)
        {
            if (prevLeftAnalogX != 0) Fire("X:0");
        }
        else
        {
            Fire($"X:{leftAnalogX}", false);
        }

        if (leftAnalogY == 0)
        {
            if (prevLeftAnalogY != 0) Fire("Y:0");
        }
        else
        {
            Fire($"Y:{leftAnalogY}", false);
        }

        if (dPadX == 0)
        {
            if (prevDPadX != 0) Fire("HX:0");
        }
        else
        {
            if (prevDPadX == 0) Fire($"HX:{dPadX}");
        }

        if (dPadY == 0)
        {
            if (prevDPadY != 0) Fire("HY:0");
        }
        else
        {
            if (prevDPadY == 0) Fire($"HY:{dPadY}");
        }

        if (trigger == 0)
        {
            if (prevTrigger != 0) Fire("TL:0");
        }
        else
        {
            Fire($"TL:{trigger}", false);
        }

        prevRightAnalogX = rightAnalogX;
        prevRightAnalogY = rightAnalogY;
        prevLeftAnalogX = leftAnalogX;
        prevLeftAnalogY = leftAnalogY;
        prevDPadX = dPadX;
        prevDPadY = dPadY;
        prevTrigger = trigger;
    }
}