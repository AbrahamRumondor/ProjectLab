using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ProjectLab.Handler;

namespace ProjectLab.Views
{
    public partial class Navbar : System.Web.UI.MasterPage
    {
        UserHandler userHandler = new UserHandler();
        protected void Page_Load(object sender, EventArgs e)
        {
                string id = Session["id"].ToString();
                if (id == null)
                {
                    Response.Redirect("~/Views/Login.aspx");
                }

                String userRole = userHandler.UserIDinDatabase(id).Role.name;

                if (string.Compare("Member", userRole) == 0)
                {
                    orderRamen_Button.Visible = true;
                    history_Button.Visible = true;
                    profile_Button.Visible = true;

                }
                else if (string.Compare("Staff", userRole) == 0)
                {
                    manageRamen_Button.Visible = true;
                    orderQueue_Button.Visible = true;
                    profile_Button.Visible = true;
                }
                else if (string.Compare("Admin", userRole) == 0)
                {
                    manageRamen_Button.Visible = true;
                    orderQueue_Button.Visible = true;
                    profile_Button.Visible = true;
                    history_Button.Visible = true;
                    report_Button.Visible = true;
                }
        }

        
        protected void home_Button_Click(object sender, EventArgs e)
        {
            string id = Request["id"];
            Response.Redirect("~/Views/Home.aspx?id=" + Session["id"].ToString());
        }

        protected void logout_Button_Click(object sender, EventArgs e)
        {
            HttpCookie cookie = new HttpCookie("ActiveUser");
            cookie.Expires = DateTime.Now.AddDays(-1);
            Response.Cookies.Add(cookie);
            Response.Redirect("~/Views/Login.aspx");
        }

        protected void manageRamen_Button_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/ManageRamen.aspx?id=" + Session["id"].ToString());
        }

        protected void profile_Button_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/UpdateProfile.aspx?id=" + Session["id"].ToString());
        }

        protected void orderRamen_Button_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/OrderRamen.aspx?id=" + Session["id"].ToString());
        }

        protected void history_Button_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/History.aspx?id=" + Session["id"].ToString());
        }

        protected void orderQueue_Button_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/TransactionQueue.aspx?id=" + Session["id"].ToString());
        }

        protected void report_Button_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/ReportDisplay.aspx?id=" + Session["id"].ToString());
        }
    }
}