using Cake_store.Context;
using Microsoft.EntityFrameworkCore;
using Cake_store.Context.Entities;
using AutoMapper;
using System;
using Cake_store.Common.Exceptions;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Cake_store.Common.Validator;
using Cake_store.Services.Actions;

namespace Cake_store.Services.Products;

public class ProductService : IProductServise
{
    private readonly IDbContextFactory<MainDbContext> dbContextFactory;
    private readonly IMapper mapper;
    private readonly IAction action;
    private readonly IModelValidator<UpdateModel> updateModelValidator;
    private readonly IModelValidator<CreateModel> createModelValidator;

    public ProductService(IDbContextFactory<MainDbContext> dbContextFactory, 
        IMapper mapper,
        IAction action,
        IModelValidator<CreateModel> createModelValidator,
        IModelValidator<UpdateModel> updateModelValidator)
    {
        this.dbContextFactory = dbContextFactory;
        this.mapper = mapper;
        this.action = action;
        this.createModelValidator = createModelValidator;
        this.updateModelValidator = updateModelValidator;
    }
    public async Task<IEnumerable<ProductModel>> GetAll()
    {
        using var context = await dbContextFactory.CreateDbContextAsync();

        var products = await context.Products
            //.Include(x => x.Reviews)
            .Include(x => x.Categories)
            //.Include(x => x.Images)
            .Include(x => x.User)
            .ToListAsync();

        var result = mapper.Map<IEnumerable<ProductModel>>(products);

        return result;

    }
    public async Task<ProductModel> GetById(Guid id)
    {
        using var context = await dbContextFactory.CreateDbContextAsync();

        var product = await context.Products
            //.Include(x => x.Reviews)
            .Include(x => x.Categories)
            //.Include(x => x.Images)
            .Include(x => x.User)
            .FirstOrDefaultAsync(x => x.Uid == id);

        var result = mapper.Map<ProductModel>(product);

        return result;
    }
    public async Task<ProductModel> Create(CreateModel model)
    {
        await createModelValidator.CheckAsync(model);

        using var context = await dbContextFactory.CreateDbContextAsync();

        var product = mapper.Map<Product>(model);

        await context.Products.AddAsync(product);

        await context.SaveChangesAsync();

        await action.PublicateProduct(new PublicateProductModel()
        {
            Id = product.Id,
            Title = product.Name,
            Description = product.Description
        });

        return mapper.Map<ProductModel>(product);
    }
    public async Task Update(Guid id, UpdateModel model)
    {
        await updateModelValidator.CheckAsync(model);

        using var context = await dbContextFactory.CreateDbContextAsync();

        var product = await context.Products.Where(x => x.Uid == id).FirstOrDefaultAsync();

        product = mapper.Map(model, product);

        context.Products.Update(product);

        await context.SaveChangesAsync();
    }
    public async Task Delete(Guid id)
    {
        using var context = await dbContextFactory.CreateDbContextAsync();

        var product = await context.Products.Where(x => x.Uid == id).FirstOrDefaultAsync();

        if (product == null)
            throw new ProcessException($"Book (ID = {id}) not found.");

        context.Products.Remove(product);

        await context.SaveChangesAsync();
    }
}
