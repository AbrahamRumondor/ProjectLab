using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProjectLab.Model;

namespace ProjectLab.Factory
{
    public class UserFactory
    {
        public static User CreateUser(string username, string email, string gender, string password)
        {
            User newAccount = new User();

            newAccount.Username = username;
            newAccount.Email = email;
            newAccount.Gender = gender;
            newAccount.Password = password;
            newAccount.Roleid = 2;

            return newAccount;
        }
    }
}