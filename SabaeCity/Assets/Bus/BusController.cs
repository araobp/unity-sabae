using System.Collections.Generic;
using UnityEngine;

public class BusController : MonoBehaviour
{
    public List<AxleInfo> axleInfos; // the information about each individual axle

    [SerializeField] float maxMotorTorque = 3000F; // maximum torque the motor can apply to wheel
    [SerializeField] float maxSteeringAngle = 30F; // maximum steer angle the wheel can have

    [SerializeField] GameObject steeringWheel;

    [SerializeField] AudioSource audioSource;

    [SerializeField] float centerOfMass = 1.2F;

    float pedalFreePlay;
    float steeringPrev = 0F;

    Rigidbody rb;

    Animator animator;

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
        rb.centerOfMass = new Vector3(0F, centerOfMass, 0F);
        animator = GetComponentInParent<Animator>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            animator.SetTrigger("OpenMainDoor");
        }
        else if (Input.GetKeyDown(KeyCode.Alpha7))
        {
            animator.SetTrigger("CloseMainDoor");
        }

        if (Input.GetKeyDown(KeyCode.Alpha8))
        {
            animator.SetTrigger("OpenFrontDoor");
        }
        else if (Input.GetKeyDown(KeyCode.Alpha9))
        {
            animator.SetTrigger("CloseFrontDoor");
        }
    }

    void FixedUpdate()
    {
        float axisVertical = Input.GetAxis("Trigger");
        float axisHorizontal = Input.GetAxis("LeftAnalogX");

        float motor = maxMotorTorque * axisVertical;
        float steering = maxSteeringAngle * axisHorizontal;
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
            //Debug.Log(motor);

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
            }
            else
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

            // Engine sound
            audioSource.pitch = rb.velocity.magnitude / 38F + 0.1F;
            float accelVolume = 0F;
            if (motor > pedalFreePlay)
            {
                accelVolume = 0.2F;
            }
            audioSource.volume = (1F + Mathf.Log10(audioSource.pitch)) * 0.6F + accelVolume + 0.2F;
        }
    }
}
