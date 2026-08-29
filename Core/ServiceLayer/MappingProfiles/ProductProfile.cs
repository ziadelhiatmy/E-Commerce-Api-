using AutoMapper;
using DomainLayer.Models;
using SharedDtos.DataTransfareObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.MappingProfiles
{
    public class ProductProfile : Profile
    {
        protected ProductProfile()
        {
            CreateMap<Product, ProductDto>()
                .ForMember(dist => dist.BrandName, Options => Options.MapFrom(src => src.ProductBrand.Name))
                 .ForMember(dist => dist.TypeName, Options => Options.MapFrom(src => src.productType.Name));
            CreateMap<ProductBrand , BrandDto>();
            CreateMap<ProductType , TypeDto>();
        }
    }
}
