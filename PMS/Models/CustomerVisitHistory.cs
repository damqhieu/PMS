using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PMS.Models
{
    public class CustomerVisitHistory
    {
        public long Id { get; set; }
        public long CrmCustomerId { get; set; }
        public CrmCustomer CrmCustomer { get; set; }

        public string Url { get; set; }
       
        [DataType(DataType.Date)]
        public DateTime? StartDate { get; set; }

        [DataType(DataType.Date)]
        public DateTime? FinishDate { get; set; }

        public string Ingredient { get; set; }

        public string Restaurant { get; set; }
        public string Gift { get; set; }

        [DataType(DataType.Date)]
        public DateTime? CreatedAt { get; set; }

        [DataType(DataType.Date)]
        public DateTime? UpdatedAt { get; set; }

        [DataType(DataType.Date)]
        public DateTime? DeletedAt { get; set; }
    }
}
