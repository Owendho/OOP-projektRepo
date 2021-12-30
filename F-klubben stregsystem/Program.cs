using System;
using System.Collections.Generic;

namespace F_klubben_stregsystem
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Stregsystem stregsystem = new Stregsystem();
            StregsystemCLI ui = new StregsystemCLI(stregsystem);
            StregsystemController sc = new StregsystemController(ui, stregsystem);

            ui.Start();
        }
    }
}
