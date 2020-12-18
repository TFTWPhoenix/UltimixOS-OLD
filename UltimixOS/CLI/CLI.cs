using System;
using System.Collections.Generic;
using System.Text;

namespace UltimixOS.CLI
{
    public class CLI
    {

        Drivers.Hypervisor hypervisor = Kernel.getHypervisor();
        string username;

        public CLI()
        {

            username = "defaultuser";

        }

        public CLI(string username)
        {

            this.username = username;

        }
        
        public void run()
        {

            bool ok = true;
            while(ok)
            {


                hypervisor.ConsoleOut(username + " | Ultimix> ");
                string command = hypervisor.ConsoleIn();
                if (command == "help" || command == "?")
                {

                    hypervisor.ConsoleOutLine("---===UltimixOS Help===---");
                    hypervisor.ConsoleOutLine("help");
                    hypervisor.ConsoleOutLine("exit");
                    hypervisor.ConsoleOutLine("shutdown");
                    hypervisor.ConsoleOutLine("reboot");
                    hypervisor.ConsoleOutLine("echotofile [file] > [data]");
                    hypervisor.ConsoleOutLine("cat [file]");
                    hypervisor.ConsoleOutLine("ls [directory]");
                    hypervisor.ConsoleOutLine("rm [file]");
                    hypervisor.ConsoleOutLine("rmdir [directory]");

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
                else if (command.StartsWith("echotofile "))
                {

                    hypervisor.fileWriteText(command.Split("echotofile ")[1].Split(" > ")[0], command.Split(" > ")[1].Replace("\\n", "\n"));

                }
                else if (command.StartsWith("cat "))
                {

                    hypervisor.ConsoleOutLine(hypervisor.readFileText(command.Split("cat ")[1]).Replace("\\n", "\n"));

                }
                else if (command.StartsWith("ls "))
                {

                    for (int i = 0; i < hypervisor.getDirFiles(command.Split("ls ")[1]).Length; i++)
                    {

                        string filename = hypervisor.getDirFiles(command.Split("ls ")[1])[i];

                        if (filename.EndsWith(".text") || filename.EndsWith(".txt"))
                        {

                            hypervisor.ConsoleOutLine("[FILE] " + filename + " [Text File (.txt/.text)]");

                        }
                        else if (filename.EndsWith(".sys"))
                        {

                            hypervisor.ConsoleOutLine("[FILE] " + filename + " [System File (.sys)]");

                        }
                        else if (filename.EndsWith(".hpx"))
                        {

                            hypervisor.ConsoleOutLine("[FILE] " + filename + " [Hypervisor Executable (.hpx)]");

                        }
                        else if (filename.EndsWith(".log"))
                        {

                            hypervisor.ConsoleOutLine("[FILE] " + filename + " [Log File (.log)]");

                        }
                        else if (filename.EndsWith(".dmp"))
                        {

                            hypervisor.ConsoleOutLine("[FILE] " + filename + " [Dump File (.dmp)]");

                        }
                        else if (filename.EndsWith(".uasm"))
                        {

                            hypervisor.ConsoleOutLine("[FILE] " + filename + " [Ultimix Assembly File (.uasm)]");

                        }
                        else
                        {

                            hypervisor.ConsoleOutLine("[FILE] " + filename + " [Unknown File]");

                        }


                    }
                    for (int i = 0; i < hypervisor.dirGetDirs(command.Split("ls ")[1]).Length; i++)
                    {

                        hypervisor.ConsoleOutLine("[DIR] " + hypervisor.dirGetDirs(command.Split("ls ")[1])[i]);

                    }

                }
                else if (command == "ls") {

                    for (int i = 0; i < hypervisor.getDirFiles(@"0:\").Length; i++)
                    {

                        string filename = hypervisor.getDirFiles(@"0:\")[i];

                        if (filename.EndsWith(".text") || filename.EndsWith(".txt"))
                        {

                            hypervisor.ConsoleOutLine("[FILE] " + filename + " [Text File (.txt/.text)]");

                        }
                        else if (filename.EndsWith(".sys"))
                        {

                            hypervisor.ConsoleOutLine("[FILE] " + filename + " [System File (.sys)]");

                        }
                        else if (filename.EndsWith(".hpx"))
                        {

                            hypervisor.ConsoleOutLine("[FILE] " + filename + " [Hypervisor Executable (.hpx)]");

                        }
                        else if (filename.EndsWith(".log"))
                        {

                            hypervisor.ConsoleOutLine("[FILE] " + filename + " [Log File (.log)]");

                        }
                        else if (filename.EndsWith(".dmp"))
                        {

                            hypervisor.ConsoleOutLine("[FILE] " + filename + " [Dump File (.dmp)]");

                        }
                        else if (filename.EndsWith(".uasm"))
                        {

                            hypervisor.ConsoleOutLine("[FILE] " + filename + " [Ultimix Assembly File (.uasm)]");

                        }
                        else
                        {

                            hypervisor.ConsoleOutLine("[FILE] " + filename + " [Unknown File]");

                        }


                    }
                    for (int i = 0; i < hypervisor.dirGetDirs(@"0:\").Length; i++)
                    {

                        hypervisor.ConsoleOutLine("[DIR] " + hypervisor.dirGetDirs(@"0:\")[i]);

                    }

                }
                else if (command.StartsWith("rm "))
                {

                    hypervisor.removeFile(command.Split("rm ")[1]);

                }
                else if (command.StartsWith("rmdir "))
                {

                    hypervisor.removeDir(command.Split("rmdir ")[1]);

                }
                else if (command.StartsWith("iapps "))
                {

                    if (command.Split("iapps ")[1] == "--list" || command.Split("iapps ")[1] == "-l")
                    {

                        hypervisor.ConsoleOutLine("Integrated Apps (IApps) List");
                        hypervisor.ConsoleOutLine("");

                    }

                }
                else if (command.StartsWith("uasm "))
                {

                    UASM.Exec exc = new UASM.Exec();
                    exc.exec(hypervisor.readFileLns(command.Split("uasm ")[1]));

                } else if (command == "usp-verif")
                {

                    Drivers.UltimixSystemProtection.verifyAndRepair();

                } else if (command.StartsWith("useradd "))
                {

                    Drivers.UserManager.users.Add(command.Split("useradd ")[1]);
                    hypervisor.ConsoleOutLine("Added user.");
                    Drivers.UserManager.saveUsers();
                    hypervisor.ConsoleOutLine("Saved user list to disk.");

                } else if (command.StartsWith("switchuser "))
                {

                    Drivers.UserManager.ShellAsUser(command.Split("switchuser ")[1]);

                }

            }

        }

    }
}
