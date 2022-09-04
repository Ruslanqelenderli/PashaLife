using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using PL.Business.Abstract.Services;
using PL.Business.Concrete.Dtos.CategoryDtos;
using PL.Business.Concrete.Dtos.ProductDtos;
using PL.Business.Concrete.Managers.ProductManagers;
using PL.Business.Concrete.Managers.ProductStockManagers;
using PL.Business.Helpers.Validators.CategoryValidators;
using PL.Business.Helpers.Validators.ProductValidators;
using PL.DataAccess.Abstract;
using PL.DataAccess.Concrete.EntityFramework.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL.Business.Helpers.Extensions
{
    public static class MyExtension
    {
        public static void ServiceCollectionMethod(this IServiceCollection service)
        {
            service.AddScoped<IProductRepository, ProductRepository>();
            service.AddScoped<IProductService, ProductManager>();
            service.AddScoped<ICategoryService, CategoryManager>();
            service.AddScoped<ICategoryRepository, CategoryRepository>();
            service.AddTransient<IValidator<CategoryAddDto>, CategoryAddValidator>();
            service.AddTransient<IValidator<CategoryUpdateDto>, CategoryUpdateValidator>();
            service.AddTransient<IValidator<ProductAddDto>, ProductAddValidator>();
            service.AddTransient<IValidator<ProductUpdateDto>, ProductUpdateValidator>();

        }
        public static void ServiceCollectionProductStockMethod(this IServiceCollection service)
        {
            service.AddScoped<IProductStockRepository, ProductStockRepository>();
            service.AddScoped<IProductStockService, ProductStockManager>();
            

        }

    }
}
