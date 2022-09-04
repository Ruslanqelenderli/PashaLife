using PL.Business.Concrete.Dtos.CategoryDtos;
using PL.Business.Concrete.Dtos.ProductStockDtos;
using PL.Business.Helpers.ReturnResult;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL.Business.Abstract.Services
{
    public interface IProductStockService
    {
        Task<BusinessReturnResult<ProductStockGetDto>> GetAllForStateAsync(bool enableTracking = true, params string[] include);
        Task<BusinessReturnResult<ProductStockGetDto>> AddAsync(ProductStockAddDto entity);
        Task<BusinessReturnResult<ProductStockGetDto>> UpdateAsync(ProductStockUpdateDto entity);
        Task<BusinessReturnResult<ProductStockGetDto>> GetByIdAsync(int id, params string[] include);
        Task<BusinessReturnResult<ProductStockGetDto>> GetByProductIdAsync(int productid, params string[] include);
        Task<BusinessReturnResult<ProductStockGetDto>> DeleteAsync(int Id);
    }
}
