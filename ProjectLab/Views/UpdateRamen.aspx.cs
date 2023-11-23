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
    public partial class UpdateRamen : System.Web.UI.Page
    {
        MeatRepo MeatRepo = new MeatRepo();
        MeatHandler meatHandler = new MeatHandler();
        RamenHandler ramenHandler = new RamenHandler();
        UserHandler userHandler = new UserHandler();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack == false)
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

                int RamenId = Convert.ToInt32(Request["rid"]);

                TextBox_name.Text = ramenHandler.getRamen(RamenId.ToString()).Name;

                DropDownList1.DataSource = MeatRepo.getAllMeatName();
                DropDownList1.SelectedValue = meatHandler.getMeat(ramenHandler.getRamen(RamenId.ToString()).Meatid).name;
                DropDownList1.DataBind();

                TextBox_broth.Text = ramenHandler.getRamen(RamenId.ToString()).Broth;
                TextBox_price.Text = ramenHandler.getRamen(RamenId.ToString()).Price;

                HyperLink1.NavigateUrl = "~/Views/ManageRamen.aspx?id=" + Session["id"].ToString();
            }
        }

        protected void Button_UpdateRamen_Click(object sender, EventArgs e)
        {
            string id = Request["rid"];
            string name = TextBox_name.Text;
            string meat = DropDownList1.SelectedValue.ToString();
            string broth = TextBox_broth.Text;
            string price = TextBox_price.Text;

            if (string.Compare(RamenController.UpdateValidation(id, name, meat, broth, price), "APPROVED") == 0)
            {
                DropDownList1.DataSource = MeatRepo.getAllMeatName();
                DropDownList1.DataBind();
                Response.Redirect("~/Views/ManageRamen.aspx?id=" + Session["id"].ToString());
            }
            else
            {
                printAlert(RamenController.UpdateValidation(id, name, meat, broth, price));
                printAlert("alert('Terdapat kesahalan user dalam input menu baru, mohon diisi ulang!')");
            }
        }

        public void printAlert(string msg)
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", msg, true);
        }
    }
}