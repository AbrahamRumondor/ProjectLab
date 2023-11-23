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
    public partial class ManageRamen : System.Web.UI.Page
    {
        UserHandler userHandler = new UserHandler();
        RamenHandler ramenHandler = new RamenHandler();
        RamenRepo ramenRepo = new RamenRepo();

        protected void Page_Load(object sender, EventArgs e)
        {
            string id = Request["id"];
            if (id != null && string.Compare(userHandler.getRole(id).name, "Member") != 0)
            {
                Session["id"] = id;
            }
            else
            {
                Response.Redirect("~/Views/Login.aspx");
            }

            GridView1.DataSource = ramenRepo.getAllRamen();
            GridView1.DataBind();
        }


        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridViewRow row = GridView1.Rows[e.NewEditIndex];
            string id = row.Cells[0].Text.ToString();
            Response.Redirect("~/Views/UpdateRamen.aspx?id=" + Session["id"].ToString() + "&rid=" + id);
        }


        /* in the ramen delete logic, our validation logic is determined only by the existence of the ramen in the transaction. (if exist, then cnt delete, if !exist, safe to delete)
         * We couldnt make any better delete logic because of the deletion of ramen will cause error in the ramenid detail.
         * The other idea that come to our mind is by setting the expire time of the transaction, so when the detail is expired, now we will be able to delete the ramen.
         * Howewer, assuming that adding that feature would violate the assignment requirement, we do not use the feature so this removal logic is the best we can come up with.
         */
        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            GridViewRow row = GridView1.Rows[e.RowIndex];
            string id = row.Cells[0].Text.ToString();

            /*remove ramen*/
            Boolean isRemoved = ramenHandler.DeleteRamen(id);

            if(!isRemoved) ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Delete gagal! Pesanan dengan menu ramen yang ingin dihapus masih belum semuanya ditangani!')", true);
            else Response.Redirect("~/Views/ManageRamen.aspx?id=" + Session["id"].ToString());
        }

        protected void Button_InsertNewRamen_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/InsertRamen.aspx?id=" + Session["id"].ToString());
        }

    }
}