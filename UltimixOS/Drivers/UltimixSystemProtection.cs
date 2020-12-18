using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace UltimixOS.Drivers
{
    public class UltimixSystemProtection
    {

        public static void verifyAndRepair()
        {

            if (Directory.Exists(@"0:\Ultimix")) { 
                if(Directory.Exists(@"0:\Ultimix\bin"))
                {
                } else
                {
                    Directory.CreateDirectory(@"0:\Ultimix\bin");
                }
                if (Directory.Exists(@"0:\Ultimix\usr"))
                {
                }
                else
                {
                    Directory.CreateDirectory(@"0:\Ultimix\usr");
                }
            } else
            {
                Directory.CreateDirectory(@"0:\Ultimix");
                Directory.CreateDirectory(@"0:\Ultimix\bin");
                Directory.CreateDirectory(@"0:\Ultimix\usr");
            }
            
        }

    }
}