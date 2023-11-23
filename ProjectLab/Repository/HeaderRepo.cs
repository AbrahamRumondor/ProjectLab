using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProjectLab.Model;

namespace ProjectLab.Repository
{
    public class HeaderRepo
    {
        RaamenDatabaseEntities1 db = new RaamenDatabaseEntities1();

        public void registerNewHeader(Header newHeader)
        {
            db.Headers.Add(newHeader);
            db.SaveChanges();
        }

        public List<Header> getAllHeader()
        {
            List<Header> allHeader = db.Headers.ToList();
            return allHeader;
        }

        public void updateDatabase()
        {
            db.SaveChanges();
        }

    }
}