namespace Cake_store.Services.Products;

public interface IProductServise
{
    Task<IEnumerable<ProductModel>> GetAll();
    Task<ProductModel> GetById(Guid id);
    Task<ProductModel> Create(CreateModel model);
    Task Update(Guid id, UpdateModel model);
    Task Delete(Guid id);
}
