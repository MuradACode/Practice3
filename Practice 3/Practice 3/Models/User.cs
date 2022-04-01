using Practice_3.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Practice_3.Models
{
    class User : IAccount
    {
        public static int _idCounter = 0;
        private string _email;
        public int Id { get; private set; }
        public string FullName { get; set; }
        public string Email { get { return _email; } 
            set 
            {
                if (value.Contains("@") && value.Contains("."))
                {
                    _email = value;
                }
            } 
        }
        public string Password { get; set; }
        private User()
        {
            Id = ++_idCounter;
        }
        public User(string name, string email, string password) : this()
        {
            FullName = name;
            Email = email;
            Password = password;
        }
        public bool PasswordChecker(string password)
        {
            bool checkedPassword = false;
            char[] check = password.ToCharArray();
            if (check.Length > 7)
            {
                foreach (char item in check)
                {
                    if (item < 91 || item > 64)
                    {
                        foreach (char item1 in check)
                        {
                            if (item < 123 || item > 96)
                            {
                                foreach (char item2 in check)
                                {
                                    if (item < 58 || item > 47)
                                    {
                                        checkedPassword = true;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            return checkedPassword;
        }

        public void ShowInfo()
        {
            Console.WriteLine($"ID: {Id}\nFullname: {FullName}\nEmail: {Email}");
        }
    }
}
