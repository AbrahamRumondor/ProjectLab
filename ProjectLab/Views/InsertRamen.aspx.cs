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
    public partial class InsertRamen : System.Web.UI.Page
    {
        RamenRepo RamenRepo = new RamenRepo();
        MeatRepo MeatRepo = new MeatRepo();
        MeatHandler meatHandler = new MeatHandler();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(IsPostBack == false)
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

                DropDownList1.DataSource = MeatRepo.getAllMeatName();
                DropDownList1.DataBind();

                HyperLink1.NavigateUrl = "~/Views/ManageRamen.aspx?id=" + Session["id"].ToString();
            }
        }

        protected void Button_register_Click(object sender, EventArgs e)
        {
            string name = TextBox_name.Text;
            string meat = DropDownList1.SelectedValue.ToString();
            string broth = TextBox_broth.Text;
            string price = TextBox_price.Text;

            if (string.Compare(RamenController.RamenValidation(name, meat, broth, price), "APPROVED") == 0)
            {
                DropDownList1.DataSource = MeatRepo.getAllMeatName();
                DropDownList1.DataBind();
                Response.Redirect("~/Views/ManageRamen.aspx?id=" + Session["id"].ToString());
            }
            else
            {
                printAlert(RamenController.RamenValidation(name, meat, broth, price));
                printAlert("alert('Terdapat kesahalan user dalam input menu baru, mohon diisi ulang!')");
            }
        }

        public void printAlert(string msg)
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", msg, true);
        }
    }
}