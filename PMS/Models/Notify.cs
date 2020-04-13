using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PMS.Models
{
    public class Notify
    {
        public long Id { get; set; }
        public long LogHistoryId { get; set; }
        public long UserId { get; set; }

        [DataType(DataType.Date)]
        public DateTime? CreatedAt { get; set; }

        [DataType(DataType.Date)]
        public DateTime? UpdatedAt { get; set; }

        [DataType(DataType.Date)]
        public DateTime? DeletedAt { get; set; }

        //relation ship
        public LogHistory LogHistory { get; set; }
    }
}
