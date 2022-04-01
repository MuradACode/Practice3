using System;
using System.Collections.Generic;
using System.Text;

namespace Practice_3.Interfaces
{
    interface IAccount
    {
        public bool PasswordChecker(string password);
        public void ShowInfo();
    }
}
