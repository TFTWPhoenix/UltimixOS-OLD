using System;
using System.Collections.Generic;
using System.Text;

namespace UltimixOS.UASM
{
    public class Exec
    {

        public string[] mem;
        public int retloc;

        public Exec()
        {

            mem = new string[8192];
            retloc = 0;

        }

        public void exec(string[] asm)
        {

            int i = 0;
            while(i < asm.Length)
            {

                if(asm[i].StartsWith("jmp "))
                {

                    retloc = i;
                    i = int.Parse(asm[i].Split("jmp ")[1]);

                } else if (asm[i] == "ret")
                {

                    i = retloc;

                } else if (asm[i].StartsWith("prnt "))
                {

                    Kernel.getHypervisor().ConsoleOut(asm[i].Split("prnt ")[1]);

                }
                else if (asm[i].StartsWith("prntln "))
                {

                    Kernel.getHypervisor().ConsoleOutLine(asm[i].Split("prntln ")[1]);

                }

                i++;

            }

        }

    }
}
