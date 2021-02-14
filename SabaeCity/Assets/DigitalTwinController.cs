using UnityEngine;

public class DigitalTwinController : MonoBehaviour
{
    public GameObject guide;
    public GameObject bus;

    public GameObject busCamera;
    public GameObject guideCamera;

    public Canvas canvas;

    private void enableGuide(bool state)
    {
        guide.GetComponent<GuideController>().enabled = state;
        guideCamera.SetActive(state);
        if (state)
        {
            canvas.GetComponent<CanvasManager>().SetMode(SceneSelection.Walk);
        }
    }

    private void enableBus(bool state)
    {
        bus.GetComponent<BusController>().enabled = state;
        busCamera.SetActive(state);
        if (state)
        {
            canvas.GetComponent<CanvasManager>().SetMode(SceneSelection.Drive);
        }
    }

    private void Start()
    {
        if (Menu.sceneSelection == SceneSelection.Walk)
        {
            enableBus(false);
            enableGuide(true);
        } else
        {
            enableBus(true);
            enableGuide(false);
        }
    }

}
