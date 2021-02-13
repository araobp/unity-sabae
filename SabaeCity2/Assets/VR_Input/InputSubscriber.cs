using UnityEngine;
using MQTTnet;
using MQTTnet.Client;
using MQTTnet.Client.Options;
using System.Text;
using System.Threading;
using System.Collections.Generic;

public class InputSubscriber : MonoBehaviour
{
    [SerializeField] MqttParameters properties;
    // [SerializeField] Text text;

    IMqttClient mqttClient;

    static bool Wd = false;
    static bool Ad = false;
    static bool Sd = false;
    static bool Dd = false;
    static bool W = false;
    static bool A = false;
    static bool S = false;
    static bool D = false;
    static bool Wu = false;
    static bool Au = false;
    static bool Su = false;
    static bool Du = false;

    static bool Kd = false;
    static bool K = false;
    static bool Ku = false;

    static bool Alpha1u = false;
    static bool Alpha2u = false;
    static bool Alpha3u = false;
    static bool Alpha4u = false;
    static bool Alpha5u = false;
    static bool Alpha1 = false;
    static bool Alpha2 = false;
    static bool Alpha3 = false;
    static bool Alpha4 = false;
    static bool Alpha5 = false;
    static bool Alpha1d = false;
    static bool Alpha2d = false;
    static bool Alpha3d = false;
    static bool Alpha4d = false;
    static bool Alpha5d = false;

    static Queue<string> queue = new Queue<string>();

    static float axisVertical = 0F;
    static float axisHorizontal = 0F;

    // Start is called before the first frame update
    async void Start()
    {
        var factory = new MqttFactory();
        mqttClient = factory.CreateMqttClient();
        var options = new MqttClientOptionsBuilder()
            .WithClientId("VR")
            .WithTcpServer(properties.mqttServer, 1883)
            .WithCredentials(properties.mqttUsername, Encoding.ASCII.GetBytes(properties.mqttPassword))
            .Build();

        var cancellationTokenSource = new CancellationTokenSource(500);

        try
        {
            await mqttClient.ConnectAsync(options, cancellationTokenSource.Token);
            if (mqttClient.IsConnected)
            {
                Debug.Log("Connected to MQTT server");
                mqttClient.UseApplicationMessageReceivedHandler(e =>
                {
                    var message = e.ApplicationMessage;
                    if (message.Topic == properties.topic)
                    {
                        string payload = Encoding.ASCII.GetString(message.Payload);
                        //Debug.Log($"MQTT message received: {payload}");
                    }
                });

                mqttClient.UseApplicationMessageReceivedHandler(e =>
                {
                    var message = e.ApplicationMessage;
                    if (message.Topic == properties.topic)
                    {
                        string payload = Encoding.ASCII.GetString(message.Payload);
                        //Debug.Log($"{message.Topic}, {payload}");
                        queue.Enqueue(payload);
                    }
                });

                await mqttClient.SubscribeAsync(new TopicFilterBuilder().WithTopic(properties.topic).Build());
            }
            else
            {
                Debug.Log("MQTT connection failure");
            }
        }
        catch (System.Exception e)
        {
            Debug.Log($"MQTT connection failure: {e}");
        }
    }

    public static bool GetKey(KeyCode key)
    {
        bool state = false;

        switch (key)
        {
            case KeyCode.W:
                state = W;
                break;
            case KeyCode.A:
                state = A;
                break;
            case KeyCode.S:
                state = false;
                break;
            case KeyCode.D:
                state = D;
                break;

            case KeyCode.K:
                state = K;
                break;

            case KeyCode.Alpha1:
                state = Alpha1;
                break;
            case KeyCode.Alpha2:
                state = Alpha2;
                break;
            case KeyCode.Alpha3:
                state = Alpha3;
                break;
            case KeyCode.Alpha4:
                state = Alpha4;
                break;
            case KeyCode.Alpha5:
                state = Alpha5;
                break;
        }

        return state;
    }

