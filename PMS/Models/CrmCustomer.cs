using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PMS.Models
{
    public class CrmCustomer
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public string HoldingCompany { get; set; }
        public string ContactPoint { get; set; }
        public long? AccountManagerId { get; set; }

        [DataType(DataType.Date)]
        public DateTime? TimeCooperation  { get; set; }

        [DataType(DataType.Date)]
        public DateTime? TimeStopCooperation { get; set; }

        [DataType(DataType.Date)]
        public DateTime? TimeSettlement { get; set; }

        public int? Status  { get; set; }

        [DataType(DataType.Date)]
        public DateTime? CreatedAt { get; set; }

        [DataType(DataType.Date)]
        public DateTime? UpdatedAt { get; set; }

        [DataType(DataType.Date)]
        public DateTime? DeletedAt { get; set; }

        //relation ship
        public ICollection<CustomerVisitHistory> CustomerVisitHistories { get; set; }

    }
}
