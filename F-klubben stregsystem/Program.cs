using System;
using System.Collections.Generic;

namespace F_klubben_stregsystem
{
    class Program
    {
        static void Main(string[] args)
        {

            //StregsystemCLI stregsystemCLI = new StregsystemCLI();
            //Stregsystem stregsystem = new Stregsystem();

            //stregsystem.CSVparser();
            //StregsystemCLI stregsystemCLI = new StregsystemCLI();

            //StregsystemCommandParser commandParser = new StregsystemCommandParser();
            //commandParser.ParseCommand("hello");

            Stregsystem stregsystem = new Stregsystem();
            StregsystemCLI ui = new StregsystemCLI(stregsystem);

            ui.Start();

            //stregsystemCLI.Show();



        }
    }
}
