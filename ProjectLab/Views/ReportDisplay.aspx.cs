using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ProjectLab.Repository;
using ProjectLab.Handler;
using ProjectLab.Reports;
using ProjectLab.Model;

namespace ProjectLab.Views
{
    public partial class ReportDisplay : System.Web.UI.Page
    {

        protected void Page_Init(object sender, EventArgs e)
        {
            CrystalReport1 report = new CrystalReport1();
            CrystalReportViewer1.ReportSource = report;

            DataSet1 data = loadData(headerHandler.getAdminHeader());
            report.SetDataSource(data);
        }

        UserHandler userHandler = new UserHandler();
        RamenHandler ramenHandler = new RamenHandler();
        RamenRepo ramenRepo = new RamenRepo();
        DetailHandler detailHandler = new DetailHandler();
        HeaderRepo headerRepo = new HeaderRepo();
        HeaderHandler headerHandler = new HeaderHandler();
        protected void Page_Load(object sender, EventArgs e)
        {
                string id = Request["id"];
                if (id != null && (string.Compare(userHandler.getRole(id).name, "Admin") == 0))
                {
                    Session["id"] = id;
                }
                else
                {
                    Response.Redirect("~/Views/Login.aspx");
                }
        }

        public DataSet1 loadData(List<Header> allHeader)
        {
            DataSet1 newData = new DataSet1();

            var headerTable = newData.Header;
            var detailTable = newData.Detail;
            var totalTable = newData.Totalincome;

            int grandTotal = 0;

            foreach (Header h in allHeader)
            {
                var newHeaderRow = headerTable.NewRow();
                newHeaderRow["id"] = h.id;
                newHeaderRow["Customer"] = h.User.Username;

                var getUser = userHandler.getUser(h.Staffid.ToString());

                newHeaderRow["Staffid"] = getUser.Username + " (" + getUser.Role.name +")";
                newHeaderRow["Date"] = h.Date.ToString();

                int subTotal = 0;
                foreach (Detail d in detailHandler.getDetail(h.id))
                {
                    subTotal += d.Quantity * Convert.ToInt32(d.Raman.Price);
                }

                grandTotal += subTotal;
                newHeaderRow["Subtotal"] = "$ " + subTotal.ToString();
                headerTable.Rows.Add(newHeaderRow);


                foreach (Detail d in detailHandler.getDetail(h.id))
                {
                    var newDetailRow = detailTable.NewRow();
                    newDetailRow["Headerid"] = d.Headerid;
                    newDetailRow["Ramen"] = d.Raman.Name;
                    newDetailRow["Meat"] = d.Raman.Meat.name;
                    newDetailRow["Broth"] = d.Raman.Broth;
                    newDetailRow["Quantity"] = d.Quantity;
                    newDetailRow["DetailTotal"] = "$ " + (d.Quantity * Convert.ToInt32(d.Raman.Price)).ToString();

                    detailTable.Rows.Add(newDetailRow);
                }
            }

            var newIncomeRow = totalTable.NewRow();
            newIncomeRow["GrandTotal"] = "$ " + grandTotal.ToString();
            totalTable.Rows.Add(newIncomeRow);

            return newData;
        }
    }
}