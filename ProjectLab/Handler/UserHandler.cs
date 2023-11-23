using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProjectLab.Model;
using ProjectLab.Repository;

namespace ProjectLab.Handler
{
    public class UserHandler
    {
        UserRepo User_Repo = new UserRepo();

        public void UpdateAccount(string id, string username, string email, string gender)
        {
            User upAccount = User_Repo.Users().Where(x => string.Compare(id, x.id.ToString()) == 0).ToList().FirstOrDefault();
            upAccount.Username = username;
            upAccount.Email = email;
            upAccount.Gender = gender;

            User_Repo.UpdateDatabase();
        }

        public List<User> usernameInDatabase(string username)
        {
            List<User> usernameList = User_Repo.Users().Where(x => string.Compare(username, x.Username.ToString()) == 0).ToList();
            return usernameList;
        }

        public Boolean AccountDoesExist(string username, string password)
        {
            User accountDoesExist = getUser(username, password);

            if (accountDoesExist == null) return false;
            else return true;
        }

        public User UserAccount(string username, string password)
        {
            List<User> usernameList = usernameInDatabase(username);
            User accountExist = usernameList.Where(x => string.Compare(password, x.Password.ToString()) == 0).FirstOrDefault();

            return accountExist;
        }

        public User getUser(string username, string password)
        {
            User accountExist = UserAccount(username, password);
            return accountExist;
        }

        public String getUserId(string username, string password)
        {
            User accountDoesExist = UserAccount(username, password);
            return accountDoesExist.id.ToString();
        }

        public User getUser(string id)
        {
            User accountExist = User_Repo.Users().Where(x => string.Compare(id, x.id.ToString()) == 0).ToList().FirstOrDefault();
            return accountExist;
        }

        public List<User> getAllCustomer()
        {
            List<User> customerList = User_Repo.Users().Where(x => string.Compare(x.Role.name, "Member") == 0).ToList();
            return customerList;
        }

        public List<User> getAllStaff()
        {
            List<User> customerList = User_Repo.Users().Where(x => string.Compare(x.Role.name, "Staff") == 0).ToList();
            return customerList;
        }

        public User UserIDinDatabase(string ID)
        {
            User IDlist = User_Repo.Users().Where(x => string.Compare(ID, x.id.ToString()) == 0).ToList().FirstOrDefault();
            return IDlist;
        }

        /* this method belongs to this userhandler because the role we want to get here is something belongs to a user, so we dont get the role from the database, because its something we grab 
           from the user itself. */
        public Role getRole(string id)
        {
            User accountDoesExist = getUser(id);
            return accountDoesExist.Role;
        }
    }
}