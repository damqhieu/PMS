using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PMS.Models
{
    public class PreSale
    {
        public long Id { get; set; }
        public string Company { get; set; }
        public string Project { get; set; }
        public int? ContractType { get; set; }
        public int? Size { get; set; }
        public int? Status { get; set; }
        public string Language { get; set; }
    
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }
        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }
        public string ProjectManager { get; set; }
        public string Description { get; set; }
        [DataType(DataType.Date)]
        public DateTime? CreatedAt { get; set; }

        [DataType(DataType.Date)]
        public DateTime? UpdatedAt { get; set; }

        [DataType(DataType.Date)]
        public DateTime? DeletedAt { get; set; }

        //relation ship
        public ICollection<LogHistory> LogHistory { get; set; }
    }
}
