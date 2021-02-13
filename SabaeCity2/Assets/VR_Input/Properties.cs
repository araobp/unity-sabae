using System;

// MQTT-related properties
[Serializable]
public class MqttParameters
{
    public string mqttServer = "192.168.57.3";
    public string mqttUsername = "simulator";
    public string mqttPassword = "simulator";
    public string topic = "input";
}
