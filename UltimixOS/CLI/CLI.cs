using System;
using System.Collections.Generic;
using System.Text;

namespace UltimixOS.CLI
{
    public class CLI
    {

        Drivers.Hypervisor hypervisor = Kernel.getHypervisor();

        public CLI()
        {



        }
        
        public void run()
        {

            bool ok = true;
            while(ok)
            {


                hypervisor.ConsoleOut("Ultimix> ");
                string command = hypervisor.ConsoleIn();
                if (command == "help" || command == "?")
                {

                    hypervisor.ConsoleOutLine("---===UltimixOS Help===---");
                    hypervisor.ConsoleOutLine("help");
                    hypervisor.ConsoleOutLine("exit");
                    hypervisor.ConsoleOutLine("shutdown");
                    hypervisor.ConsoleOutLine("reboot");

                }
                else if (command == "exit")
                {

                    ok = false;

                }
                else if (command == "shutdown")
                {

                    hypervisor.ConsoleOutLine("Goodbye!");
                    hypervisor.Shutdown();

                }
                else if (command == "reboot")
                {

                    hypervisor.ConsoleOutLine("Rebooting...");
                    hypervisor.Reboot();

                }

            }

        }

    }
}
