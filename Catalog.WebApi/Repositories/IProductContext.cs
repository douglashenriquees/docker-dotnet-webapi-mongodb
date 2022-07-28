using Catalog.WebApi.Models;
using MongoDB.Driver;

namespace Catalog.WebApi.Repositories;

public interface IProductContext
{
    IMongoCollection<Product> Products { get; }
}