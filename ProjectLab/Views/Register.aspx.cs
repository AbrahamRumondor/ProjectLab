using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ProjectLab.Repository;
using ProjectLab.Factory;
using ProjectLab.Handler;
using ProjectLab.Controller;

namespace ProjectLab.Views
{
    // *ASSUMPTION*
    // on working on this project. it is assumed that when user creating an account, the account will be automatically considered as 
    // a member. If, the new user role is either staff or admin, then, it has to be assigned manually in the database.

    public partial class Register : System.Web.UI.Page
    {
        UserRepo UserRepo = new UserRepo();
        UserHandler userHandler = new UserHandler();
        
        protected void Page_Load(object sender, EventArgs e)
        {
            HttpCookie cookie = Request.Cookies["ActiveUser"];
            if (cookie != null)
            {
                Response.Redirect("~/Views/Home.aspx?id=" + cookie["id"].ToString());
            }
        }

        protected void Button_register_Click(object sender, EventArgs e)
        {
            string username = TextBox_username.Text.ToString();
            
            string Email = TextBox_email.Text.ToLower().ToString();

            int emptyGender = 0;
            string Gender = null;
            if (Male.Checked) Gender = "Male";
            else if (Female.Checked) Gender = "Female";
            else if (Male.Checked == false && Female.Checked == false) emptyGender = 1;

            string Password = TextBox_password.Text.ToString();
            string PasswordConfirmation = TextBox_passwordConfirmation.Text.ToString();

            if(string.Compare(UserController.AccountValidation(username, Email, Gender, emptyGender, Password, PasswordConfirmation), "APPROVED") == 0) Response.Redirect("~/Views/Login.aspx");
            else
            {
                printAlert(UserController.AccountValidation(username, Email, Gender, emptyGender, Password, PasswordConfirmation));
                printAlert("alert('Tolong cek kembali form register anda, masih terdapat kesalahan atau bagian yang mungkin belum terisi. Terima Kasih')");
            }

        }

        public void printAlert(string msg)
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", msg, true);
        }

    }
}