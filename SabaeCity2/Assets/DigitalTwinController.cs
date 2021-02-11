using System.Collections.Generic;
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

    public Canvas busHelp;
    public Canvas guideHelp;

    BusController m_busController;
    GuideController m_guideController;

    Transform m_originalParent;
    Quaternion m_originalBusCameraRotation;
    Vector3 m_originalRenderStreamingCameraPosition;
    Quaternion m_originalRenderStreamingCameraRotation;

    Actor m_actor;

    private void enableBus(bool state)
    {
        bus.GetComponent<BusController>().enabled = state;
        busCamera.SetActive(state);
        busHelp.enabled = state;
    }

    private void enableGuide(bool state)
    {
        guide.GetComponent<GuideController>().enabled = state;
        guideCamera.SetActive(state);
        guideHelp.enabled = state;
    }

    private void Start()
    {
        m_guideController = guide.GetComponent<GuideController>();
        m_busController = bus.GetComponent<BusController>();

        m_actor = Actor.GUIDE;
        enableBus(false);
        enableGuide(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K) || InputSubscriber.GetKeyDown(KeyCode.K))
        {
            ToggleActor();
        }        
    }

    void ToggleActor()
    {
        if (m_actor == Actor.GUIDE)
        {
            m_actor = Actor.BUS;
            enableBus(true);
            enableGuide(false);
        }
        else
        {
            m_actor = Actor.GUIDE;
            enableBus(false);
            enableGuide(true);
        }
    }

}
