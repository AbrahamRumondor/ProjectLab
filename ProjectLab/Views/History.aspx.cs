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
    public partial class History : System.Web.UI.Page
    {
        UserHandler userHandler = new UserHandler();
        HeaderHandler headerHandler = new HeaderHandler();

        protected void Page_Load(object sender, EventArgs e)
        {
            string id = Request["id"];
            if (id != null && (string.Compare(userHandler.getRole(id).name, "Staff") != 0))
            {
                Session["id"] = id;
            }
            else
            {
                Response.Redirect("~/Views/Login.aspx");
            }

            if ((string.Compare(userHandler.getRole(id).name, "Member") == 0 ))
            {
                GridViewMENU.DataSource = headerHandler.getCustomerHeader(Convert.ToInt32(id));
            }

            if ((string.Compare(userHandler.getRole(id).name, "Admin") == 0))
            {
                GridViewMENU.DataSource = headerHandler.getAdminHeader();
            }

            GridViewMENU.DataBind();
            if (GridViewMENU.Rows.Count > 0) TransactionStatus.Visible = false;
        }

        protected void GridViewMENU_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridViewRow row = GridViewMENU.Rows[e.NewEditIndex];
            string id = row.Cells[0].Text.ToString();
            Response.Redirect("~/Views/TransactionDetail.aspx?id=" + Session["id"].ToString() + "&tid=" + id);
        }
    }
}