using System;
using Quobject.SocketIoClientDotNet.Client;

namespace Chromamboo.Providers.Notification
{
    internal class PushNotificationProvider : INotificationProvider<string>
    {

        public void Register(string param)
        {
            var socket = IO.Socket("http://localhost");

            socket.On("news", (data) =>
            {
                Console.WriteLine(data);               
            });
            Console.ReadLine();
        }
    }
}