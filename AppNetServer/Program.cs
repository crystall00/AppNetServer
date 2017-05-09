using System;
using Microsoft.Owin.Hosting;

namespace AppNetServer
{
    class Program
    {
        static void Main(string[] args)
        {
            using (WebApp.Start<Startup>("http://appnet.hsr.ch:40000"))
            {
                Console.WriteLine("####################");
                Console.WriteLine("#### AppNet v1.0 ###");
                Console.WriteLine("####################");
                Console.WriteLine("--------------------");
                Console.WriteLine("AppNet Web Service is running...");
                Console.WriteLine("Press any key to quit the AppNet Web Service.");
                Console.ReadLine();
            }
        }
    }
}
