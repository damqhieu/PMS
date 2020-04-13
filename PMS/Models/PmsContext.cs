using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PMS.Models
{
    public class PmsContext : DbContext
    {
        public PmsContext(DbContextOptions<PmsContext> options) : base(options)
        {

        }

        public DbSet<CrmCustomer> CrmCustomers { get; set; }

        public DbSet<CustomerVisitHistory> CustomerVisitHistory { get; set; }
        public DbSet<PreSale> PreSale { get; set; }
        public DbSet<LogHistory> LogHistory { get; set; }
        public DbSet<Notify> Notify { get; set; }


    }
}
