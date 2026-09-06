using AutoMapper;
using DomainLayer.Contracts;
using ServiceAbstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer
{
    public class ServiceManager(IUniteOfWork uniteOfWork , IMapper mapper) : IServiceManager
    {
        private readonly Lazy<IProductService> _LazyproductService = new Lazy<IProductService>(()=> new ProductService(uniteOfWork , mapper));
        public IProductService ProductService =>  _LazyproductService.Value;
    }
}
