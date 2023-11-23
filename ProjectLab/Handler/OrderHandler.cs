using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProjectLab.Repository;

namespace ProjectLab.Handler
{
    public class OrderHandler
    {
        RamenHandler ramenHandler = new RamenHandler();

        public int ramenID { get; set; }
        public int ramenQuantity { get; set; }
        public string ramenMeat { get; set; }
        public string ramenName { get; set; }
        public string ramenBroth { get; set; }
        public string ramenPrice { get; set; }


        public void setNewRamenOrder(int ID)
        {
            ramenID = ID;
            ramenQuantity = 1;
            ramenMeat = ramenHandler.getRamen(ID.ToString()).Meat.name;
            ramenName = ramenHandler.getRamen(ID.ToString()).Name;
            ramenBroth = ramenHandler.getRamen(ID.ToString()).Broth;
            ramenPrice = ramenHandler.getRamen(ID.ToString()).Price;
        }

        public void plusOneOrder()
        {
            ramenQuantity++;
        }

        public void minusOneOrder()
        {
            ramenQuantity--;
        }
    }
}