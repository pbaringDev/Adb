using SharpAdbClient;
using System;

namespace AndroidDebugBridge
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Starting Adb...");

            AdbServer server = new AdbServer();
            var result = server.StartServer(@"C:\Program Files (x86)\android-sdk\platform-tools\adb.exe", restartServerIfNewer: false);


            Console.WriteLine($"SERVER STATUS: {result.ToString()}");

            if (result == StartServerResult.AlreadyRunning)
            {
                //List all Android devices currently connected
                Console.WriteLine("Devices currently connected...");

                var client = new AdbClient();

                var devices = client.GetDevices();

                foreach (var device in devices)
                {
                    Console.WriteLine(device.Name);
                }
            }

            Console.ReadKey();
        }
    }
}
