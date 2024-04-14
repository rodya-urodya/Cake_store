using System.ComponentModel.DataAnnotations;

namespace Cake_store.Context.Entities;

public class Product : BaseEntity
{

    [Required]
    public string Name { get; set; }

    public string Description { get; set; }

    [Required]
    public decimal Price { get; set; }
    [Required]
    public virtual User User { get; set; }

    public Guid? UserId { get; set; }

    // Navigation property for images
    public virtual ICollection<Image>? Images { get; set; }

    // Navigation property for reviews
    public virtual ICollection<Review>? Reviews { get; set; }
    public virtual ICollection<Category> Categories { get; set; }
}
