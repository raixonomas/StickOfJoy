namespace MQTT.Library.Server
{
    using System;
    using System.Text;
    using MQTTnet;
    using MQTTnet.Server;
    using Serilog;

    public class Server
    {
        MqttServerOptionsBuilder builder;

        IMqttServer mqttServer;

        static int MessageCounter;

        public Server()
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .Enrich.FromLogContext()
                .WriteTo.Console()
                .CreateLogger();

            builder = new MqttServerOptionsBuilder()
                .WithDefaultEndpointPort(707)
                .WithConnectionValidator(OnNewConnection)
                .WithApplicationMessageInterceptor(OnNewMessage);

            mqttServer = new MqttFactory().CreateMqttServer();
        }

        public void Start()
        {
            mqttServer.StartAsync(builder.Build()).GetAwaiter().GetResult();
        }

        public static void OnNewConnection(MqttConnectionValidatorContext context)
        {
            Log.Logger.Information(
                    "New connection: ClientId = {clientId}, Endpoint = {endpoint}, CleanSession = {cleanSession}",
                    context.ClientId,
                    context.Endpoint,
                    context.CleanSession);
        }

        public static void OnNewMessage(MqttApplicationMessageInterceptorContext context)
        {
            var payload = context.ApplicationMessage?.Payload == null ? null : Encoding.UTF8.GetString(context.ApplicationMessage?.Payload);

            MessageCounter++;

            Log.Logger.Information(
                "MessageId: {MessageCounter} - TimeStamp: {TimeStamp} -- Message: ClientId = {clientId}, Topic = {topic}, Payload = {payload}, QoS = {qos}, Retain-Flag = {retainFlag}",
                MessageCounter,
                DateTime.Now,
                context.ClientId,
                context.ApplicationMessage?.Topic,
                payload,
                context.ApplicationMessage?.QualityOfServiceLevel,
                context.ApplicationMessage?.Retain);
        }
    }

}