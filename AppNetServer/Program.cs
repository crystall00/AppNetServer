using System;
using Microsoft.Owin.Hosting;

#pragma warning disable 1591
namespace AppNetServer
{
    class Program
    {//test
        static void Main(string[] args)
        {
            using (WebApp.Start<Startup>("http://appnet.hsr.ch:40000"))//http://appnet.hsr.ch:40000"))http://localhost:9000
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
