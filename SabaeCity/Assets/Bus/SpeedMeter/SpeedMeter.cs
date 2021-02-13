using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedMeter : MonoBehaviour
{
    public Rigidbody bus;

    Transform meterAxis;

    // Start is called before the first frame update
    void Start()
    {
        meterAxis = transform.Find("Armature/MeterAxis");
    }

    // Update is called once per frame
    void Update()
    {
        var localEulerAngles = meterAxis.localEulerAngles;
        meterAxis.localEulerAngles = new Vector3(localEulerAngles.x, -bus.velocity.magnitude / 1000F * 3600F / 120F * 180F - 180F, localEulerAngles.z);
    }
}
