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

    public GameObject guideHelp;
    public GameObject busHelp;

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
        busHelp.SetActive(state);
    }

    private void enableGuide(bool state)
    {
        guide.GetComponent<GuideController>().enabled = state;
        guideCamera.SetActive(state);
        guideHelp.SetActive(state);
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
        if (Input.GetKeyDown(KeyCode.K))
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

    /***** Button input events from HTML5 buttons on a remote browser *****/

    // 1
    public void ButtonAClick1()
    {
        switch (m_actor)
        {
            case Actor.GUIDE:
                m_guideController.NextSpot();
                break;
            case Actor.BUS:
                break;
        }
    }

    // 5
    public void ButtonATouchStart5()
    {

    }

    // 6
    public void ButtonATouchEnd6()
    {

    }

    // 2
    public void ButtonBClick2()
    {
        ToggleActor();
    }

    // 7
    public void ButtonBTouchStart7()
    {

    }

    // 8
    public void ButtonBTouchEnd8()
    {

    }

    // 3
    public void ButtonXClick3()
    {

    }

    // 9
    public void ButtonXTouchStart9()
    {

    }

    // 10
    public void ButtonXTouchEnd10()
    {

    }

    // 4
    public void ButtonYClick4()
    {

    }

    // 11
    public void ButtonYTouchStart11()
    {
        switch (m_actor)
        {
            case Actor.GUIDE:
                m_guideController.Walk();
                break;
            case Actor.BUS:
                break;
        }
    }

    // 12
    public void ButtonYTouchEnd12()
    {
        switch (m_actor)
        {
            case Actor.GUIDE:
                m_guideController.Stop();
                break;
            case Actor.BUS:
                break;
        }
    }

    /***** Arrow Keys *****/

    // 13
    public void ArrowDownClick13()
    {

    }

    // 17
    public void ArrowDownTouchStart17()
    {

    }

    // 18
    public void ArrowDownTouchEnd18()
    {

    }

    // 14
    public void ArrowRightClick14()
    {

    }

    // 19
    public void ArrowRightTouchStart19()
    {
        switch (m_actor)
        {
            case Actor.GUIDE:
                m_guideController.TurnRight();
                break;
            case Actor.BUS:
                break;
        }
    }

    // 20
    public void ArrowRightTouchEnd20()
    {
        switch (m_actor)
        {
            case Actor.GUIDE:
                m_guideController.TurnRightStop();
                break;
            case Actor.BUS:
                break;
        }
    }

    // 15
    public void ArrowLeftClick15()
    {

    }

    // 21
    public void ArrowLeftTouchStart21()
    {
        switch (m_actor)
        {
            case Actor.GUIDE:
                m_guideController.TurnLeft();
                break;
            case Actor.BUS:
                break;
        }
    }

    // 22
    public void ArrowLeftTouchEnd22()
    {
        switch (m_actor)
        {
            case Actor.GUIDE:
                m_guideController.TurnLeftStop();
                break;
            case Actor.BUS:
                break;
        }
    }

    // 16
    public void ArrowUpClick16()
    {

    }

    // 23
    public void ArrowUpClickTouchStart23()
    {
        switch (m_actor)
        {
            case Actor.GUIDE:
                m_guideController.Walk();
                break;
            case Actor.BUS:
                break;
        }
    }

    // 24
    public void ArrowUpClickTouchEnd24()
    {
        switch (m_actor)
        {
            case Actor.GUIDE:
                m_guideController.Stop();
                break;
            case Actor.BUS:
                break;
        }
    }

}
