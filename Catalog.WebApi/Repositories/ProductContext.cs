using Catalog.WebApi.Models;
using MongoDB.Driver;

namespace Catalog.WebApi.Repositories;

public class ProductContext : IProductContext
{
    public IMongoCollection<Product> Products { get; }

    public ProductContext(IConfiguration configuration)
    {
        var client = new MongoClient(configuration.GetValue<string>("DatabaseSettings:ConnectionString"));
        var database = client.GetDatabase(configuration.GetValue<string>("DatabaseSettings:DatabaseName"));

        Products = database.GetCollection<Product>(configuration.GetValue<string>("DatabaseSettings:CollectionName"));

        var contextSeed = new ContextSeed();

        contextSeed.SeedData(Products);
    }
}