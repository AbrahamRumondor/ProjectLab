using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProjectLab.Repository;
using ProjectLab.Factory;
using ProjectLab.Handler;

namespace ProjectLab.Controller
{
    public class UserController
    {

        public static string AccountValidation(string username, string Email, string Gender, int emptyGender, string Password, string PasswordConfirmation)
        {
            UserRepo UserRepo = new UserRepo();
            UserHandler userHandler = new UserHandler();

            int validUsername = UsernameValidation(username);
            Boolean emptyUsername = string.IsNullOrEmpty(username);

            Boolean emptyEmail = string.IsNullOrEmpty(Email);
            int validEmail = EmailValidation(Email, emptyEmail);

            Boolean emptyPassword = string.IsNullOrEmpty(Password);
            Boolean emptyPasswordConfirmation = string.IsNullOrEmpty(PasswordConfirmation);
            int passwordValid = string.Compare(Password, PasswordConfirmation);

            if (validUsername == 1 && validEmail == 1 && emptyGender == 0 && passwordValid == 0 &&
                !emptyUsername && !emptyEmail && !emptyPassword && !emptyPasswordConfirmation)
            {
                if (!userHandler.AccountDoesExist(username, Password))
                {
                    UserRepo.RegisterInDatabase(UserFactory.CreateUser(username, Email, Gender, Password));
                    return "APPROVED";
                }
                else
                {
                    return "alert('Akun dengan username dan password yang sama telah ada, mohon buat dengan nama dan password yang berbeda')";
                }
            }
            else
            {
                return AlertCollections(validUsername, validEmail, emptyGender, passwordValid, emptyPassword, emptyPasswordConfirmation);
            }

        }

        public static string UpdateValidation(string id, string username, string Email, string Gender, int emptyGender, string Password)
        {
            UserRepo UserRepo = new UserRepo();
            UserHandler userHandler = new UserHandler();

            int validUsername = UsernameValidation(username);
            Boolean emptyUsername = string.IsNullOrEmpty(username);

            Boolean emptyEmail = string.IsNullOrEmpty(Email);
            int validEmail = EmailValidation(Email, emptyEmail);

            Boolean emptyPassword = string.IsNullOrEmpty(Password);
            int passwordValid = string.Compare(Password, userHandler.getUser(id).Password);

            if (validUsername == 1 && validEmail == 1 && emptyGender == 0 && passwordValid == 0 &&
                !emptyUsername && !emptyEmail && !emptyPassword)
            {
                userHandler.UpdateAccount(id, username, Email, Gender);
                return "APPROVED";
            }
            else
            {
                return AlertCollections(validUsername, validEmail, emptyGender, 0, emptyPassword, false);
            }

        }

        public static int UsernameValidation(string username)
        {
            if (username.Length >= 5 && username.Length <= 15 && username.All(x => char.IsLetter(x) || char.IsWhiteSpace(x))) return 1;
            else return 0;
        }

        public static int EmailValidation(string Email, Boolean emptyEmail)
        {
            int emailLength = Email.Length;
            if (!emptyEmail && Email[emailLength - 1] == 'm' && Email[emailLength - 2] == 'o' && Email[emailLength - 3] == 'c' && Email[emailLength - 4] == '.') return 1;
            else return 0;
        }

        public static String AlertCollections(int validUsername, int validEmail, int emptyGender, int passwordValid, Boolean emptyPassword, Boolean emptyPasswordConfirmation)
        {
            if (validUsername == 0)
            {
                 return "alert('username masih salah')";
            }

            else if (validEmail == 0)
            {
                return "alert('email masih salah')";
            }

            else if (emptyGender == 1)
            {
                return "alert('gender belum diisi')";
            }

            else if (emptyPassword == true)
            {
                return "alert('password masih kosong')";
            }

            else if (emptyPasswordConfirmation == true)
            {
                return "alert('Password Confirmation masih kosong')";
            }

            else if (passwordValid != 0)
            {
                return "alert('password belum cocok')";
            }

            return null;
        }

    }
}