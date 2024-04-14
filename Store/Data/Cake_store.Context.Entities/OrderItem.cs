using Cake_store.Context.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cake_store.Context.Entities
{
    public class OrderItem : BaseEntity
    {

        [Required]
        public int Quantity { get; set; }

        [Required]
        public decimal Price { get; set; }

        // Foreign Key
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }

        // Foreign Key
        public int OrderId { get; set; }
        public virtual Order Order { get; set; }
    }
}
