using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F_klubben_stregsystem
{
    class StregsystemController
    {
        StregsystemCommandParser commandParser = new StregsystemCommandParser();
        
        public void HandleInput()
        {
            ConsoleKeyInfo key = Console.ReadKey();

            string inputcommand= Console.ReadLine();

            switch (key.Key)
            {
                case ConsoleKey.Enter:
                    commandParser.ParseCommand(inputcommand);
                    break;
                case ConsoleKey.UpArrow:
                    //MoveUp();
                    break;
                case ConsoleKey.DownArrow:
                    //MoveDown();
                    break;
                case ConsoleKey.Escape:
                    //_running = false;
                    break;

                default:
                    break;

            }
        }
    }
    /*StregsystemController opdaterer brugergrænsefladen og modificerer stregsystemet.
     *Den holder referencer til både Stregsystem og til en IStregsystemUI. 
     * */
}
