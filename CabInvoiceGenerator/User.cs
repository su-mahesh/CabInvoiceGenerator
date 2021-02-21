using System;
using System.Collections.Generic;
using System.Text;

namespace Cab_Invoice_Generator
{
    public class User
    {
        public List<string> users;
        private readonly int idLength = 5;

        public User()
        {
            users = new List<string>();
        }

        public string CreateNewUser()
        {
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var stringChars = new char[idLength];
            var random = new Random();

            for (int i = 0; i < idLength; i++)
            {
                stringChars[i] = chars[random.Next(chars.Length)];
            }
            var userID = new String(stringChars);
            users.Add(userID);
            return userID;
        }
    }
}
