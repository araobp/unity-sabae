using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrafficSignal : MonoBehaviour
{
    public GameObject red;
    public GameObject yellow;
    public GameObject blue;

    Material matRed;
    Material matYellow;
    Material matBlue;

    // Start is called before the first frame update
    void Start()
    {
        matRed = Resources.Load("Materials/TrafficSignalRed") as Material;
        matYellow = Resources.Load("Materials/TrafficSignalYellow") as Material;
        matBlue = Resources.Load("Materials/TrafficSignalBlue") as Material;

        // Create clones of the materials
        matRed = Instantiate(matRed);
        matYellow = Instantiate(matYellow);
        matBlue = Instantiate(matBlue);

        matRed.DisableKeyword("_EMISSION");
        matYellow.DisableKeyword("_EMISSION");
        matBlue.DisableKeyword("_EMISSION");

        Material[] materialsRed = red.GetComponent<MeshRenderer>().materials;
        materialsRed[1] = matRed;
        red.GetComponent<MeshRenderer>().materials = materialsRed;

        Material[] materialsYellow = yellow.GetComponent<MeshRenderer>().materials;
        materialsYellow[1] = matYellow;
        yellow.GetComponent<MeshRenderer>().materials = materialsYellow;

        Material[] materialsBlue = blue.GetComponent<MeshRenderer>().materials;
        materialsBlue[1] = matBlue;
        blue.GetComponent<MeshRenderer>().materials = materialsBlue;
    }

    void EnableEmission(Material mat0, Material mat1, Material mat2)
    {
        mat0.EnableKeyword("_EMISSION");
        mat1.DisableKeyword("_EMISSION");
        mat2.DisableKeyword("_EMISSION");
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
