using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoTrackingCamera : MonoBehaviour
{
    public GameObject target;
    public float distance = 3F;
    public float relativeHeight = 1F;
    public float autoTurnSensitivity = 3F;

    Transform _target;

    // Start is called before the first frame update
    void Start()
    {
        _target = target.transform;
    }

    void Update()
    {
        Vector3 move = _target.position - transform.position;
        if (move.magnitude > distance)
        {
            var lookAt = _target.position - transform.position;
            lookAt.y = 0;
            var rotation = Quaternion.LookRotation(lookAt);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * autoTurnSensitivity);

            move = move.normalized * (move.magnitude - distance);
            Vector3 pos = transform.position + move;
            transform.position = new Vector3(pos.x, _target.position.y + relativeHeight, pos.z);
        }
    }
}
