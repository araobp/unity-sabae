using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spots : MonoBehaviour
{
    public GameObject guide;

    Transform m_spot1;
    Transform m_spot2;
    Transform m_spot3;
    Transform m_spot4;
    Transform m_spot5;

    List<Transform> m_spots = new List<Transform>();
    int idx = 0;

    // Start is called before the first frame update
    void Start()
    {
        m_spot1 = transform.Find("spot_sign_1");
        m_spot2 = transform.Find("spot_sign_2");
        m_spot3 = transform.Find("spot_sign_3");
        m_spot4 = transform.Find("spot_sign_4");
        m_spot5 = transform.Find("spot_sign_5");

        m_spots.Add(m_spot1);
        m_spots.Add(m_spot2);
        m_spots.Add(m_spot3);
        m_spots.Add(m_spot4);
        m_spots.Add(m_spot5);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Spot1();
        } else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Spot2();
        } else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            Spot3();
        } else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            Spot4();
        } else if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            Spot5();
        } else if (Input.GetKeyDown(KeyCode.N))
        {
            NextSpot();
        }
    }

    void RelocateTo(Transform spot)
    {
        guide.GetComponent<GuideController>().ToOriginalLocalPosition();

        float direction = spot.eulerAngles.y + 180F;
        guide.transform.eulerAngles = new Vector3(0F, direction, 0F);
        Vector3 newPos = spot.position - spot.right.normalized * 1.7F;
        guide.transform.position = new Vector3(newPos.x, newPos.y + 0.8F, newPos.z);
    }

    public void NextSpot()
    {
        idx++;
        if (idx > 4) idx = 0;
        RelocateTo(m_spots[idx]);
    }

    public void Spot1()
    {
        RelocateTo(m_spot1);
        idx = 0;
    }

    public void Spot2()
    {
        RelocateTo(m_spot2);
        idx = 1;
    }

    public void Spot3()
    {
        RelocateTo(m_spot3);
        idx = 2;
    }

    public void Spot4()
    {
        RelocateTo(m_spot4);
        idx = 3;
    }

    public void Spot5()
    {
        RelocateTo(m_spot5);
        idx = 4;
    }

}
