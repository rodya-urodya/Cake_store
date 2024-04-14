namespace Cake_store.Context.Seeder;

using Cake_store.Context.Entities;

public class DemoHelper
{
    public IEnumerable<Product> GetBooks = new List<Product>
    {
        new Product()
        {
            Uid = Guid.NewGuid(),
            Name = "Napoleon",
            Description = "Top cake named by franch polkovodec",
            Price = 1000,
            //Images = new Image()
            //{
            //    Uid = Guid.NewGuid(),
            //},
            Categories = new List<Category>()
            {
                new Category()
                {
                    Name = "Chocolade",
                },
                new Category()
                {
                    Name = "Cream",
                }
            },
            User = new User()
            {
                UserName = "John",
                Email = "abc@mail.com"
            }

        },

        
    };
}