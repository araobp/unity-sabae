using UnityEngine;

public class PedestrianTrafficSignal : MonoBehaviour
{
    public GameObject signal;

    Material matRed;
    Material matBlue;

    // Start is called before the first frame update
    void Start()
    {
        Material[] materials = signal.GetComponent<MeshRenderer>().materials;
        for (int i = 0; i < materials.Length; i++)
        {
            if (materials[i].name == "TrafficSignalRed (Instance)")
            {
                matRed = materials[i];
                matRed.DisableKeyword("_EMISSION");
            }
            else if (materials[i].name == "TrafficSignalBlue (Instance)")
            {
                matBlue = materials[i];
                matBlue.DisableKeyword("_EMISSION");
            }
        }
        signal.GetComponent<MeshRenderer>().materials = materials;
    }

    void EnableEmission(Material mat0, Material mat1)
    {
        mat0.EnableKeyword("_EMISSION");
        mat1.DisableKeyword("_EMISSION");
    }

    public void Off()
    {
        matBlue.DisableKeyword("_EMISSION");
    }

    public void Red()
    {
        EnableEmission(matRed, matBlue);
    }

    public void Blue()
    {
        EnableEmission(matBlue, matRed);
    }
}
