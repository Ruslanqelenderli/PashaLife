using AutoMapper;
using PL.Business.Abstract.Services;
using PL.Business.Concrete.Dtos.CategoryDtos;
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
    public class CategoryManager:ICategoryService
    {
        private readonly ICategoryRepository categoryRepository;
        private readonly IMapper mapper;



        public CategoryManager(ICategoryRepository categoryRepository, IMapper mapper)
        {
            this.categoryRepository = categoryRepository;
            this.mapper = mapper;
        }
        public async Task<BusinessReturnResult<CategoryGetDto>> AddAsync(CategoryAddDto entity)
        {
            try
            {
                var data = mapper.Map<Category>(entity);
                data.CreatedDate = DateTime.Now;
                data.IsDeleted = false;
                var returnresult = await categoryRepository.AddAsync(data);
                var result = mapper.Map<BusinessReturnResult<CategoryGetDto>>(returnresult);
                return result;
            }
            catch (Exception ex)
            {
                var result = new BusinessReturnResult<CategoryGetDto>();
                result.MainMethod(ex.Message, false);
                return result;
            }
        }

       

        public async Task<BusinessReturnResult<CategoryGetDto>> DeleteAsync(int Id)
        {
            try
            {
                var returnresult = await categoryRepository.DeleteAsync(Id);
                var result = mapper.Map<BusinessReturnResult<CategoryGetDto>>(returnresult);
                return result;
            }
            catch (Exception ex)
            {
                var result = new BusinessReturnResult<CategoryGetDto>();
                result.MainMethod(ex.Message, false);
                return result;
            }
        }

        public async Task<BusinessReturnResult<CategoryGetDto>> GetAllForStateAsync(bool enableTracking = true, params string[] include)
        {
            try
            {
                var result = await categoryRepository.GetAllAsync(x => x.State == true && x.IsDeleted == false,
                                                      enableTracking,
                                                      include);
                var returnresult = mapper.Map<BusinessReturnResult<CategoryGetDto>>(result);
                return returnresult;

            }
            catch (Exception ex)
            {
                var returnresult = new BusinessReturnResult<CategoryGetDto>();
                returnresult.MainMethod(ex.Message, false);
                return returnresult;
                ;
            }
        }

        public async Task<BusinessReturnResult<CategoryGetDto>> GetByIdAsync(int id, params string[] include)
        {
            try
            {
                var result = await categoryRepository.GetAsync(x => x.Id == id,
                                                      include);
                var returnresult = mapper.Map<BusinessReturnResult<CategoryGetDto>>(result);
                return returnresult;

            }
            catch (Exception ex)
            {
                var returnresult = new BusinessReturnResult<CategoryGetDto>();
                returnresult.MainMethod(ex.Message, false);
                return returnresult;
                ;
            }
        }

        public async Task<BusinessReturnResult<CategoryGetDto>> UpdateAsync(CategoryUpdateDto entity)
        {
            try
            {
                var data = mapper.Map<Category>(entity);
                var returnresult = await categoryRepository.UpdateAsync(data);
                var result = mapper.Map<BusinessReturnResult<CategoryGetDto>>(returnresult);
                return result;
            }
            catch (Exception ex)
            {
                var result = new BusinessReturnResult<CategoryGetDto>();
                result.MainMethod(ex.Message, false);
                return result;
            }
        }

        
    }
}
