using UnityEngine;

public class DigitalTwinController : MonoBehaviour
{
    public GameObject guide;
    public GameObject bus;

    public GameObject guideCamera;
    public GameObject busCamera;

    public Canvas canvas;

    public SceneSelection m_scene = SceneSelection.Inactive; 

    private void enableGuide(bool state)
    {
        guide.GetComponent<GuideController>().enabled = state;
        guideCamera.SetActive(state);
        if (state)
        {
            canvas.GetComponent<CanvasManager>().SetMode(SceneSelection.Guide);
        }
    }

    private void enableBus(bool state)
    {
        bus.GetComponent<BusController>().enabled = state;
        busCamera.SetActive(state);
        if (state)
        {
            canvas.GetComponent<CanvasManager>().SetMode(SceneSelection.Bus);
        }
    }

    private void Start()
    {
        SceneSelection scene = SceneSelection.Inactive;
        
        if (m_scene != SceneSelection.Inactive)
        {
            scene = m_scene;
        } else
        {
            scene = Menu.sceneSelection;
        }

        switch (scene) {
            case SceneSelection.Guide:
                enableGuide(true);
                enableBus(false);
                break;
            case SceneSelection.Bus:
                enableGuide(false);
                enableBus(true);
                break;
            case SceneSelection.Drone:
                enableGuide(false);
                enableBus(false);
                break;
            default:
                enableGuide(true);
                enableBus(false);
                break;
        }
    }

}
