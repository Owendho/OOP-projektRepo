using System;

namespace F_klubben_stregsystem
{
    class Program
    {
        static void Main(string[] args)
        {
            User user1 = new User("owen", "Mbo", "owenmo", "owendho200@gmail.com");
            user1.ToString();
            Console.WriteLine(user1.ToString());
        }
    }
}
