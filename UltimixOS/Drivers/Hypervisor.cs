using System;
using System.Collections.Generic;
using System.Text;

namespace UltimixOS.Drivers
{
    public class Hypervisor
    {

        public Hypervisor()
        {



        }

        public void ConsoleOut(string text)
        {

            Console.Write(text);

        }

        public void ConsoleOutLine(string text)
        {

            Console.WriteLine(text);

        }

        public string ConsoleIn()
        {

            return Console.ReadLine();

        }

        public void Shutdown()
        {

            Cosmos.System.Power.Shutdown();

        }

        public void Reboot()
        {

            Cosmos.System.Power.Reboot();

        }

    }
}
