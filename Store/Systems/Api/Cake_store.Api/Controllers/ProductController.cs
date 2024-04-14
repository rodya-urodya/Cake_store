namespace Cake_store.Api.App;

using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using Cake_store.Services.Products;
using Cake_store.Services.Logger;
using Cake_store.Common.Security;
using Microsoft.AspNetCore.Authorization;

[ApiController]
[Authorize]
[ApiVersion("1.0")]
[ApiExplorerSettings(GroupName = "Product")]
[Route("v{version:apiVersion}/[controller]")]
public class ProductController : ControllerBase
{
    private readonly IAppLogger logger;
    private readonly IProductServise bookService;

    public ProductController(IAppLogger logger, IProductServise bookService)
    {
        this.logger = logger;
        this.bookService = bookService;
    }

    [HttpGet("")]
    [Authorize(AppScopes.BooksRead)]
    public async Task<IEnumerable<ProductModel>> GetAll()
    {
        var result = await bookService.GetAll();

        return result;
    }

    [HttpGet("{id:Guid}")]
    public async Task<IActionResult> Get([FromRoute] Guid id)
    {
        var result = await bookService.GetById(id);

        if (result == null)
            return NotFound();

        return Ok(result);
    }

    [HttpPost("")]
    [Authorize(AppScopes.BooksWrite)]
    public async Task<ProductModel> Create(CreateModel request)
    {
        var result = await bookService.Create(request);

        return result;
    }

    [HttpPut("{id:Guid}")]
    [Authorize(AppScopes.BooksWrite)]
    public async Task Update([FromRoute] Guid id, UpdateModel request)
    {
        await bookService.Update(id, request);
    }

    [HttpDelete("{id:Guid}")]
    [Authorize(AppScopes.BooksWrite)]
    public async Task Delete([FromRoute] Guid id)
    {
        await bookService.Delete(id);
    }

}
