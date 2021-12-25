using System;
using System.Collections.Generic;

namespace F_klubben_stregsystem
{
    class Program
    {
        static void Main(string[] args)
        {

            //StregsystemCLI stregsystemCLI = new StregsystemCLI();
            Stregsystem stregsystem = new Stregsystem();

            //stregsystem.CSVparser2();
            //Console.ReadLine();

            //stregsystem.CSVparserSemicolon();

            stregsystem.CSVparserR();


            /*
            int ID = 1;
            List<User> userList = new List<User>();
            userList.Add(new User("hellothere", "byethere", "pr", "gitg@gmail.com", ID++));

            User user1 = new User("owen", "Mbo", "owenmo", "owendho200@gmail.com", ID++);
            user1.ToString();
            Console.WriteLine(user1.ToString());

            User user2 = new User("mb", "ya", "yooyoy", "owendh2001@gmail.com", ID++);

            Console.WriteLine(user2.ToString());

            userList.ForEach(Console.WriteLine);
            */
        }
    }
}
