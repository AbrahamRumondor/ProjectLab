using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProjectLab.Model;

namespace ProjectLab.Factory
{
    public class HeaderFactory
    {
        public static Header createHeader(string id)
        {
            Header newHeader = new Header();
            newHeader.Customerid = Convert.ToInt32(id);
            newHeader.Staffid = -1;
            newHeader.Date = DateTime.Now;

            return newHeader;
        }
    }
}