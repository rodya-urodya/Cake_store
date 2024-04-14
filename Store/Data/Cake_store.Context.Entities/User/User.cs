namespace Cake_store.Context.Entities;

using Microsoft.AspNetCore.Identity;

public class User : IdentityUser<Guid>
{
    public string FullName { get; set; }
    public UserStatus Status { get; set; }


    public virtual ICollection<Product>? Products { get; set; }
    public virtual ICollection<Review>? Reviews { get; set; }
}
