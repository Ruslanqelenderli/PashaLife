using AutoMapper;
using PL.Business.Abstract.Services;
using PL.Business.Concrete.Dtos.ProductDtos;
using PL.Business.Helpers.ReturnResult;
using PL.DataAccess.Abstract;
using PL.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL.Business.Concrete.Managers.ProductManagers
{
    public class ProductManager : IProductService
    {
        private readonly IProductRepository productRepository;
        private readonly IMapper mapper;



        public ProductManager(IProductRepository productRepository, IMapper mapper)
        {
            this.productRepository = productRepository;
            this.mapper = mapper;
        }
        public async Task<BusinessReturnResult<ProductGetDto>> AddAsync(ProductAddDto entity)
        {
            try
            {
                var data = mapper.Map<Product>(entity);
                data.CreatedDate = DateTime.Now;
                data.IsDeleted = false;
                var returnresult = await productRepository.AddAsync(data);
                var result = mapper.Map<BusinessReturnResult<ProductGetDto>>(returnresult);
                return result;
            }
            catch (Exception ex)
            {
                var result = new BusinessReturnResult<ProductGetDto>();
                result.MainMethod(ex.Message, false);
                return result;
            }
        }

        public async Task<BusinessReturnResult<ProductGetDto>> DeleteAsync(int Id)
        {
            try
            {
                var returnresult = await productRepository.DeleteAsync(Id);
                var result = mapper.Map<BusinessReturnResult<ProductGetDto>>(returnresult);
                return result;
            }
            catch (Exception ex)
            {
                var result = new BusinessReturnResult<ProductGetDto>();
                result.MainMethod(ex.Message, false);
                return result;
            }
        }

        public async Task<BusinessReturnResult<ProductGetDto>> GetAllForStateAsync(bool enableTracking = true, params string[] include)
        {
            try
            {
                var result = await productRepository.GetAllAsync(x => x.State == true && x.IsDeleted == false,
                                                      enableTracking,
                                                      include) ;
                var returnresult = mapper.Map<BusinessReturnResult<ProductGetDto>>(result);
                return returnresult;

            }
            catch (Exception ex)
            {
                var returnresult = new BusinessReturnResult<ProductGetDto>();
                returnresult.MainMethod(ex.Message, false);
                return returnresult;
                ;
            }
        }

        public async Task<BusinessReturnResult<ProductGetDto>> GetByIdAsync(int id, params string[] include)
        {
            try
            {
                var result = await productRepository.GetAsync(x => x.Id == id,
                                                      include);
                var returnresult = mapper.Map<BusinessReturnResult<ProductGetDto>>(result);
                return returnresult;

            }
            catch (Exception ex)
            {
                var returnresult = new BusinessReturnResult<ProductGetDto>();
                returnresult.MainMethod(ex.Message, false);
                return returnresult;
                ;
            }
        }

        public async Task<BusinessReturnResult<ProductGetDto>> UpdateAsync(ProductUpdateDto entity)
        {
            try
            {
                var data = mapper.Map<Product>(entity);
                var returnresult = await productRepository.UpdateAsync(data);
                var result = mapper.Map<BusinessReturnResult<ProductGetDto>>(returnresult);
                return result;
            }
            catch (Exception ex)
            {
                var result = new BusinessReturnResult<ProductGetDto>();
                result.MainMethod(ex.Message, false);
                return result;
            }
        }
    }
}
