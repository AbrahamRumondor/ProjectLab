using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProjectLab.Repository;
using ProjectLab.Handler;
using ProjectLab.Factory;
using ProjectLab.Handler;

namespace ProjectLab.Controller
{
    public class RamenController
    {

        public static string RamenValidation(string name, string meat, string broth, string p)
        {
            MeatHandler meatHandler = new MeatHandler();
            RamenRepo ramenRepo = new RamenRepo();

            if (string.Compare(p, "") == 0) return "alert('price masih belum diisi')";
            else
            {
                int price = Convert.ToInt32(p);
                Boolean validName = name.Contains("Ramen");
                Boolean validPrice = false;
                if (price >= 3000) validPrice = true;
                if ((string.Compare(name, "") != 0) && validName && validPrice && meat != null && (string.Compare(broth, "") != 0))
                {
                    ramenRepo.RegisterNewRamen(RamenFactory.CreateRamen(name, meatHandler.getMeat(meat), broth, price.ToString()));
                    return "APPROVED";
                }
                else
                {
                    return AlertCollection(name, validName, broth, validPrice);
                }
            }
        }

        public static string UpdateValidation(string id, string name, string meat, string broth, string p)
        {
            MeatHandler meatHandler = new MeatHandler();
            RamenHandler ramenHandler = new RamenHandler();
            RamenRepo ramenRepo = new RamenRepo();

            if (string.Compare(p, "") == 0) return "alert('price masih belum diisi')";
            else
            {
                int price = Convert.ToInt32(p);
                Boolean validName = name.Contains("Ramen");
                Boolean validPrice = false;
                if (price >= 3000) validPrice = true;

                if ((string.Compare(name, "") != 0) && validName && validPrice && meat != null && (string.Compare(broth, "") != 0))
                {
                    ramenHandler.UpdateRamen(id, name, meatHandler.getMeat(meat), broth, price.ToString());
                    return "APPROVED";
                }
                else
                {
                    return AlertCollection(name, validName, broth, validPrice);
                }
            }
        }

        public static string AlertCollection(string name, Boolean validName, string broth, Boolean validPrice)
        {
            if ((string.Compare(name, "") == 0) || !validName) return "alert('Nama harus mengandung \"Ramen\" ')";
            else if ((string.Compare(broth, "") == 0)) return "alert('Broth harus diisi')";
            else if (!validPrice) return "alert('Price harus >= 3000')";
            else return "alert('Terdapat kesahalan user dalam input menu baru, mohon diisi ulang!')";
        }
    }
}