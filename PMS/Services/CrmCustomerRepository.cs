using Microsoft.EntityFrameworkCore;
using PMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PMS.Services
{
    public class CrmCustomerRepository
    {
        //Test service
        private readonly PmsContext _context;

        public CrmCustomerRepository(PmsContext context)
        {
            _context = context;
        }

        public List<CrmCustomer> GetAll()
        {
            var customers = _context.CrmCustomers.ToList();
            return customers;
        }

        public CrmCustomer Show(long id)
        {
            var customer = _context.CrmCustomers.Find(id);
            return customer;
        }

        public CrmCustomer Post(CrmCustomer crmCustomer)
        { 

            _context.CrmCustomers.Add(crmCustomer);
            _context.SaveChanges();

            return crmCustomer;
        }
    }
}
