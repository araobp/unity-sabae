using UnityEngine;

public class TrafficSignal2 : MonoBehaviour, ITrafficSignal
{
    public GameObject signal;

    Material matRed;
    Material matYellow;
    Material matBlue;

    // Start is called before the first frame update
    void Start()
    {
        matRed = signal.transform.Find("Red").GetComponent<MeshRenderer>().materials[0];
        matYellow = signal.transform.Find("Yellow").GetComponent<MeshRenderer>().materials[0];
        matBlue = signal.transform.Find("Blue").GetComponent<MeshRenderer>().materials[0];
    }

    void EnableEmission(Material mat0, Material mat1, Material mat2)
    {
        mat0.EnableKeyword("_EMISSION");
        mat1.DisableKeyword("_EMISSION");
        mat2.DisableKeyword("_EMISSION");
    }

    public void Off()
    {
        matRed.DisableKeyword("_EMISSION");
        matYellow.DisableKeyword("_EMISSION");
        matBlue.DisableKeyword("_EMISSION");
    }

    public void Red()
    {
        EnableEmission(matRed, matYellow, matBlue);
    }

    public void Yellow()
    {
        EnableEmission(matYellow, matBlue, matRed);
    }

    public void Blue()
    {
        EnableEmission(matBlue, matRed, matYellow);
    }
}
