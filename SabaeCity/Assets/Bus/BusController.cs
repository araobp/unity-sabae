using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BusController : MonoBehaviour
{
    public List<AxleInfo> axleInfos; // the information about each individual axle

    public float maxMotorTorque; // maximum torque the motor can apply to wheel
    public float maxSteeringAngle; // maximum steer angle the wheel can have

    public GameObject steeringWheel;

    private float pedalFreePlay;

    [System.Serializable]
    public class AxleInfo
    {
        public WheelCollider leftWheel;
        public WheelCollider rightWheel;
        public bool motor; // is this wheel attached to motor?
        public bool steering; // does this wheel apply steer angle?
    }

    void Start()
    {
        pedalFreePlay = maxMotorTorque * 0.1F;        
    }

    void FixedUpdate()
    {
        float motor = maxMotorTorque * Input.GetAxis("Vertical");
        float steering = maxSteeringAngle * Input.GetAxis("Horizontal");

        foreach (AxleInfo axleInfo in axleInfos)
        {
            if (motor > pedalFreePlay)
            {
                axleInfo.leftWheel.brakeTorque = 0;
                axleInfo.rightWheel.brakeTorque = 0;
            } else
            {
                var brake = Mathf.Abs(motor);
                axleInfo.leftWheel.brakeTorque = brake;
                axleInfo.rightWheel.brakeTorque = brake;
            }
            if (axleInfo.steering)
            {
                axleInfo.leftWheel.steerAngle = steering;
                axleInfo.rightWheel.steerAngle = steering;
                axleInfo.leftWheel.transform.localRotation = Quaternion.Euler(-90, 0, steering);
                axleInfo.rightWheel.transform.localRotation = Quaternion.Euler(-90, 0, steering);

                steeringWheel.transform.localRotation = Quaternion.Euler(-90, 0, steering * 2);
            }
            if (axleInfo.motor)
            {
                if (motor > pedalFreePlay)
                {
                    if (Input.GetKey(KeyCode.R)) {
                        motor = -motor / 2F;
                    }
                    axleInfo.leftWheel.motorTorque = motor;
                    axleInfo.rightWheel.motorTorque = motor;
                } else
                {
                    axleInfo.leftWheel.motorTorque = 0;
                    axleInfo.rightWheel.motorTorque = 0;
                }
            }
        }
    }
}
