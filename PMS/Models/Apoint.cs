using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PMS.Models
{
    public class Appoint
    {
        public long Id { get; set; }
        public string Company { get; set; }
        public string Domain { get; set; }
        public string Capital { get; set; }
        [DataType(DataType.Date)]
        public DateTime SaleDate { get; set; }
        public string PersonInCharge { get; set; }
        public string SalePerson { get; set; }
        public string Business { get; set; }
        public string CooperationTrend { get; set; }
        public int? Status { get; set; }
        public string Reping { get; set; }
        [DataType(DataType.Date)]
        public DateTime DateReping { get; set; }
    }
}
