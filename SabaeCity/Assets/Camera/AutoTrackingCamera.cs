using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoTrackingCamera : MonoBehaviour
{
    public GameObject target;
    public float distance = 3F;
    public float relativeHeight = 1F;

    Transform _target;
    Transform renderStreamingCamera;
    bool firstPersonView = false;

    // Start is called before the first frame update
    void Start()
    {
        _target = target.transform;
        renderStreamingCamera = transform.Find("Render Streaming Camera");
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            ToggleCameraPosition();
        }

        Vector3 move = _target.position - transform.position;
        var lookAt = (_target.position - transform.position).normalized;
        lookAt.y = 0;
        var rotation = Quaternion.LookRotation(lookAt);
        transform.rotation = rotation;

        if (move.magnitude > distance)
        {
            move = move.normalized * (move.magnitude - distance);
            Vector3 pos = transform.position + move;
            transform.position = new Vector3(pos.x, _target.position.y + relativeHeight, pos.z);
        }
    }

    public void ToggleCameraPosition()
    {
        firstPersonView = !firstPersonView;

        if (firstPersonView)
        {
            renderStreamingCamera.Translate(0, 0, distance + 0.2F);
        } else
        {
            renderStreamingCamera.Translate(0, 0, -(distance + 0.2F));
        }
    }
}
