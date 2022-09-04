using PL.Business.Concrete.Dtos.CategoryDtos;
using PL.Business.Concrete.Dtos.ProductDtos;
using PL.Business.Helpers.ReturnResult;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL.Business.Abstract.Services
{
    public interface ICategoryService
    {
        Task<BusinessReturnResult<CategoryGetDto>> GetAllForStateAsync(bool enableTracking = true, params string[] include);
        Task<BusinessReturnResult<CategoryGetDto>> AddAsync(CategoryAddDto entity);
        Task<BusinessReturnResult<CategoryGetDto>> UpdateAsync(CategoryUpdateDto entity);
        Task<BusinessReturnResult<CategoryGetDto>> GetByIdAsync(int id, params string[] include);
        Task<BusinessReturnResult<CategoryGetDto>> DeleteAsync(int Id);
    }
}
