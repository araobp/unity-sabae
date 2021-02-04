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
    private float steeringPrev = 0F;

    private Rigidbody rb;

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
        pedalFreePlay = maxMotorTorque * 0.03F;
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        float motor = maxMotorTorque * Input.GetAxis("Vertical");
        float steering = maxSteeringAngle * Input.GetAxis("Horizontal");
        if (steering == 0 || steering > 0 && (steering < steeringPrev) || steering < 0 && (steering > steeringPrev))
        {
            if (Mathf.Abs(steeringPrev) > 0.5F)
            {
                if (steeringPrev > 0) steeringPrev -= 0.5F;
                else steeringPrev += 0.5F;
            } else
            {
                steeringPrev = 0F;
            }
            steering = steeringPrev;
        } else
        {
            if (steering > 0) steeringPrev += 0.5F;
            else steeringPrev -= 0.5F;
            steering = steeringPrev;
        }

        foreach (AxleInfo axleInfo in axleInfos)
        {
            // Brake
            if (motor > pedalFreePlay)
            {
                axleInfo.leftWheel.brakeTorque = 0;
                axleInfo.rightWheel.brakeTorque = 0;
            } else if (motor < -pedalFreePlay)
            {
                var brake = Mathf.Abs(motor) * 100F;
                axleInfo.leftWheel.brakeTorque = brake;
                axleInfo.rightWheel.brakeTorque = brake;
            } else
            {
                float engineBrake = rb.velocity.magnitude * maxMotorTorque * 0.02F;
                axleInfo.leftWheel.brakeTorque = engineBrake;
                axleInfo.rightWheel.brakeTorque = engineBrake;
            }

            // Steering
            if (axleInfo.steering)
            {
                axleInfo.leftWheel.steerAngle = steering;
                axleInfo.rightWheel.steerAngle = steering;
                axleInfo.leftWheel.transform.localRotation = Quaternion.Euler(-90, 0, steering);
                axleInfo.rightWheel.transform.localRotation = Quaternion.Euler(-90, 0, steering);

                steeringWheel.transform.localRotation = Quaternion.Euler(-90, 0, steering * 2);
            }

            // Motor
            if (axleInfo.motor)
            {
                if (motor > pedalFreePlay)
                {
                    if (Input.GetKey(KeyCode.R)) {
                        motor = -motor / 2F;
                    }
                    axleInfo.leftWheel.motorTorque = motor;
                    axleInfo.rightWheel.motorTorque = motor;
                }
            }
        }
    }
}
