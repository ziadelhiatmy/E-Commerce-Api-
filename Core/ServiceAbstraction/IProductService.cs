using DomainLayer.Models;
using SharedDtos.DataTransfareObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceAbstraction
{
    public interface IProductService 
    {
        Task<IEnumerable<ProductDto>> GetAllProductsAsync();
        Task<ProductDto> GetProductById(int id);
        Task<IEnumerable<TypeDto>> GetAllProductTypesAsync();
        Task<IEnumerable<BrandDto>> GetAllProductBrandsAsync();
    }
}
