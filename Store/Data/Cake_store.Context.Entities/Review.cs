using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cake_store.Context.Entities
{
    public class Review : BaseEntity
    {
        [Required]
        public string Content { get; set; }

        public bool Like { get; set; }
        [Required]
        [AllowedValues([1,2,3,4,5])]
        public int Rating { get; set; }
        // Foreign Key
        [Required]
        public Guid UserId { get; set; }
        public virtual User User { get; set; }

        // Foreign Key
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }
    }
}
