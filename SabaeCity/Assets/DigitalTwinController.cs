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

    Mode mode;

    private void Start()
    {
        mode = Mode.WALKER;
        walker.GetComponent<WalkerController>().enabled = true;
        walkerCamera.SetActive(true);
        bus.GetComponent<BusController>().enabled = false;
        busCamera.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            if (mode == Mode.WALKER)
            {
                mode = Mode.BUS;
                walker.GetComponent<WalkerController>().enabled = false;
                walkerCamera.SetActive(false);
                bus.GetComponent<BusController>().enabled = true;
                busCamera.SetActive(true);
            }
            else
            {
                mode = Mode.WALKER;
                walker.GetComponent<WalkerController>().enabled = true;
                walkerCamera.SetActive(true);
                bus.GetComponent<BusController>().enabled = false;
                busCamera.SetActive(false);
            }
        }        
    }
}
