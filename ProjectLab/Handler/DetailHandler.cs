using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProjectLab.Model;
using ProjectLab.Repository;
using ProjectLab.Factory;

namespace ProjectLab.Handler
{
    public class DetailHandler
    {
        DetailRepo detail_Repo = new DetailRepo();
        public List<Detail> getDetail(int Headerid)
        {
            List<Detail> detailList = detail_Repo.getAllDetail().Where(x => x.Headerid == Headerid).ToList();
            return detailList;
        }

        public int getDetailTotalPrice(int Headerid)
        {
            List<Detail> detailList = getDetail(Headerid);
            int totalPrice = 0;
            detailList.ForEach(delegate (Detail i)
            {
                totalPrice += Convert.ToInt32(i.Raman.Price) * i.Quantity;
            });
            return totalPrice;
        }

        public List<Detail> getRamenValidation(int Ramenid)
        {
            List<Detail> detailList = detail_Repo.getAllDetail().Where(x => x.Ramenid == Ramenid).ToList();
            List<Detail> validList = detailList.Where(x => x.Header.Staffid == -1).ToList();
            return validList;
        }

    }
}