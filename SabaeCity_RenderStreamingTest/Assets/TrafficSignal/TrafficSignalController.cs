using System;
using System.Collections;
using System.Threading.Tasks;
using UnityEngine;

public class TrafficSignalController : MonoBehaviour
{
    public float duration = 20F;

    ITrafficSignal[] a = { new TrafficSignalNull() }; 
    ITrafficSignal[] b = { new TrafficSignalNull() };
    ITrafficSignal[] ap = { new TrafficSignalNull() };
    ITrafficSignal[] bp = { new TrafficSignalNull() };

    // Start is called before the first frame update
    void Start()
    {
        Transform A = transform.Find("A");
        if (A != null) {
            a = A.GetComponents<TrafficSignal2>();
        }

        Transform B = transform.Find("B");
        if (B != null)
        {
            b = B.GetComponents<TrafficSignal2>();
        }

        Transform AP = transform.Find("AP");
        if (AP != null)
        {
            ap = AP.GetComponents<PedestrianTrafficSignal>();
        }

        Transform BP = transform.Find("BP");
        if (BP != null)
        {
            bp = BP.GetComponents<PedestrianTrafficSignal>();
        }

        StartCoroutine("SignalLoop");
    }

    IEnumerator SignalLoop()
    {
        yield return new WaitForSeconds(2);

        string blueSide = "A";

        while (true)
        {
            if (blueSide == "A")
            {
                for (int i = 0; i < 10; i++)
                {
                    foreach (var tf in ap)
                    {
                        tf.Off();
                    }
                    yield return new WaitForSeconds(0.25F);

                    foreach (var tf in ap)
                    {
                        tf.Blue();
                    }
                    yield return new WaitForSeconds(0.25F);
                }
                foreach (var tf in ap)
                {
                    tf.Red();
                }
                yield return new WaitForSeconds(1);

                foreach (var tf in a)
                {
                    tf.Yellow();
                }
                yield return new WaitForSeconds(2);

                foreach (var tf in a)
                {
                    tf.Red();
                }
                foreach (var tf in b)
                {
                    tf.Blue();
                }
                yield return new WaitForSeconds(1);

                foreach (var tf in bp)
                {
                    tf.Blue();
                }
                blueSide = "B";
            }
            else if (blueSide == "B")
            {
                for (int i = 0; i < 10; i++)
                {
                    foreach (var tf in bp)
                    {
                        tf.Off();
                    }
                    yield return new WaitForSeconds(0.25F);

                    foreach (var tf in bp)
                    {
                        tf.Blue();
                    }
                    yield return new WaitForSeconds(0.25F);
                }
                foreach (var tf in bp)
                {
                    tf.Red();
                }
                yield return new WaitForSeconds(1);

                foreach (var tf in b)
                {
                    tf.Yellow();
                }
                yield return new WaitForSeconds(2);

                foreach (var tf in b)
                {
                    tf.Red();
                }
                foreach (var tf in a)
                {
                    tf.Blue();
                }

                yield return new WaitForSeconds(1);
                foreach (var tf in ap)
                {
                    tf.Blue();
                }
                blueSide = "A";
            }
            yield return new WaitForSeconds(duration);
        }
    }

}
