using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL.Business.Concrete.Dtos.CategoryDtos
{
    public class CategoryGetDto
    {
        public int Id { get; set; }
        public bool State { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Name { get; set; }
    }
}
