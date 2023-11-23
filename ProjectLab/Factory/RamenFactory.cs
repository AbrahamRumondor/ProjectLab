using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProjectLab.Model;
using ProjectLab.Repository;
using ProjectLab.Handler;


namespace ProjectLab.Factory
{
    public class RamenFactory
    {
        static MeatRepo meatRepo = new MeatRepo();
        public static Raman CreateRamen(string name, Meat meat, string broth, string price)
        {
            Raman newRamen = new Raman();

            newRamen.Name = name;
            newRamen.Meatid = meat.id;
            newRamen.Broth = broth;
            newRamen.Price = price;

            return newRamen;
        }
    }
}