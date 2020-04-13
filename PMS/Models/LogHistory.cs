using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PMS.Models
{
    public class LogHistory
    {
        public long Id { get; set; }
        public long PreSaleId { get; set; }
        public long UserId { get; set; }
        
        [DataType(DataType.Date)]
        public DateTime? CreatedAt { get; set; }

        [DataType(DataType.Date)]
        public DateTime? UpdatedAt { get; set; }

        [DataType(DataType.Date)]
        public DateTime? DeletedAt { get; set; }

        //relation ship
        public PreSale PreSale { get; set; }
        public ICollection<Notify> Notify { get; set; }
    }
}
