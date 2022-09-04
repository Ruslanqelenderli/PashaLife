using PL.DataAccess.Abstract;
using PL.DataAccess.Concrete.EntityFramework.Context;
using PL.DataAccess.Concrete.EntityFramework.Repositories.GenericRepository;
using PL.DataAccess.Concrete.ReturnResult;
using PL.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL.DataAccess.Concrete.EntityFramework.Repositories
{
    public class ProductRepository:EFGenericRepository<Product, DataAccessReturnResult<Product>,PLDbContext>,IProductRepository
    {
        public ProductRepository(PLDbContext context):base(context) { }
        
    }
}
