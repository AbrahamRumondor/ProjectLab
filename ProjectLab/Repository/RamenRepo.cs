using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProjectLab.Model;
using ProjectLab.Repository;

namespace ProjectLab.Repository
{
    public class RamenRepo
    {
        RaamenDatabaseEntities1 db = new RaamenDatabaseEntities1();
        MeatRepo MeatRepo = new MeatRepo();

        public List<Raman> getAllRamen()
        {
            List<Raman> ramenList = (from Raman in db.Ramen select Raman).ToList();
            return ramenList;
        }

        public void RegisterNewRamen(Raman newRamen)
        {
            db.Ramen.Add(newRamen);
            db.SaveChanges();
        }

        public Boolean DeleteDatabaseItem(Raman RegisteredRamen)
        {
            if (RegisteredRamen == null) return false;

            db.Ramen.Remove(RegisteredRamen);
            db.SaveChanges();

            return true;
        }

        public void UpdateDatabase()
        {
            db.SaveChanges();
        }

    }
}