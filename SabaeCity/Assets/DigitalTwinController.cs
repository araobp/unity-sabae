using UnityEngine;

public class DigitalTwinController : MonoBehaviour
{
    public GameObject guide;
    public GameObject bus;
    public GameObject car;

    public GameObject guideCamera;
    public GameObject busCamera;
    public GameObject carCamera;

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

    private void enableCar(bool state)
    {
        car.GetComponent<CarController>().enabled = state;
        carCamera.SetActive(state);
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
                enableCar(false);
                break;
            case SceneSelection.Bus:
                enableGuide(false);
                enableBus(true);
                enableCar(false);
                break;
            case SceneSelection.Car:
                enableGuide(false);
                enableBus(false);
                enableCar(true);
                break;
            default:
                enableGuide(true);
                enableBus(false);
                enableCar(false);
                break;
        }
    }

}
