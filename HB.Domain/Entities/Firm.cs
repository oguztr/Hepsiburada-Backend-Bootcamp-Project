using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HB.Domain.Entities
{
    public class Firm
    {
        public Firm ()
        {
            Id = new Guid();
        }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string? ManagerName { get; set; }
        public string? Address { get; set; }
        [RegularExpression(@"^(\+\d{1,2}\s)?\(?\d{3}\)?[\s.-]\d{3}[\s.-]\d{4}$")]
        public string? Phone { get; set; }
        public string? Email { get; set; }
        [Range(0,1)]
        public int FirmType { get; set; }

        public ICollection<Order> Orders { get; set; }

    }
}
