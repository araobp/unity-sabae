using UnityEngine;

public enum GamepadF310KeyCode
{
    A, B, X, Y, START, BACK, RIGHT_BUTTON, LEFT_BUTTON
}

public class GamepadF310 : MonoBehaviour
{
    public bool GetKeyDown(GamepadF310KeyCode button)
    {
        bool value;
        switch (button)
        {
            case GamepadF310KeyCode.A:
                value = Input.GetKeyDown(KeyCode.Joystick1Button0);
                break;
            case GamepadF310KeyCode.B:
                value = Input.GetKeyDown(KeyCode.Joystick1Button1);
                break;
            case GamepadF310KeyCode.X:
                value = Input.GetKeyDown(KeyCode.Joystick1Button2);
                break;
            case GamepadF310KeyCode.Y:
                value = Input.GetKeyDown(KeyCode.Joystick1Button3);
                break;
            case GamepadF310KeyCode.START:
                value = Input.GetKeyDown(KeyCode.Joystick1Button7);
                break;
            case GamepadF310KeyCode.BACK:
                value = Input.GetKeyDown(KeyCode.Joystick1Button6);
                break;
            case GamepadF310KeyCode.RIGHT_BUTTON:
                value = Input.GetKeyDown(KeyCode.Joystick1Button5);
                break;
            case GamepadF310KeyCode.LEFT_BUTTON:
                value = Input.GetKeyDown(KeyCode.Joystick1Button4);
                break;
            default:
                value = false;
                break;
        }
        return value;
    }
}