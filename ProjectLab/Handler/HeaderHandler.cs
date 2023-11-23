using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProjectLab.Model;
using ProjectLab.Repository;

namespace ProjectLab.Handler
{
    public class HeaderHandler
    {
        HeaderRepo headerRepo = new HeaderRepo();

        public Header getLatestHeader(int id)
        {
            Header header = headerRepo.getAllHeader().Where(x => x.Customerid == id).ToList().LastOrDefault();
            return header;
        }

        public Header getHeader(int id)
        {
            Header header = headerRepo.getAllHeader().Where(x => x.id == id).ToList().FirstOrDefault();
            return header;
        }

        public List<Header> getCustomerHeader(int id)
        {
            List<Header> customerHeader = headerRepo.getAllHeader().Where(x => x.Customerid == id).ToList();
            return customerHeader;
        }

        public List<Header> getAdminHeader()
        {
            List<Header> adminHeader = headerRepo.getAllHeader().Where(x => x.Staffid != -1).ToList();
            return adminHeader;
        }

        public void updateStaff(int tid, int id)
        {
            getHeader(tid).Staffid = id;
            headerRepo.updateDatabase();
        }
    }
}