// See https://aka.ms/new-console-template for more information

using Microsoft.Extensions.DependencyInjection;
using MQTT.Library.Server;

Server Server = new Server();

IServiceProvider serviceProvider;

IServiceCollection services = new ServiceCollection();

Server.Start();

Console.ReadLine();
