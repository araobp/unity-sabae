using System;
using System.Threading.Tasks;
using UnityEngine;

public class TrafficSignalController : MonoBehaviour
{
    public float duration = 20F;

    TrafficSignal[] a;
    TrafficSignal[] b;
    PedestrianTrafficSignal[] ap;
    PedestrianTrafficSignal[] bp;

    // Start is called before the first frame update
    void Start()
    {
        a = transform.Find("A").GetComponents<TrafficSignal>();
        b = transform.Find("B").GetComponents<TrafficSignal>();
        ap = transform.Find("AP").GetComponents<PedestrianTrafficSignal>();
        bp = transform.Find("BP").GetComponents<PedestrianTrafficSignal>();
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
