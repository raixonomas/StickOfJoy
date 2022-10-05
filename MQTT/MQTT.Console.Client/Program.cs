// See https://aka.ms/new-console-template for more information

using MQTT.Library.Client;

Client client = new Client();

client.Start();

string message;

do
{
    Console.WriteLine("Enter the message you want to send");

    message = Console.ReadLine();

    client.SendJsonFile(message);

} while (true);

