using PL.DataAccess.Abstract;
using PL.DataAccess.Abstract.IGenericRepository;
using PL.DataAccess.Concrete.EntityFramework.Context;
using PL.DataAccess.Concrete.EntityFramework.Repositories.GenericRepository;
using PL.DataAccess.Concrete.ReturnResult;
using PL.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PL.DataAccess.Concrete.EntityFramework.Repositories
{
    public class CategoryRepository:EFGenericRepository<Category,DataAccessReturnResult<Category>,PLDbContext>,ICategoryRepository
    {
        public CategoryRepository(PLDbContext context):base(context) { }

        
    }
}
