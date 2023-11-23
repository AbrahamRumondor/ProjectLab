using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ProjectLab.Handler;

namespace ProjectLab.Views
{
    public partial class Login : System.Web.UI.Page
    {
        UserHandler userHandler = new UserHandler();
        protected void Page_Load(object sender, EventArgs e)
        {
            HttpCookie cookie = Request.Cookies["ActiveUser"];
            if (cookie != null)
            {
                Response.Redirect("~/Views/Home.aspx?id=" + cookie["id"].ToString());
            }
        }

        protected void Button_login_Click(object sender, EventArgs e)
        {
            string username = TextBox_username.Text.ToString();
            string Password = TextBox_password.Text.ToString();

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(Password))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Tolong isi username dan password')", true);
            }
            else
            {
                Boolean accountDoesExist = userHandler.AccountDoesExist(username, Password);

                if (accountDoesExist)
                {
                    if (RememberMe.Checked == true)
                    {
                        HttpCookie cookie = new HttpCookie("ActiveUser");
                        
                        cookie["id"] = userHandler.getUserId(username, Password).ToString();
                        cookie.Expires = DateTime.MaxValue;
                        Response.Cookies.Add(cookie);
                    } else
                    {
                        Session["id"] = userHandler.getUserId(username, Password);
                    }
                    Response.Redirect("~/Views/Home.aspx?id=" + userHandler.getUserId(username, Password));
                } 
                else
                {
                   ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('username atau password salah')", true);
                }
            }
        }
    }
}