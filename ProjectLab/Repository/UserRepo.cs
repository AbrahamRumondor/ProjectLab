using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProjectLab.Model;

namespace ProjectLab.Repository
{
    public class UserRepo
    {
        RaamenDatabaseEntities1 db = new RaamenDatabaseEntities1();

        public void RegisterInDatabase(User newAccount)
        {
            db.Users.Add(newAccount);
            db.SaveChanges();
        }

        public void UpdateDatabase()
        {
            db.SaveChanges();
        }

        public List<User> Users()
        {
            List<User> allUser = (from User in db.Users select User).ToList();
            return allUser;
        } 
    }
}