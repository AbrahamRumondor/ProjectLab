using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProjectLab.Model;

namespace ProjectLab.Repository
{
    public class MeatRepo
    {
        RaamenDatabaseEntities1 db = new RaamenDatabaseEntities1();

        public List<string> getAllMeatName()
        {
            List<string> meatList = (from Meat in db.Meats select Meat.name).ToList();
            return meatList;
        }

        public List<Meat> getAllMeat()
        {
            List<Meat> meatList = (from Meat in db.Meats select Meat).ToList();
            return meatList;
        }
    }
}