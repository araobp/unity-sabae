using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Mode
{
    WALKER,
    BUS
}

public class DigitalTwinController : MonoBehaviour
{
    public GameObject walker;
    public GameObject bus;

    public GameObject walkerCamera;
    public GameObject busCamera;

    public GameObject walkerHelp;
    public GameObject busHelp;

    Mode mode;

    private void enableBus(bool state)
    {
        bus.GetComponent<BusController>().enabled = state;
        busCamera.SetActive(state);
        busHelp.SetActive(state);
    }

    private void enableWalker(bool state)
    {
        walker.GetComponent<WalkerController>().enabled = state;
        walkerCamera.SetActive(state);
        walkerHelp.SetActive(state);
    }

    private void Start()
    {
        mode = Mode.BUS;
        enableBus(true);
        enableWalker(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            if (mode == Mode.WALKER)
            {
                mode = Mode.BUS;
                enableBus(true);
                enableWalker(false);
            }
            else
            {
                mode = Mode.WALKER;
                enableBus(false);
                enableWalker(true);
            }
        }        
    }
}
