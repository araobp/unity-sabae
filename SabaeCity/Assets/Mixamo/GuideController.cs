using UnityEngine;

public class GuideController : MonoBehaviour
{
    public GameObject walker;
    public GameObject cameraCrew;

    Vector3 walkerOriginalPos;
    Vector3 cameraCrewOriginalPos;

    // Start is called before the first frame update
    void Start()
    {
        walkerOriginalPos = walker.transform.localPosition;
        cameraCrewOriginalPos = cameraCrew.transform.localPosition;
    }

    public void ToOriginalLocalPosition()
    {
        walker.transform.localPosition = walkerOriginalPos;
        cameraCrew.transform.localPosition = cameraCrewOriginalPos;
    }
}
