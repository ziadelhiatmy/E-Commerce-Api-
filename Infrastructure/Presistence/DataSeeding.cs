using DomainLayer.Contracts;
using DomainLayer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Presistence.Data;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Presistence
{
    public class DataSeeding(StoreDbContext _dbContext) : IDataSeeding
    {
        public async Task DataSeedAsync()
        {
            try
            {
               var PendingMigrations = await _dbContext.Database.GetPendingMigrationsAsync();
                if (PendingMigrations.Any())
                {
                    _dbContext.Database.Migrate();
                }

                if (!_dbContext.ProductBrands.Any())
                {
                    var ProductBrandData = File.OpenRead(@"..\Infrastructure\Presistence\Data\DataSeed\brands.json");
                    var ProductBrands =await JsonSerializer.DeserializeAsync<List<ProductBrand>>(ProductBrandData);
                    if (ProductBrands is not null && ProductBrands.Any())
                     await _dbContext.ProductBrands.AddRangeAsync(ProductBrands);

                }
                if (!_dbContext.ProductTypes.Any())
                {
                    var ProductTypeData = File.OpenRead(@"..\Infrastructure\Presistence\Data\DataSeed\types.json");
                    var ProductTypes =await JsonSerializer.DeserializeAsync<List<ProductType>>(ProductTypeData);
                    if (ProductTypes is not null && ProductTypes.Any())
                      await  _dbContext.ProductTypes.AddRangeAsync(ProductTypes);

                }
                if (!_dbContext.ProductBrands.Any())
                {
                    var ProductData = File.OpenRead(@"..\Infrastructure\Presistence\Data\DataSeed\products.json");
                    var Products =await JsonSerializer.DeserializeAsync<List<Product>>(ProductData);
                    if (Products is not null && Products.Any())
                        _dbContext.Products.AddRange(Products);

                }
                await _dbContext.SaveChangesAsync();
            }
            catch(Exception ex)
            { 

                //To Do
            }
        }
    }
}
