using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CanvasManager : MonoBehaviour
{
    GamepadF310 gamepad;

    // Start is called before the first frame update
    void Start()
    {
        gamepad = GameObject.FindWithTag("Gamepad").GetComponent<GamepadF310>();
    }

    void Update()
    {
        if (gamepad.GetKeyDown(GamepadF310KeyCode.BACK)) {
            Close();
        }   
    }

    public void Close()
    {
        SceneManager.LoadScene("Scenes/Menu");
    }

    public void SetMode(SceneSelection selection)
    {
        GameObject textGuide = transform.Find("TextGuide").gameObject;
        GameObject textBus = transform.Find("TextBus").gameObject;
        GameObject rawImageBusMirrorLeft = transform.Find("RawImageBusMirrorLeft").gameObject;
        GameObject rawImageBusMirrorRight = transform.Find("RawImageBusMirrorRight").gameObject;

        switch (selection)
        {
            case SceneSelection.Guide:
                textGuide.SetActive(true);
                textBus.SetActive(false);
                rawImageBusMirrorLeft.SetActive(false);
                rawImageBusMirrorRight.SetActive(false);
                break;
            case SceneSelection.Bus:
                textGuide.SetActive(false);
                textBus.SetActive(true);
                rawImageBusMirrorLeft.SetActive(true);
                rawImageBusMirrorRight.SetActive(true);
                break;
            case SceneSelection.Drone:
                textGuide.SetActive(false);
                textBus.SetActive(true);
                rawImageBusMirrorLeft.SetActive(false);
                rawImageBusMirrorRight.SetActive(false);
                break;
            default:
                break;
        }
    }
}
