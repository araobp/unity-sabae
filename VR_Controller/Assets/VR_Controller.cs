using UnityEngine;
using MQTTnet;
using MQTTnet.Client;
using MQTTnet.Client.Options;
using System.Text;
using System.Threading;
using UnityEngine.UI;

public class VR_Controller : MonoBehaviour
{
    [SerializeField] Properties properties;
    [SerializeField] Text text;

    IMqttClient mqttClient;

    private void Publish(string message)
    {
        text.text = message;

        byte[] bytes = Encoding.ASCII.GetBytes(message);
        //Debug.Log($"{message}, {Encoding.ASCII.GetString(bytes)}");

        if (mqttClient.IsConnected)
        {
            var payload = new MqttApplicationMessageBuilder()
            .WithTopic(properties.topic)
            .WithPayload(bytes)
            .WithRetainFlag(false)
            .Build();
            mqttClient.PublishAsync(payload);
        }

        
    }

    // Start is called before the first frame update
    async void Start()
    {
        var factory = new MqttFactory();
        mqttClient = factory.CreateMqttClient();
        var options = new MqttClientOptionsBuilder()
            .WithClientId("input")
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

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            Publish("Wd");
        }
        else if (Input.GetKeyUp(KeyCode.W))
        {
            Publish("Wu");
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            Publish("Ad");
        }
        else if (Input.GetKeyUp(KeyCode.A))
        {
            Publish("Au");
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            Publish("Sd");
        }
        else if (Input.GetKeyUp(KeyCode.S))
        {
            Publish("Su");
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            Publish("Dd");
        }
        else if (Input.GetKeyUp(KeyCode.D))
        {
            Publish("Du");
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            Publish("Rd");
        }
        else if (Input.GetKeyUp(KeyCode.R))
        {
            Publish("Ru");
        }

        if (Input.GetKeyDown(KeyCode.K))
        {
            Publish("Kd");
        }
        else if (Input.GetKeyUp(KeyCode.K))
        {
            Publish("Ku");
        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Publish("1d");
        }
        else if (Input.GetKeyUp(KeyCode.Alpha1))
        {
            Publish("1u");
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Publish("2d");
        }
        else if (Input.GetKeyUp(KeyCode.Alpha2))
        {
            Publish("2u");
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            Publish("3d");
        }
        else if (Input.GetKeyUp(KeyCode.Alpha3))
        {
            Publish("3u");
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            Publish("3d");
        }
        else if (Input.GetKeyUp(KeyCode.Alpha3))
        {
            Publish("3u");
        }

        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            Publish("4d");
        }
        else if (Input.GetKeyUp(KeyCode.Alpha4))
        {
            Publish("4u");
        }

        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            Publish("5d");
        }
        else if (Input.GetKeyUp(KeyCode.Alpha5))
        {
            Publish("5u");
        }
    }
}
