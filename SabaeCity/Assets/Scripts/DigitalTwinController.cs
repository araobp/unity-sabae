using UnityEngine;
public class DigitalTwinController : MonoBehaviour
{
    public GameObject guide;
    public GameObject bus;
    public GameObject drone;

    public GameObject guideCamera;
    public GameObject busCamera;
    public GameObject droneCamera;

    public Canvas canvas;

    public SceneSelection m_scene = SceneSelection.Inactive;

    private void EnableGuide(bool state)
    {
        guide.GetComponent<GuideController>().enabled = state;
        guideCamera.SetActive(state);
        if (state)
        {
            canvas.GetComponent<CanvasManager>().SetMode(SceneSelection.Guide);
        }
    }

    private void EnableBus(bool state)
    {
        bus.GetComponent<BusController>().enabled = state;
        busCamera.SetActive(state);
        if (state)
        {
            canvas.GetComponent<CanvasManager>().SetMode(SceneSelection.Bus);
        }
    }

    private void EnableDrone(bool state)
    {
        drone.GetComponent<DroneController>().enabled = state;
        droneCamera.SetActive(state);
        if (state)
        {
            canvas.GetComponent<CanvasManager>().SetMode(SceneSelection.Drone);
        }
    }

    private void Start()
    {
        SceneSelection scene = SceneSelection.Inactive;

        if (m_scene != SceneSelection.Inactive)
        {
            scene = m_scene;
        }
        else
        {
            scene = Menu.sceneSelection;
        }

        switch (scene)
        {
            case SceneSelection.Guide:
                EnableGuide(true);
                EnableBus(false);
                EnableDrone(false);
                break;
            case SceneSelection.Bus:
                EnableGuide(false);
                EnableBus(true);
                EnableDrone(false);
                break;
            case SceneSelection.Drone:
                EnableGuide(false);
                EnableBus(false);
                EnableDrone(true);
                break;
            default:
                EnableGuide(true);
                EnableBus(false);
                EnableDrone(false);
                break;
        }
    }

}
