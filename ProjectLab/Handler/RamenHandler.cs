using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProjectLab.Model;
using ProjectLab.Repository;

namespace ProjectLab.Handler
{
    public class RamenHandler
    {
        RamenRepo ramen_Repo = new RamenRepo();
        DetailHandler detail_Handler = new DetailHandler();
        public Boolean DeleteRamen(string id)
        {
            Raman RegisteredRamen = getRamen(id);

            if(detail_Handler.getRamenValidation(RegisteredRamen.id).Count > 0)
            {
                return false;
            }

            return ramen_Repo.DeleteDatabaseItem(RegisteredRamen);
        }

        public void UpdateRamen(string id, string name, Meat meat, string broth, string price)
        {
            Raman RegisteredRamen = getRamen(id);

            RegisteredRamen.Name = name;
            RegisteredRamen.Meatid = meat.id;
            RegisteredRamen.Broth = broth;
            RegisteredRamen.Price = price;

            ramen_Repo.UpdateDatabase();
        }

        public Raman getRamen(string id)
        {
            Raman Ramen = ramen_Repo.getAllRamen().Where(x => string.Compare(id, x.id.ToString()) == 0).ToList().FirstOrDefault();
            return Ramen;
        }

    }
}