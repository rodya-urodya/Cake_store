using Cake_store.Context;
using Microsoft.EntityFrameworkCore;

namespace Cake_store.Services.Products.Products;

internal class ProductService : iProductServise
{
    private readonly IDbContextFactory<MainDbContext> dbContextFactory;
    public ProductService(IDbContextFactory<MainDbContext> dbContextFactory)
    {
        this.dbContextFactory = dbContextFactory;
    }
    public async Task<IEnumerable<ProductModel>> GetAll()
    {
        using var context = await dbContextFactory.CreateDbContextAsync();

        var products = context.Products.ToListAsync();

        var result = products.Select(x => new ProductModel()
        {
            Id = x.Uid,
            Name = x.Name,
            Categories = x.Categories.Select(x => s.Title),
            Description = x.Description,
            Price = x.Price,

        })

    }
    public async Task<ProductModel> GetById(Guid id)
    {

    }
    public async Task<ProductModel> Create(CreateModel model)
    {

    }
    public async Task Create(Guid id, UpdateModel model)
    {

    }
    public async Task Delete(Guid id)
    {

    }
}
