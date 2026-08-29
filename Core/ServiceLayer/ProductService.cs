using AutoMapper;
using DomainLayer.Contracts;
using DomainLayer.Models;
using ServiceAbstraction;
using SharedDtos.DataTransfareObject;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer
{
    public class ProductService(IUniteOfWork _uniteOfWork , IMapper _mapper ) : IProductService
    {
        public async Task<IEnumerable<BrandDto>> GetAllProductBrandsAsync()
        {
            var Repo =  _uniteOfWork.GetRepository<ProductBrand , int>();
            var Brands = await Repo.GetAllAsync();
            var brandDtos = _mapper.Map<IEnumerable<BrandDto>>(Brands);
            return brandDtos;
        }

        public async Task<IEnumerable<ProductDto>> GetAllProductsAsync()
        {
            var products = await _uniteOfWork.GetRepository<Product , int>().GetAllAsync();
            return _mapper.Map<IEnumerable<Product>, IEnumerable<ProductDto>>(products);

        }

        public async Task<IEnumerable<TypeDto>> GetAllProductTypesAsync()
        {
            var Types = await _uniteOfWork.GetRepository<ProductType , int>().GetAllAsync();
            var TypesDto = _mapper.Map<IEnumerable<ProductType>, IEnumerable<TypeDto>>(Types);
            return TypesDto;
        }

        public async Task<ProductDto> GetProductById(int id)
        {
            var Product =await _uniteOfWork.GetRepository<Product , int>().GetByIdAsync(id);
            return _mapper.Map<Product ,ProductDto>(Product);
        }
    }
}