    public static bool GetKeyDown(KeyCode key)
    {
        bool state = false;

        switch (key)
        {
            case KeyCode.W:
                state = Wd;
                Wd = false;
                break;
            case KeyCode.A:
                state = Ad;
                Ad = false;
                break;
            case KeyCode.S:
                state = Sd;
                Sd = false;
                break;
            case KeyCode.D:
                state = Dd;
                Dd = false;
                break;

            case KeyCode.K:
                state = Kd;
                Kd = false;
                break;

            case KeyCode.Alpha1:
                state = Alpha1d;
                Alpha1d = false;
                break;
            case KeyCode.Alpha2:
                state = Alpha2d;
                Alpha2d = false;
                break;
            case KeyCode.Alpha3:
                state = Alpha3d;
                Alpha3d = false;
                break;
            case KeyCode.Alpha4:
                state = Alpha4d;
                Alpha4d = false;
                break;
            case KeyCode.Alpha5:
                state = Alpha5d;
                Alpha5d = false;
                break;
        }

        return state;
    }

    public static bool GetKeyUp(KeyCode key)
    {
        bool state = false;

        switch (key)
        {
            case KeyCode.W:
                state = Wu;
                Wu = false;
                break;
            case KeyCode.A:
                state = Au;
                Au = false;
                break;
            case KeyCode.S:
                state = Su;
                Su = false;
                break;
            case KeyCode.D:
                state = Du;
                Du = false;
                break;

            case KeyCode.K:
                state = Ku;
                Ku = false;
                break;

            case KeyCode.Alpha1:
                state = Alpha1u;
                Alpha1u = false;
                break;
            case KeyCode.Alpha2:
                state = Alpha2u;
                Alpha2u = false;
                break;
            case KeyCode.Alpha3:
                state = Alpha3u;
                Alpha3u = false;
                break;
            case KeyCode.Alpha4:
                state = Alpha4u;
                Alpha4u = false;
                break;
            case KeyCode.Alpha5:
                state = Alpha5u;
                Alpha5u = false;
                break;
        }

        return state;
    }

    public static float GetAxis(string axis)
    {
        float value = 0F;
        switch (axis)
        {
            case "Vertical":
                value = axisVertical;
                break;
            case "Horizontal":
                value = axisHorizontal;
                break;
            default:
                break;
        }
        return value;
    }

    private void Update()
    {
        if (queue.Count > 0) {
            string key = queue.Dequeue();
            SetKeycode(key);
        }
    }

    static void SetKeycode(string key)
    {
        Debug.Log(key);
        switch(key)
        {
            case "Wd":
                Wd = true;
                W = true;
                axisVertical = 1F;
                break;
            case "Ad":
                Ad = true;
                A = true;
                axisHorizontal = -1F;
                break;
            case "Sd":
                Sd = true;
                S = true;
                axisVertical = -1F;
                break;
            case "Dd":
                Dd = true;
                D = true;
                axisHorizontal = 1F;
                break;
            case "Wu":
                Wd = false;
                W = false;
                Wu = true;
                axisVertical = 0F;
                break;
            case "Au":
                Ad = false;
                A = false;
                Au = true;
                axisHorizontal = 0F;
                break;
            case "Su":
                Sd = false;
                S = false;
                Su = true;
                axisVertical = 0F;
                break;
            case "Du":
                Dd = false;
                D = false;
                Du = true;
                axisHorizontal = 0F;
                break;

            case "Kd":
                Kd = true;
                K = true;
                break;
            case "Ku":
                Kd = false;
                K = false;
                Ku = true;
                break;

            case "1d":
                Alpha1d = true;
                Alpha1 = true;
                break;
            case "2d":
                Alpha2d = true;
                Alpha2 = true;
                break;
            case "3d":
                Alpha3d = true;
                Alpha3 = true;
                break;
            case "4d":
                Alpha4d = true;
                Alpha4 = true;
                break;
            case "5d":
                Alpha5d = true;
                Alpha5 = true;
                break;
            case "1u":
                Alpha1d = false;
                Alpha1 = false;
                Alpha1u = true;
                break;
            case "2u":
                Alpha2d = false;
                Alpha2 = false;
                Alpha2u = true;
                break;
            case "3u":
                Alpha3d = false;
                Alpha3 = false;
                Alpha3u = true;
                break;
            case "4u":
                Alpha4d = false;
                Alpha4 = false;
                Alpha4u = true;
                break;
            case "5u":
                Alpha5d = false;
                Alpha5 = false;
                Alpha5u = true;
                break;
        }
    }
}
