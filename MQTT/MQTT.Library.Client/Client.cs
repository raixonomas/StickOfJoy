namespace MQTT.Library.Client
{

    using System;
    using System.IO;
    using System.Text;
    using System.Threading.Tasks;
    using MQTTnet;
    using MQTTnet.Client.Connecting;
    using MQTTnet.Client.Disconnecting;
    using MQTTnet.Client.Options;
    using MQTTnet.Client.Receiving;
    using MQTTnet.Extensions.ManagedClient;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    using Serilog;

    public class Client
    {
        MqttClientOptionsBuilder builder;

        ManagedMqttClientOptions options;

        IManagedMqttClient _mqttClient;

        private static string dir = @"C:\StickOfJoy";

        public Client()
        {
            Log.Logger = new LoggerConfiguration()
              .MinimumLevel.Debug()
              .Enrich.FromLogContext()
              .WriteTo.Console()
              .CreateLogger();

            builder = new MqttClientOptionsBuilder()
                                        .WithClientId("Dev.To")
                                        .WithTcpServer("10.4.1.184", 707);

            options = new ManagedMqttClientOptionsBuilder()
                                    .WithAutoReconnectDelay(TimeSpan.FromSeconds(60))
                                    .WithClientOptions(builder.Build())
                                    .Build();

            _mqttClient = new MqttFactory().CreateManagedMqttClient();

            _mqttClient.ConnectedHandler = new MqttClientConnectedHandlerDelegate(OnConnected);
            _mqttClient.DisconnectedHandler = new MqttClientDisconnectedHandlerDelegate(OnDisconnected);
            _mqttClient.ConnectingFailedHandler = new ConnectingFailedHandlerDelegate(OnConnectingFailed);

            _mqttClient.ApplicationMessageReceivedHandler = new MqttApplicationMessageReceivedHandlerDelegate(OnMessageReceived);
        }

        async public void Start()
        {
            _mqttClient.StartAsync(options).GetAwaiter().GetResult();

            await _mqttClient.SubscribeAsync(
                new MqttTopicFilter
                {
                    Topic = "dev.to/topic/highscore",

                },
                new MqttTopicFilter
                {
                    Topic = "dev.to/topic/data",

                }
                );

            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }
        }

        public static void OnConnected(MqttClientConnectedEventArgs obj)
        {
            Log.Logger.Information("Successfully connected.");
        }

        public static void OnConnectingFailed(ManagedProcessFailedEventArgs obj)
        {
            Log.Logger.Warning("Couldn't connect to broker.");
        }

        public static void OnDisconnected(MqttClientDisconnectedEventArgs obj)
        {
            Log.Logger.Information("Successfully disconnected.");
        }
        
        public static void OnMessageReceived(MqttApplicationMessageReceivedEventArgs obj)
        {
            string topic = obj.ApplicationMessage.Topic;
            var payloadText = obj.ApplicationMessage.Payload;
            if (topic == "dev.to/topic/highscore")
            {
                using (FileStream writer = new FileStream(dir + @"\raiden2.hi", FileMode.Create, FileAccess.Write))
                {
                    writer.Write(obj.ApplicationMessage.Payload,0,obj.ApplicationMessage.Payload.Length);
                }
            }
            else if (topic == "dev.to/topic/data")
            {
                using (StreamWriter writer = File.CreateText(dir + @"\hiscore.dat"))
                {
                    writer.Write(payloadText);
                }
            }

            

            Console.WriteLine($"Received msg: {payloadText}");
        }

        public void SendJsonFile(string message)
        {
            using (StreamReader r = new StreamReader(@"C:\Users\533\Documents\GitHub\StickOfJoy\MQTT\raiden2.hi"))
            {
                string json = r.ReadToEnd();
                _mqttClient.PublishAsync("dev.to/topic/highscore", json);
            }         
        }
    }
}