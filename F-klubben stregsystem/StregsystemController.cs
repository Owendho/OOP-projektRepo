using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F_klubben_stregsystem
{
    class StregsystemController
    {
        public StregsystemController(StregsystemCLI stregsystemCli, Stregsystem stregsystem)
        {
            //parser = commandParser;
            strCLI = stregsystemCli;
            str = stregsystem;
            stregsystemCli.CommandEntered += ExecuteCommand;

        }


        StregsystemCLI strCLI;
        Stregsystem str;
        //StregsystemCommandParser parser;

        public void ExecuteCommand(string command)
        {
            StregsystemCommandParser commandParser = new StregsystemCommandParser(strCLI, str);
            commandParser.commandType(command);
        }
        public void HandleInput()
        {

            string inputcommand = Console.ReadLine();
            //commandParser.ParseCommand(inputcommand);

        }
    }
    /*StregsystemController opdaterer brugergrænsefladen og modificerer stregsystemet.
     *Den holder referencer til både Stregsystem og til en IStregsystemUI. 
     * */
}
