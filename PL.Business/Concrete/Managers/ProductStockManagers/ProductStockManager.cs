using AutoMapper;
using PL.Business.Abstract.Services;
using PL.Business.Concrete.Dtos.CategoryDtos;
using PL.Business.Concrete.Dtos.ProductDtos;
using PL.Business.Concrete.Dtos.ProductStockDtos;
using PL.Business.Helpers.ReturnResult;
using PL.DataAccess.Abstract;
using PL.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL.Business.Concrete.Managers.ProductStockManagers
{
    public class ProductStockManager:IProductStockService
    {
        private readonly IProductStockRepository productsStockRepository;
        private readonly IMapper mapper;



        public ProductStockManager(IProductStockRepository productsStockRepository, IMapper mapper)
        {
            this.productsStockRepository = productsStockRepository;
            this.mapper = mapper;
        }
        public async Task<BusinessReturnResult<ProductStockGetDto>> AddAsync(ProductStockAddDto entity)
        {
            try
            {
                var data = mapper.Map<ProductStock>(entity);
                data.CreatedDate = DateTime.Now;
                data.IsDeleted = false;
                var returnresult = await productsStockRepository.AddAsync(data);
                var result = mapper.Map<BusinessReturnResult<ProductStockGetDto>>(returnresult);
                return result;
            }
            catch (Exception ex)
            {
                var result = new BusinessReturnResult<ProductStockGetDto>();
                result.MainMethod(ex.Message, false);
                return result;
            }
        }

        

        public async Task<BusinessReturnResult<ProductStockGetDto>> DeleteAsync(int Id)
        {
            try
            {
                var returnresult = await productsStockRepository.DeleteAsync(Id);
                var result = mapper.Map<BusinessReturnResult<ProductStockGetDto>>(returnresult);
                return result;
            }
            catch (Exception ex)
            {
                var result = new BusinessReturnResult<ProductStockGetDto>();
                result.MainMethod(ex.Message, false);
                return result;
            }
        }

        public async Task<BusinessReturnResult<ProductStockGetDto>> GetAllForStateAsync(bool enableTracking = true, params string[] include)
        {
            try
            {
                var result = await productsStockRepository.GetAllAsync(x => x.State == true && x.IsDeleted == false,
                                                      enableTracking,
                                                      include);
                var returnresult = mapper.Map<BusinessReturnResult<ProductStockGetDto>>(result);
                return returnresult;

            }
            catch (Exception ex)
            {
                var returnresult = new BusinessReturnResult<ProductStockGetDto>();
                returnresult.MainMethod(ex.Message, false);
                return returnresult;
                ;
            }
        }

        public async Task<BusinessReturnResult<ProductStockGetDto>> GetByIdAsync(int id, params string[] include)
        {
            try
            {
                var result = await productsStockRepository.GetAsync(x => x.Id == id,
                                                      include);
                var returnresult = mapper.Map<BusinessReturnResult<ProductStockGetDto>>(result);
                return returnresult;

            }
            catch (Exception ex)
            {
                var returnresult = new BusinessReturnResult<ProductStockGetDto>();
                returnresult.MainMethod(ex.Message, false);
                return returnresult;
                ;
            }
        }

        public async Task<BusinessReturnResult<ProductStockGetDto>> GetByProductIdAsync(int productid, params string[] include)
        {
            try
            {
                var result = await productsStockRepository.GetAsync(x => x.ProductId == productid,
                                                      include);
                var returnresult = mapper.Map<BusinessReturnResult<ProductStockGetDto>>(result);
                return returnresult;

            }
            catch (Exception ex)
            {
                var returnresult = new BusinessReturnResult<ProductStockGetDto>();
                returnresult.MainMethod(ex.Message, false);
                return returnresult;
                ;
            }
        }

        public async Task<BusinessReturnResult<ProductStockGetDto>> UpdateAsync(ProductStockUpdateDto entity)
        {
            try
            {
                var data = mapper.Map<ProductStock>(entity);
                var returnresult = await productsStockRepository.UpdateAsync(data);
                var result = mapper.Map<BusinessReturnResult<ProductStockGetDto>>(returnresult);
                return result;
            }
            catch (Exception ex)
            {
                var result = new BusinessReturnResult<ProductStockGetDto>();
                result.MainMethod(ex.Message, false);
                return result;
            }
        }

       
    }
}
