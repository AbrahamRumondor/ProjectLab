using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProjectLab.Model;

namespace ProjectLab.Factory
{
    public class DetailFactory
    {
        public static Detail createDetailOrder(int HeaderID, int ramenId, int ramenQty)
        {
            Detail newDetail = new Detail();
            newDetail.Headerid = HeaderID;
            newDetail.Ramenid = ramenId;
            newDetail.Quantity = ramenQty;

            return newDetail;
        }
    }
}