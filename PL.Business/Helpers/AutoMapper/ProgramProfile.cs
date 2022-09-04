using AutoMapper;
using PL.Business.Concrete.Dtos.CategoryDtos;
using PL.Business.Concrete.Dtos.ProductDtos;
using PL.Business.Concrete.Dtos.ProductStockDtos;
using PL.Business.Helpers.ReturnResult;
using PL.DataAccess.Abstract;
using PL.DataAccess.Concrete.EntityFramework.Repositories;
using PL.DataAccess.Concrete.ReturnResult;
using PL.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL.Business.Helpers.AutoMapper
{
    public class ProgramProfile:Profile
    {
        public ProgramProfile()
        {
            CreateMap<Product, ProductGetDto>();
            CreateMap<ProductGetDto, Product>();

            CreateMap<Product, ProductAddDto>();
            CreateMap<ProductAddDto, Product>();

            CreateMap<Product, ProductUpdateDto>();
            CreateMap<ProductUpdateDto, Product>();

            CreateMap<Category, CategoryGetDto>();
            CreateMap<CategoryGetDto, Category>();

            CreateMap<Category, CategoryAddDto>();
            CreateMap<CategoryAddDto, Category>();

            CreateMap<Category, CategoryUpdateDto>();
            CreateMap<CategoryUpdateDto, Category>();

            CreateMap<ProductStock, ProductStockGetDto>();
            CreateMap<ProductStockGetDto, ProductStock>();

            CreateMap<ProductStock, ProductStockAddDto>();
            CreateMap<ProductStockAddDto, ProductStock>();

            CreateMap<ProductStock, ProductStockUpdateDto>();
            CreateMap<ProductStockUpdateDto, ProductStock>();

            CreateMap<DataAccessReturnResult<Category>, BusinessReturnResult<CategoryGetDto>>();
            CreateMap<BusinessReturnResult<CategoryGetDto>, DataAccessReturnResult<Category>>();

            CreateMap<DataAccessReturnResult<Product>, BusinessReturnResult<ProductGetDto>>();
            CreateMap<BusinessReturnResult<ProductGetDto>, DataAccessReturnResult<Product>>();

            CreateMap<DataAccessReturnResult<ProductStock>, BusinessReturnResult<ProductStockGetDto>>();
            CreateMap<BusinessReturnResult<ProductStockGetDto>, DataAccessReturnResult<ProductStock>>();
        }
    }
}
