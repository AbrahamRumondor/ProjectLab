using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProjectLab.Model;
using ProjectLab.Repository;

namespace ProjectLab.Repository
{
    public class DetailRepo
    {
        RaamenDatabaseEntities1 db = new RaamenDatabaseEntities1();

        public void registerNewDetailOrder(Detail newDetail)
        {
            db.Details.Add(newDetail);
            db.SaveChanges();
        }

        public List<Detail> getAllDetail()
        {
            List<Detail> detailList = db.Details.ToList();
            return detailList;
        }

    }
}