using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace F_klubben_stregsystem
{
    class User
    {
        public User(string FirstName, string LastName, string UserName)
        {
            firstName = FirstName;
            lastName = LastName;
            userName = UserName;
            ID += ID++;
        }

        private string _userName, _email;
        
        public int ID { get; set; }
        public string firstName
        {
            get
            {
                return firstName;
            }
            set
            {
                if (firstName == null)
                {
                    throw new NullReferenceException();
                }
            }
        }
        public string lastName
        {
            get
            {
                return lastName;
            }
            set
            {
                if (lastName == null)
                {
                    throw new NullReferenceException();
                }
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

                if (usernameExpression.IsMatch(value))
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

                bool isFirstCharletter = char.IsLetter(domainPart, 0);
                

                if (localPartExpression.IsMatch(localPart))
                {
                    throw new Exception("invalid string");
                }

                if (domainExpression.IsMatch(domainPart) && !isFirstCharletter && domainPart.EndsWith(".") && domainPart.EndsWith("-"))
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

        /*Figure out the delegate and toString() parts*/

        public override string ToString()
        {
            return $"{firstName}{lastName}{userName}";
        }

    }
}
