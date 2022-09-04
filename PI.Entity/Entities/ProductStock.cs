using PL.Entity.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL.Entity.Entities
{
    public class ProductStock:BaseEntity
    {
        public int ProductId { get; set; }
        public int StockCount { get; set; }
    }
}
