using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ProjectLab.Repository;
using ProjectLab.Handler;
using ProjectLab.Factory;

namespace ProjectLab.Views
{
    public partial class OrderRamen : System.Web.UI.Page
    {
        DetailRepo DetailRepo = new DetailRepo();
        UserHandler userHandler = new UserHandler();
        HeaderHandler headerHandler = new HeaderHandler();
        RamenRepo ramenRepo = new RamenRepo();


        protected void Page_Load(object sender, EventArgs e)
        {
            string id = Request["id"];
            if (id != null && string.Compare(userHandler.getRole(id).name, "Member") == 0 )
            {
                Session["id"] = id;
            }
            else
            {
                Response.Redirect("~/Views/Login.aspx");
            }
            GridViewMENU.DataSource = ramenRepo.getAllRamen();
            GridViewMENU.DataBind();

            
            List<OrderHandler> Order = (List<OrderHandler>)Session["OrderCartSession"];
            GridViewCART.DataSource = Order;
            GridViewCART.DataBind();

            if (Order != null)
            { 
                cartStatus.Visible = false;
                int totalPrice = 0;
                Order.ForEach(delegate(OrderHandler i)
                {
                    totalPrice += Convert.ToInt32(i.ramenPrice) * i.ramenQuantity;
                });
                Label_totalHarga.Text = "$ " + totalPrice.ToString();
            }
            if(Order == null || Order.Count < 1) cartStatus.Visible = true;
        }

        protected void GridViewMENU_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridViewRow row = GridViewMENU.Rows[e.NewEditIndex];
            int id = Convert.ToInt32(row.Cells[0].Text.ToString());

            List<OrderHandler> OrderCart = (List<OrderHandler>)Session["OrderCartSession"];

            if (OrderCart != null)
            {
                OrderHandler RamenOrder = OrderCart.Find(delegate (OrderHandler i)
                {
                    return i.ramenID == id;
                });

                if (RamenOrder == null)
                {
                    OrderHandler newOrder = new OrderHandler();
                    newOrder.setNewRamenOrder(id);
                    OrderCart.Add(newOrder);
                }
                else
                {
                    int index = OrderCart.FindIndex(delegate (OrderHandler i)
                    {
                        return i.ramenID == id;
                    });

                    OrderCart[index].plusOneOrder();                }
            } else
            {
                OrderCart = new List<OrderHandler>();
                OrderHandler newOrder = new OrderHandler();
                newOrder.setNewRamenOrder(id);
                OrderCart.Add(newOrder);
            }
            Session["OrderCartSession"] = OrderCart;

            Response.Redirect("~/Views/OrderRamen.aspx?id=" + Session["id"].ToString());
        }

        protected void GridViewCART_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridViewRow row = GridViewCART.Rows[e.NewEditIndex];
            int id = Convert.ToInt32(row.Cells[0].Text.ToString());

            List<OrderHandler> OrderCart = (List<OrderHandler>)Session["OrderCartSession"];

            int index = OrderCart.FindIndex(delegate (OrderHandler i)
            {
                return i.ramenID == id;
            });

            if (index >= 0)
            {
                if (OrderCart[index].ramenQuantity > 1) 
                {
                    OrderCart[index].minusOneOrder();                }
                else OrderCart.RemoveAt(index);
            } else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Delete gagal!')", true);
            }

            Session["OrderCartSession"] = OrderCart;

            Response.Redirect("~/Views/OrderRamen.aspx?id=" + Session["id"].ToString());
        }

        protected void Button_ClearAll_Click(object sender, EventArgs e)
        {
            List<OrderHandler> OrderCart = (List<OrderHandler>)Session["OrderCartSession"];
            OrderCart.Clear();
            Session["OrderCartSession"] = OrderCart;
            Response.Redirect("~/Views/OrderRamen.aspx?id=" + Session["id"].ToString());
        }

        protected void Button_BuyAll_Click(object sender, EventArgs e)
        {  
            List<OrderHandler> OrderCart = (List<OrderHandler>)Session["OrderCartSession"];
            if (OrderCart != null && OrderCart.Count >= 1)
            {
                HeaderRepo newHeader = new HeaderRepo();
                string CustomerId = Request["id"];
                newHeader.registerNewHeader(HeaderFactory.createHeader(CustomerId));

                OrderCart.ForEach(delegate (OrderHandler i)
                {
                    DetailRepo.registerNewDetailOrder(DetailFactory.createDetailOrder(headerHandler.getLatestHeader(Convert.ToInt32(CustomerId)).id, i.ramenID, i.ramenQuantity));
                });
            }

            OrderCart.Clear();
            Session["OrderCartSession"] = OrderCart;

            Response.Redirect("~/Views/OrderRamen.aspx?id=" + Session["id"].ToString());

        }

    }
}