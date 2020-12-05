using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

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

        public void hyperexec(string[] cmds)
        {

            int i = 0;
            while(i < cmds.Length)
            {

                if(cmds[i] == "exit")
                {

                    return;

                } else if (cmds[i] == "prntout")
                {

                    this.ConsoleOut(cmds[i + 1]);
                    i++;

                }
                else if (cmds[i] == "prntoutln")
                {

                    this.ConsoleOutLine(cmds[i + 1]);
                    i++;

                }
                i++;

            }

        }

        public string readFileText(string path)
        {

            string output = "";

            if (File.Exists(path))
            {

                output = File.ReadAllText(path);

            } else
            {

                ConsoleOutLine("Hypervisor: File not found.");

            }
            return output;

        }

        public void fileWriteText(string path, string text)
        {

            File.WriteAllText(path, text);

        }

        public string[] getDirFiles(string path)
        {

            string[] output = { };

            if(Directory.Exists(path))
            {

                output = Directory.GetFiles(path);

            }

            return output;

        }

        public string[] dirGetDirs(string path)
        {

            string[] output = { };

            if(Directory.Exists(path))
            {

                output = Directory.GetDirectories(path);

            }

            return output;

        }

        public void removeFile(string path)
        {

            if (File.Exists(path))
            {

                File.Delete(path);

            }
            else
            {

                ConsoleOutLine("Hypervisor: File not found.");

            }

        }

        public void removeDir(string path)
        {

            if(Directory.Exists(path))
            {

                if(Directory.GetFiles(path).Length == 0 && Directory.GetDirectories(path).Length == 0)
                {

                    Directory.Delete(path);

                } else
                {

                    ConsoleOutLine("Hypervisor: Directory not empty.");

                }
                
            } else
            {

                ConsoleOutLine("Hypervisor: Directory not found.");

            }

        }

    }
}
