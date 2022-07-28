using Catalog.WebApi.Models;
using MongoDB.Driver;

namespace Catalog.WebApi.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly IProductContext productContext;

    public ProductRepository(IProductContext productContext)
    {
        this.productContext = productContext ?? throw new ArgumentNullException(nameof(productContext));
    }

    public async Task<IEnumerable<Product>> Get()
    {
        return await productContext.Products.Find(x => true).ToListAsync();
    }

    public async Task<Product> Get(string id)
    {
        return await productContext.Products.Find(x => x.Id == id).FirstOrDefaultAsync();
    }

    public async Task<IEnumerable<Product>> GetByName(string name)
    {
        var filter = Builders<Product>.Filter.ElemMatch(x => x.Name, name);

        return await productContext.Products.Find(filter).ToListAsync();
    }

    public async Task<IEnumerable<Product>> GetByCategory(string category)
    {
        var filter = Builders<Product>.Filter.Eq(x => x.Category, category);

        return await productContext.Products.Find(filter).ToListAsync();
    }

    public async Task Create(Product product)
    {
        await productContext.Products.InsertOneAsync(product);
    }

    public async Task<bool> Update(Product product)
    {
        var updateResult = await productContext.Products.ReplaceOneAsync(filter: x => x.Id == product.Id, replacement: product);

        return updateResult.IsAcknowledged && updateResult.ModifiedCount > 0;
    }

    public async Task<bool> Delete(string id)
    {
        var filter = Builders<Product>.Filter.Eq(x => x.Id, id);

        var deleteResult = await productContext.Products.DeleteOneAsync(filter);

        return deleteResult.IsAcknowledged && deleteResult.DeletedCount > 0;
    }
}