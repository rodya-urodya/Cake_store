using Cake_store.Context.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cake_store.Context.Entities;

public class Category : BaseEntity
{

    [Required]
    public string Name { get; set; }

    public virtual ICollection<Product> Products { get; set; }
}
