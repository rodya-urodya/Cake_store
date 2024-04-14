using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cake_store.Services.Products;

internal class iProductServise
{
    Task<IEnumerable<ProductModel>> GetAll();
    Task<ProductModel> GetById(Guid id);
    Task<ProductModel> Create(CreateModel model);
    Task Create(Guid id, UpdateModel model);
    Task Delete(Guid id);
}
