using UnityEngine;

public enum Actor
{
    GUIDE,
    BUS
}

public class DigitalTwinController : MonoBehaviour
{
    public GameObject guide;
    public GameObject bus;

    public GameObject busCamera;
    public GameObject guideCamera;

    public Canvas canvas;

    BusController m_busController;
    GuideController m_guideController;

    Transform m_originalParent;
    Quaternion m_originalBusCameraRotation;
    Vector3 m_originalRenderStreamingCameraPosition;
    Quaternion m_originalRenderStreamingCameraRotation;

    Actor m_actor;

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
        m_guideController = guide.GetComponent<GuideController>();
        m_busController = bus.GetComponent<BusController>();

        if (Menu.sceneSelection == SceneSelection.Walk)
        {
            m_actor = Actor.GUIDE;
            enableBus(false);
            enableGuide(true);
        } else
        {
            m_actor = Actor.BUS;
            enableBus(true);
            enableGuide(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
    }

}
