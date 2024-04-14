using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cake_store.Context.Entities
{
    public class Image : BaseEntity
    {
        [Required]
        public byte[] Data { get; set; }

        // Foreign Key
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }
    }
}
