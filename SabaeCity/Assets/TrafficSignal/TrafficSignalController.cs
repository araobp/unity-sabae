using System;
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

        SignalLoop();
    }

    async void SignalLoop()
    {
        await Task.Delay(TimeSpan.FromSeconds(2));

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
                    await Task.Delay(TimeSpan.FromSeconds(0.25));
                    foreach (var tf in ap)
                    {
                        tf.Blue();
                    }
                    await Task.Delay(TimeSpan.FromSeconds(0.25));
                }
                foreach (var tf in ap)
                {
                    tf.Red();
                }
                await Task.Delay(TimeSpan.FromSeconds(1));
                foreach (var tf in a)
                {
                    tf.Yellow();
                }
                await Task.Delay(TimeSpan.FromSeconds(2));
                foreach (var tf in a)
                {
                    tf.Red();
                }
                foreach (var tf in b)
                {
                    tf.Blue();
                }
                await Task.Delay(TimeSpan.FromSeconds(1));
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
                    await Task.Delay(TimeSpan.FromSeconds(0.25));
                    foreach (var tf in bp)
                    {
                        tf.Blue();
                    }
                    await Task.Delay(TimeSpan.FromSeconds(0.25));
                }
                foreach (var tf in bp)
                {
                    tf.Red();
                }
                await Task.Delay(TimeSpan.FromSeconds(1));
                foreach (var tf in b)
                {
                    tf.Yellow();
                }
                await Task.Delay(TimeSpan.FromSeconds(2));
                foreach (var tf in b)
                {
                    tf.Red();
                }
                foreach (var tf in a)
                {
                    tf.Blue();
                }
                await Task.Delay(TimeSpan.FromSeconds(1));
                foreach (var tf in ap)
                {
                    tf.Blue();
                }
                blueSide = "A";
            }
            await Task.Delay(TimeSpan.FromSeconds(duration));
        }
    }

}
