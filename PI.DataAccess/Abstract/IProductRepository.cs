using PL.DataAccess.Abstract.IGenericRepository;
using PL.DataAccess.Concrete.ReturnResult;
using PL.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL.DataAccess.Abstract
{
    public interface IProductRepository:IAsyncRepository<Product,DataAccessReturnResult<Product>>,IRepository<Product, DataAccessReturnResult<Product>>
    {
    }
}
