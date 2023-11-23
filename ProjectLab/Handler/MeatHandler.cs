using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProjectLab.Model;
using ProjectLab.Repository;

namespace ProjectLab.Handler
{
    public class MeatHandler
    {
        MeatRepo meatRepo = new MeatRepo();

        public Meat getMeat(string meat)
        {
            Meat meatList = meatRepo.getAllMeat().Where(x => string.Compare(meat, x.name.ToString()) == 0).ToList().FirstOrDefault();
            return meatList;
        }

        public Meat getMeat(int id)
        {
            Meat meatList = meatRepo.getAllMeat().Where(x => id == x.id).ToList().FirstOrDefault();
            return meatList;
        }
    }
}