using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PL.Business.Abstract.Services;
using PL.Business.Concrete.Dtos.ProductDtos;
using PL.Business.Concrete.Dtos.ProductStockDtos;
using PL.Business.Helpers.Api;
using PL.Entity.Entities;

namespace PLStoc.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductStockController : ControllerBase
    {
        private readonly ILogger<ProductStockController> logger;
        private readonly IProductStockService productStockService;

        public ProductStockController(IProductStockService productStockService, ILogger<ProductStockController> logger)
        {
            this.productStockService = productStockService;
            this.logger = logger;
        }

        [HttpPut("/addstock")]
        public async Task<IActionResult> AddStock(ManageStockDto dto)
        {
            logger.LogInformation("Start AddStock method in ProductStockController.");
            if (dto.ProductId == 0 || dto == null) return BadRequest("İnvalidProductId");
            var url = "http://localhost:5265/product/"+dto.ProductId;
            var result = await Api<ProductGetDto>.GetAsync(url);
            var product=result.FirstOrDefault();
            if (product != null)
            {
                var productstocks=await productStockService.GetByProductIdAsync(dto.ProductId);
                
                if (productstocks.Status)
                {
                    var productstock = productstocks.List.FirstOrDefault();
                    productstock.StockCount += dto.Count;
                    var updatedto = new ProductStockUpdateDto();
                    updatedto.ProductId = productstock.ProductId;
                    updatedto.StockCount = productstock.StockCount;
                    updatedto.Id = productstock.Id;
                    updatedto.State = productstock.State;
                    var updateresult = await productStockService.UpdateAsync(updatedto);
                    if (updateresult.Status)
                    {
                        return Ok();
                    }
                    else
                    {
                        logger.LogError(updateresult.Message + " in ProductStockController AddStock method");
                        return NotFound();
                    }
                    
                }
                else
                {
                    logger.LogWarning(productstocks.Message + " in ProductStockController AddStock method");
                    return BadRequest(productstocks.Message);
                }
            }
            logger.LogWarning("İnvalidProductId");
            return BadRequest("İnvalidProductId");
        }
        [HttpPut("/removestock")]
        public async Task<IActionResult> RemoveStock(ManageStockDto dto)
        {
            logger.LogInformation("Start RemoveStock method in ProductStockController.");
            if (dto.ProductId == 0 || dto == null) return BadRequest("İnvalidProductId");
            var url = "http://localhost:5265/product/" + dto.ProductId;
            var result = await Api<ProductGetDto>.GetAsync(url);
            var product = result.FirstOrDefault();
            if (product != null)
            {
                var productstocks = await productStockService.GetByProductIdAsync(dto.ProductId);

                if (productstocks.Status)
                {
                    var productstock = productstocks.List.FirstOrDefault();
                    if (productstock.StockCount == 0)
                    {
                        logger.LogWarning("OutOfStock" + " in ProductStockController RemoveStock method");
                        return BadRequest("OutOfStock");
                    }
                    else if(productstock.StockCount >= dto.Count)
                    {
                        productstock.StockCount -= dto.Count;
                        var updatedto = new ProductStockUpdateDto();
                        updatedto.ProductId = productstock.ProductId;
                        updatedto.StockCount = productstock.StockCount;
                        updatedto.Id = productstock.Id;
                        updatedto.State = productstock.State;
                        var updateresult = await productStockService.UpdateAsync(updatedto);
                        if (updateresult.Status)
                        {
                            return Ok();
                        }
                        else
                        {
                            logger.LogError(updateresult.Message + " in ProductStockController RemoveStock method");
                            return NotFound();
                        }
                    }
                    else
                    {
                        logger.LogWarning("NotEnough" + " in ProductStockController RemoveStock method");
                        return BadRequest("NotEnough");
                    }
                    

                }
                else
                {
                    logger.LogWarning(productstocks.Message + " in ProductStockController RemoveStock method");
                    return BadRequest(productstocks.Message);
                }
            }

            logger.LogWarning("İnvalidProductId");
            return BadRequest("İnvalidProductId");
        }
        [HttpGet("/getstock/{productId:int}")]

        public async Task<IActionResult> Get(int productId)
        {
            logger.LogInformation("Start Get method in ProductStockController.");
            if (productId == 0 ) return BadRequest("İnvalidProductId");
            var url = "http://localhost:5265/product/" + productId;
            var result = await Api<ProductGetDto>.GetAsync(url);
            var product = result.FirstOrDefault();
            if (product != null)
            {
                var productstocks = await productStockService.GetByProductIdAsync(productId);

                if (productstocks.Status)
                {
                    return Ok(new{ 
                        productid=productstocks.List.FirstOrDefault().ProductId,
                        stockproduct=productstocks.List.FirstOrDefault().StockCount
                    });
                   


                }
                else
                {
                    logger.LogWarning(productstocks.Message + " in ProductStockController RemoveStock method");
                    return BadRequest(productstocks.Message);
                }
            }
            logger.LogWarning("İnvalidProductId");
            return BadRequest("İnvalidProductId");
        }
    }
}
