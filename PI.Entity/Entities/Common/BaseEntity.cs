using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL.Entity.Entities.Common
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public bool State { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime CreatedDate { get; set; }

    }
}
