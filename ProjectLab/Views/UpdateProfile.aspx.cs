using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ProjectLab.Repository;
using ProjectLab.Handler;
using ProjectLab.Controller;

namespace ProjectLab.Views
{
    public partial class UpdateProfile : System.Web.UI.Page
    {
        UserRepo UserRepo = new UserRepo();
        UserHandler userHandler = new UserHandler();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack == false)
            {
                string id = Request["id"];
                if (id != null)
                {
                    Session["id"] = id;
                }
                else
                {
                    Response.Redirect("~/Views/Login.aspx");
                }

                /*code display current profile data*/
                TextBox_username.Text = userHandler.getUser(id).Username;
                TextBox_email.Text = userHandler.getUser(id).Email;
                if(string.Compare(userHandler.getUser(id).Gender, "Male") == 0)
                {
                    Male.Checked = true;
                    Female.Checked = false;
                } else
                {
                    Male.Checked = false;
                    Female.Checked = true;
                }
                TextBox_password.Text = null;
            }
        }

        protected void Button_update_Click(object sender, EventArgs e)
        {
            string id = Request["id"];

            string username = TextBox_username.Text.ToString();
            string Email = TextBox_email.Text.ToLower().ToString();


            int emptyGender = 0;
            string Gender = null;
            if (Male.Checked) Gender = "Male";
            else if (Female.Checked) Gender = "Female";
            else if (Male.Checked == false && Female.Checked == false) emptyGender = 1;

            string Password = TextBox_password.Text.ToString();

            if (string.Compare(UserController.UpdateValidation(id,username, Email, Gender, emptyGender, Password), "APPROVED") == 0) Response.Redirect("~/Views/Home.aspx?id=" + Session["id"].ToString());
            else
            {
                printAlert(UserController.UpdateValidation(id, username, Email, Gender, emptyGender, Password));
                printAlert("alert('Tolong cek kembali form register anda, masih terdapat kesalahan atau bagian yang mungkin belum terisi. Terima Kasih')");
            }

        }

        public void printAlert(string msg)
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", msg, true);
        }
    }
}