using Catalog.WebApi.Models;
using Catalog.WebApi.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.WebApi.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class ProductsController : ControllerBase
{
    private readonly IProductRepository productRepository;

    public ProductsController(IProductRepository productRepository)
    {
        this.productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
    }

    [HttpGet]
    public async Task<ActionResult> Get()
    {
        var products = await productRepository.Get();

        if (products == null)
        {
            return NotFound();
        }

        return Ok(products);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult> Get(string id)
    {
        var product = await productRepository.Get(id);

        if (product == null)
        {
            return NotFound();
        }

        return Ok(product);
    }

    [HttpGet("name")]
    public async Task<ActionResult> GetByName(string name)
    {
        var products = await productRepository.GetByName(name);

        if (products == null)
        {
            return NotFound();
        }

        return Ok(products);
    }

    [HttpGet("category")]
    public async Task<ActionResult> GetByCategory(string category)
    {
        var products = await productRepository.GetByCategory(category);

        if (products == null)
        {
            return NotFound();
        }

        return Ok(products);
    }

    [HttpPost]
    public async Task<ActionResult> Post([FromBody] Product product)
    {
        await productRepository.Create(product);

        return Ok(product);
    }

    [HttpPut]
    public async Task<ActionResult> Put([FromBody] Product product)
    {
        await productRepository.Update(product);

        return Ok(product);
    }

    [HttpDelete]
    public async Task<ActionResult> Delete(string id)
    {
        await productRepository.Delete(id);

        return Ok();
    }
}