using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ProjectLab.Repository;
using ProjectLab.Handler;

namespace ProjectLab.Views
{
    public partial class Home : System.Web.UI.Page
    {
        UserHandler userHandler = new UserHandler();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack == false)
            {
                string id = Request["id"];
                if (id != null)
                {
                    Label_username.Text = userHandler.UserIDinDatabase(id).Username;
                    Label_role.Text = userHandler.UserIDinDatabase(id).Role.name;
                    Session["id"] = id;
                }
                else
                {
                    Response.Redirect("~/Views/Login.aspx");
                }

                if (string.Compare(userHandler.getUser(id).Role.name, "Staff") == 0)
                {
                    GridView_Customer.Visible = true;
                    GridView_Customer.DataSource = userHandler.getAllCustomer();
                    GridView_Customer.DataBind();
                }

                if (string.Compare(userHandler.getUser(id).Role.name, "Admin") == 0)
                {
                    GridView_Customer.Visible = true;
                    GridView_Customer.DataSource = userHandler.getAllCustomer();
                    GridView_Customer.DataBind();

                    GridView_Staff.Visible = true;
                    GridView_Staff.DataSource = userHandler.getAllStaff();
                    GridView_Staff.DataBind();
                }
            }


        }

    }
}