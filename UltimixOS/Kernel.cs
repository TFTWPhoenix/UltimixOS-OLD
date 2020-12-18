using System;
using System.Collections.Generic;
using System.Text;
using Sys = Cosmos.System;

namespace UltimixOS
{
    public class Kernel : Sys.Kernel
    {

        private static Drivers.Hypervisor hypervisor = new Drivers.Hypervisor();
        private static CLI.CLI cli = new CLI.CLI();

        protected override void BeforeRun()
        {
            Console.WriteLine("[COSMOS] Cosmos has booted successfully.");
            Drivers.FSDriver.initFS();
            Console.WriteLine("[  FS  ] FileSystem Initialized.");
            Drivers.UltimixSystemProtection.verifyAndRepair();
        }

        protected override void Run()
        {

            Drivers.UltimixSystemProtection.verifyAndRepair();
            cli.run();
            Drivers.UltimixSystemProtection.verifyAndRepair();

        }

        public static Drivers.Hypervisor getHypervisor()
        {

            return hypervisor;

        }

        public static CLI.CLI getCLI()
        {

            return cli;

        }

    }
}
