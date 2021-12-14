using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace F_klubben_stregsystem
{
    class User : IComparable
    {
        public User(string FirstName, string LastName, string UserName, string Email, decimal balance)
        {
            firstName = FirstName;
            lastName = LastName;
            userName = UserName;
            email = Email;
            Balance = balance;
            id++;

        }

        public int CompareTo(object obj)
        {
            if (obj == null)
            {
                return 1;
            }

            User testUser = new User(firstName, lastName, userName, email, Balance);

            if (testUser != null)
            {
                return testUser.CompareTo(obj);
            }
            else
            {
                throw new ArgumentException("This is not a user");
            }

        }

        private string _userName, _email, _firstname, _lastname;
        public static int id { get; set; }

        public string firstName
        {
            get
            {
                return _firstname;
            }
            set
            {
                if (value == null)
                    throw new NullReferenceException();

                _firstname = value;
            }
        }

        public string lastName
        {
            get
            {
                return _lastname;
            }
            set
            {
                if (value == null)
                    throw new NullReferenceException();
                _lastname = value;
            }
        }


        /*Validation in the get and set here. Username may contain numbers 0 - 9, small letters and underscore: [0-9], [a-z], og '_'*/
        public string userName
        {
            get
            {
                return _userName;
            }
            set
            {
                Regex usernameExpression = new Regex(@"^[0-9?[a-z_]+$");

                if (!usernameExpression.IsMatch(value))
                {
                    throw new Exception("Invalid string");
                }
                else
                {
                    _userName = value;
                }
            }
        }
        public string email 
        { 
            get
            {
                return _email;
            }

            set
            {
                string[] emailStringSplit = value.Split("@");

                Regex localPartExpression = new Regex(@"^\w+.+$");
                Regex domainExpression = new Regex(@"^[0-9?[a-z_A-Z]+$");

                string localPart = emailStringSplit[0];
                string domainPart = emailStringSplit[1];


                if (!localPartExpression.IsMatch(localPart) && !domainExpression.IsMatch(domainPart))
                {
                    throw new Exception("invalid string");
                }

                if (domainPart.StartsWith(".") ^ domainPart.StartsWith("-") ^ domainPart.EndsWith(".") ^ domainPart.EndsWith("-"))
                {
                    throw new Exception("invalid string");
                }

                _email = value;


            }


        } /*email contians to parts: local-part and domain part. They each need validation which can be read in the file.
                                           * My idea is to split the string in and validation on those to string. then put them back together.
                                           * A domain must also include a period(punktum)
                                           */

        public decimal Balance { get; set; }

        public delegate void UserBalanceNotification(User user, decimal balance);


        /*maybe make the delegate a bool and return either true or false depending on whether the balance is under 50
                                                         By defualt have it be false and return true if under 50.
                  
         */
        /*
        public void InsuffecientBalance(UserBalanceNotification userBalanceNotification)
        {
            userBalanceNotification(, )
            balance = 50;
            string balanceNotif = " ";
            if (user.Balance < balance)
            {
                balanceNotif = $"{user.firstName} Balance under 50 kr.";
            }

        }
        */

        /*Work on this later*/
        public void getHashEqualsMethod()
        {

        }

        public override string ToString()
        {
            return $"{firstName} {lastName} {userName} {email} {id}";
        }


    }
}
