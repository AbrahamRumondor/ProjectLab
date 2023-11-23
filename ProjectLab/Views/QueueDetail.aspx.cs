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
    public partial class QueueDetail : System.Web.UI.Page
    {
        UserHandler userHandler = new UserHandler();
        HeaderHandler headerHandler = new HeaderHandler();
        DetailHandler detailHandler = new DetailHandler();

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

            int tid = Convert.ToInt32(Request["tid"]);

            Label_HeaderId.Text = tid.ToString();
            Label_Customer.Text = headerHandler.getHeader(tid).User.Username;
            Label_Staff.Text = headerHandler.getHeader(tid).Staffid.ToString();
            Label_Date.Text = headerHandler.getHeader(tid).Date.ToString();


            GridViewList.DataSource = detailHandler.getDetail(tid);

            GridViewList.DataBind();

            Label_totalHarga.Text = "$ " + detailHandler.getDetailTotalPrice(tid).ToString();

            int hdl = Convert.ToInt32(Request["hdl"]);
            if (hdl == 1)
            {
                Button_Handle.Visible = false;
                Label_handle.Text = "The order has been handled";
                Label_handle.Visible = true;
            }

            HyperLink_TH.NavigateUrl = "~/Views/TransactionQueue.aspx?id=" + Session["id"].ToString();
        }

        protected void Button_Handle_Click(object sender, EventArgs e)
        {
            int tid = Convert.ToInt32(Request["tid"]);
            int id = Convert.ToInt32(Request["id"]);
            headerHandler.updateStaff(tid, id);
            Response.Redirect("~/Views/TransactionQueue.aspx?id=" + Session["id"].ToString());
        }

    }
}