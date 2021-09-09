using UnityEngine;
using UnityEngine.SceneManagement;

public class CanvasManager : MonoBehaviour
{
    void Update()
    {
        // Logicool Gamepad F310 back button
        if (Input.GetKeyDown(KeyCode.Joystick1Button6))
        {
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
        GameObject textDrone = transform.Find("TextDrone").gameObject;
        GameObject rawImageBusMirrorLeft = transform.Find("RawImageBusMirrorLeft").gameObject;
        GameObject rawImageBusMirrorRight = transform.Find("RawImageBusMirrorRight").gameObject;

        switch (selection)
        {
            case SceneSelection.Guide:
                textGuide.SetActive(true);
                textBus.SetActive(false);
                textDrone.SetActive(false);
                rawImageBusMirrorLeft.SetActive(false);
                rawImageBusMirrorRight.SetActive(false);
                break;
            case SceneSelection.Bus:
                textGuide.SetActive(false);
                textBus.SetActive(true);
                textDrone.SetActive(false);
                rawImageBusMirrorLeft.SetActive(true);
                rawImageBusMirrorRight.SetActive(true);
                break;
            case SceneSelection.Drone:
                textGuide.SetActive(false);
                textBus.SetActive(false);
                textDrone.SetActive(true);
                rawImageBusMirrorLeft.SetActive(false);
                rawImageBusMirrorRight.SetActive(false);
                break;
            default:
                break;
        }
    }
}
