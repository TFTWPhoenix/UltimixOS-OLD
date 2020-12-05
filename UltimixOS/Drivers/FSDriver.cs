using System;
using System.Collections.Generic;
using System.Text;
using Sys = Cosmos.System;

namespace UltimixOS.Drivers
{
    public class FSDriver
    {

        public static Cosmos.System.FileSystem.CosmosVFS fs = new Sys.FileSystem.CosmosVFS();

        public static void initFS()
        {

            Sys.FileSystem.VFS.VFSManager.RegisterVFS(fs);

        }

    }
}
