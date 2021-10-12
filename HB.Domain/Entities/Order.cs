using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HB.Domain.Entities
{
    public class Order
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public float TotalAmount { get; set; }
        public Guid FirmId { get; set; }
        [ForeignKey("FirmId")]
        public Firm Firm { get; set; }
    }
}
