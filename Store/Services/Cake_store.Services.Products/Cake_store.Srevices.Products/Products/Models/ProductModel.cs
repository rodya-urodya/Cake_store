using Microsoft.EntityFrameworkCore;
using Cake_store.Context.Entities;
using Cake_store.Context;
using AutoMapper;

namespace Cake_store.Services.Products;

public class ProductModel
{
    public Guid Id { get; set; }

    public Guid UserId { get; set; }
    public string Name { get; set; }

    public string Description { get; set; }

    public decimal Price { get; set; }

    ////Navigation property for images
    //public virtual ICollection<Image> Images { get; set; }

    //// Navigation property for reviews
    //public virtual ICollection<Review> Reviews { get; set; }
    public virtual IEnumerable<string> Categories { get; set; }
}


public class ProductModelProfile : Profile
{
    public ProductModelProfile()
    {
        CreateMap<Product, ProductModel>()
            .BeforeMap<ProductModelActions>()
            .ForMember(dest => dest.Id, opt => opt.Ignore())

            .ForMember(dest => dest.UserId, opt => opt.Ignore())
            .ForMember(dest => dest.Categories, opt => opt.Ignore())
            ;
    }

    public class ProductModelActions : IMappingAction<Product, ProductModel>
    {
        private readonly IDbContextFactory<MainDbContext> contextFactory;

        public ProductModelActions(IDbContextFactory<MainDbContext> contextFactory)
        {
            this.contextFactory = contextFactory;
        }

        public void Process(Product source, ProductModel destination, ResolutionContext context)
        {
            using var db = contextFactory.CreateDbContext();

            var product = db.Products.Include(x=>x.User).FirstOrDefault(x => x.Id == source.Id);

            destination.Id = product.Uid;
            destination.UserId = product.User.Id;
            destination.Categories = product.Categories?.Select(x => x.Name);

            //.ForMember(dest => dest.Id, opt => opt.Ignore())
            //.ForMember(dest => dest.UserId, opt => opt.Ignore())
            //.ForMember(dest => dest.Name, opt => opt.Ignore())
            //.ForMember(dest => dest.Description, opt => opt.Ignore())
            //.ForMember(dest => dest.Price, opt => opt.Ignore())
            //.ForMember(dest => dest.Categories, opt => opt.Ignore())
        }
    }
}