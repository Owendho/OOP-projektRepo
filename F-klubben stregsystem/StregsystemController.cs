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
            strCLI = stregsystemCli;
            str = stregsystem;
            stregsystemCli.CommandEntered += ExecuteCommand;

        }

        StregsystemCLI strCLI;
        Stregsystem str;

        public void ExecuteCommand(string command)
        {
            StregsystemCommandParser commandParser = new StregsystemCommandParser(strCLI, str);
            commandParser.commandType(command);
        }
    }

}
