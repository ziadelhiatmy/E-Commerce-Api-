using DomainLayer.Models;
using Microsoft.AspNetCore.Mvc;
using ServiceAbstraction;
using SharedDtos.DataTransfareObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController (IServiceManager _serviceManager) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDto>>> GetAllProducts()
        {
            var products = await _serviceManager.ProductService.GetAllProductsAsync();
            return Ok(products);

        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<ProductDto>> GetProductById(int id)
        {
            var Product =await _serviceManager.ProductService.GetProductById(id);
            return Ok(Product);
        }
        [HttpGet("Type")]
        public async Task<ActionResult<IEnumerable<TypeDto>>> GetProductsType()
        { 
        var productsType =await _serviceManager.ProductService.GetAllProductTypesAsync();
            return Ok(productsType);
        }

        [HttpGet("brand")]
        public async Task<ActionResult<IEnumerable<BrandDto>>> GetProductsBrand()
        {
            var productsBrand =await _serviceManager.ProductService.GetAllProductBrandsAsync();
            return Ok(productsBrand);
        }
    }
}
