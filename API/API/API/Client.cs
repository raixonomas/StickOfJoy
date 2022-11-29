using MQTTnet;
using MQTTnet.Client.Connecting;
using MQTTnet.Client.Disconnecting;
using MQTTnet.Client.Options;
using MQTTnet.Client.Receiving;
using MQTTnet.Extensions.ManagedClient;

namespace API
{
    public class Client
    {
        MqttClientOptionsBuilder builder;

        ManagedMqttClientOptions options;

        IManagedMqttClient _mqttClient;

        public string galaga;
        public string altbeast;
        public string ddonpach;
        public string ffight;
        public string frogger;
        public string goldenaxe;
        public string mmancp2u;
        public string pacman;
        public string raiden2;

        public Client()
        {
            builder = new MqttClientOptionsBuilder()
                                        .WithClientId("Dev.To")
                                        .WithTcpServer("10.4.1.44", 707);


            options = new ManagedMqttClientOptionsBuilder()
                                    .WithAutoReconnectDelay(TimeSpan.FromSeconds(60))
                                    .WithClientOptions(builder.Build())
                                    .Build();


            _mqttClient = new MqttFactory().CreateManagedMqttClient();


            _mqttClient.ConnectedHandler = new MqttClientConnectedHandlerDelegate(OnConnected);
            _mqttClient.DisconnectedHandler = new MqttClientDisconnectedHandlerDelegate(OnDisconnected);
            _mqttClient.ConnectingFailedHandler = new ConnectingFailedHandlerDelegate(OnConnectingFailed);


            _mqttClient.ApplicationMessageReceivedHandler = new MqttApplicationMessageReceivedHandlerDelegate(OnMessageReceived);

            Start();
        }

        async public void Start()
        {
            _mqttClient.StartAsync(options).GetAwaiter().GetResult();


            await _mqttClient.SubscribeAsync(
                new MqttTopicFilter
                {
                    Topic = "Game/galaga",
                    QualityOfServiceLevel = (MQTTnet.Protocol.MqttQualityOfServiceLevel)2,
                },
                new MqttTopicFilter
                {
                    Topic = "Game/altbeast",
                    QualityOfServiceLevel = (MQTTnet.Protocol.MqttQualityOfServiceLevel)2,
                },
                new MqttTopicFilter
                {
                    Topic = "Game/ddonpach",
                    QualityOfServiceLevel = (MQTTnet.Protocol.MqttQualityOfServiceLevel)2,
                },
                new MqttTopicFilter
                {
                    Topic = "Game/ffight",
                    QualityOfServiceLevel = (MQTTnet.Protocol.MqttQualityOfServiceLevel)2,
                },
                new MqttTopicFilter
                {
                    Topic = "Game/frogger",
                    QualityOfServiceLevel = (MQTTnet.Protocol.MqttQualityOfServiceLevel)2,
                },
                new MqttTopicFilter
                {
                    Topic = "Game/goldenaxe",
                    QualityOfServiceLevel = (MQTTnet.Protocol.MqttQualityOfServiceLevel)2,
                },
                new MqttTopicFilter
                {
                    Topic = "Game/mmancp2u",
                    QualityOfServiceLevel = (MQTTnet.Protocol.MqttQualityOfServiceLevel)2,
                },
                new MqttTopicFilter
                {
                    Topic = "Game/pacman",
                    QualityOfServiceLevel = (MQTTnet.Protocol.MqttQualityOfServiceLevel)2,
                },
                new MqttTopicFilter
                {
                    Topic = "Game/raiden2",
                    QualityOfServiceLevel = (MQTTnet.Protocol.MqttQualityOfServiceLevel)2,
                }
                );
        }

        public static void OnConnected(MqttClientConnectedEventArgs obj)
        {

        }


        public static void OnConnectingFailed(ManagedProcessFailedEventArgs obj)
        {

        }


        public static void OnDisconnected(MqttClientDisconnectedEventArgs obj)
        {

        }

        public void OnMessageReceived(MqttApplicationMessageReceivedEventArgs obj)
        {
            string topic = obj.ApplicationMessage.Topic;
            var payloadText = obj.ApplicationMessage.Payload;

            if (topic == "Game/galaga")
            {
                galaga = System.Text.Encoding.Default.GetString(payloadText);
            }
            if (topic == "Game/altbeast")
            {
                altbeast = System.Text.Encoding.Default.GetString(payloadText);
            }
            if (topic == "Game/ddonpach")
            {
                ddonpach = System.Text.Encoding.Default.GetString(payloadText);
            }
            if (topic == "Game/ffight")
            {
                ffight = System.Text.Encoding.Default.GetString(payloadText);
            }
            if (topic == "Game/frogger")
            {
                frogger = System.Text.Encoding.Default.GetString(payloadText);
            }
            if (topic == "Game/goldenaxe")
            {
                goldenaxe = System.Text.Encoding.Default.GetString(payloadText);
            }
            if (topic == "Game/mmancp2u")
            {
                mmancp2u = System.Text.Encoding.Default.GetString(payloadText);
            }
            if (topic == "Game/pacman")
            {
                pacman = System.Text.Encoding.Default.GetString(payloadText);
            }
            if (topic == "Game/raiden2")
            {
                raiden2 = System.Text.Encoding.Default.GetString(payloadText);
            }
        }
    }
}
