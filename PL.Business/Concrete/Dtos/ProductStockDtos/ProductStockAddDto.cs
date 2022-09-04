using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL.Business.Concrete.Dtos.ProductStockDtos
{
    public class ProductStockAddDto
    {
        public int ProductId { get; set; }
        public int StockCount { get; set; }
        public bool State { get; set; }
    }
}
