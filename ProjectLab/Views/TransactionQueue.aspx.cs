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
    public partial class TransactionQueue : System.Web.UI.Page
    {
        HeaderRepo Header = new HeaderRepo();
        UserHandler userHandler = new UserHandler();
        HeaderHandler headerHandler = new HeaderHandler();
        protected void Page_Load(object sender, EventArgs e)
        {
            string id = Request["id"];
            if (id != null && (string.Compare(userHandler.getRole(id).name, "Member") != 0))
            {
                Session["id"] = id;
            }
            else
            {
                Response.Redirect("~/Views/Login.aspx");
            }

            GridViewList.DataSource = Header.getAllHeader();

            GridViewList.DataBind();
            if (GridViewList.Rows.Count > 0) TransactionStatus.Visible = false;
        }

        protected void GridViewList_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridViewRow row = GridViewList.Rows[e.NewEditIndex];
            string id = row.Cells[0].Text.ToString();

            if (headerHandler.getHeader(Convert.ToInt32(id)).Staffid == -1)
            {
                Response.Redirect("~/Views/QueueDetail.aspx?id=" + Session["id"].ToString() + "&tid=" + id + "&hdl=" + 0);
            } else
            {
                Response.Redirect("~/Views/QueueDetail.aspx?id=" + Session["id"].ToString() + "&tid=" + id + "&hdl=" + 1);
            }
        }
    }
}