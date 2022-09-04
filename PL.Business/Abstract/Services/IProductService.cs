using PL.Business.Concrete.Dtos.ProductDtos;
using PL.Business.Helpers.ReturnResult;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL.Business.Abstract.Services
{
    public interface IProductService
    {
        Task<BusinessReturnResult<ProductGetDto>> GetAllForStateAsync(bool enableTracking = true, params string[] include);
        Task<BusinessReturnResult<ProductGetDto>> AddAsync(ProductAddDto entity);
        Task<BusinessReturnResult<ProductGetDto>> UpdateAsync(ProductUpdateDto entity);
        Task<BusinessReturnResult<ProductGetDto>> GetByIdAsync(int id, params string[] include);
        Task<BusinessReturnResult<ProductGetDto>> DeleteAsync(int Id);

    }
}
