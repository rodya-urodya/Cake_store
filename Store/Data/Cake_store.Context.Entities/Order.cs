using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cake_store.Context.Entities
{
    public class Order : BaseEntity
    {

        [Required]
        public DateTime OrderDate { get; set; }
        [Required]
        public string Status { get; set; }


        // Navigation property for order items
        public virtual ICollection<OrderItem> OrderItems { get; set; }
    }
}
