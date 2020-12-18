using System;
using System.Collections.Generic;
using System.Text;

namespace UltimixOS.Drivers
{
    public class UserManager
    {

        public static List<string> users = new List<string>();

        public static void ShellAsUser(string username)
        {

            if(users.Contains(username))
            {

                CLI.CLI cli = new CLI.CLI(username);
                cli.run();

            } else
            {

                Kernel.getHypervisor().ConsoleOutLine("[UserMngr] Error: No user found.");

            }

        }

        public static void saveUsers()
        {

            string userout = "";
            foreach(string s in users)
            {

                userout = userout + s + "\n";

            }

            Kernel.getHypervisor().fileWriteText(@"0:\Ultimix\usr\usrlist.cfg", userout);

        }

        public static void loadUsers()
        {

            string[] lines = Kernel.getHypervisor().readFileLns(@"0:\Ultimix\usr\usrlist.cfg");

            foreach(string s in lines)
            {

                users.Add(s);

            }

        }

    }
}
