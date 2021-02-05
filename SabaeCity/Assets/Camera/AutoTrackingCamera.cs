using UnityEngine;

public class AutoTrackingCamera : MonoBehaviour
{
    public GameObject renderStreamingCamera;
    public GameObject target;
    public float distance = 3F;
    public float relativeHeight = 1F;

    Transform m_target;
    Transform m_renderStreamingCamera;
    bool firstPersonView = false;

    // Start is called before the first frame update
    void Start()
    {
        m_target = target.transform;
        m_renderStreamingCamera = renderStreamingCamera.transform;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            ToggleCameraPosition();
        }

        Vector3 move = m_target.position - transform.position;
        var lookAt = move.normalized;
        lookAt.y = 0;
        var rotation = Quaternion.LookRotation(lookAt);
        transform.rotation = rotation;

        if (move.magnitude > distance)
        {
            move = move.normalized * (move.magnitude - distance);
            Vector3 pos = transform.position + move;
            transform.position = new Vector3(pos.x, m_target.position.y + relativeHeight, pos.z);
        }
    }

    public void ToggleCameraPosition()
    {
        firstPersonView = !firstPersonView;

        if (firstPersonView)
        {
            m_renderStreamingCamera.localPosition = new Vector3(0, 0, distance + 0.05F);
        }
        else
        {
            m_renderStreamingCamera.localPosition = Vector3.zero;
        }
    }
}
