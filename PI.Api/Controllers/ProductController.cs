using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PL.Business.Abstract.Services;
using PL.Business.Concrete.Dtos.ProductDtos;

namespace PI.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ILogger<ProductController> logger;
        private readonly IProductService productService;

        public ProductController(ILogger<ProductController> logger, IProductService productService)
        {
            this.logger = logger;
            this.productService = productService;
        }


        [HttpGet("/products")]
        public async Task<IActionResult> Get()
        {
            logger.LogInformation("Start Get method in ProductController.");
            var result = await productService.GetAllForStateAsync(true, "Category");

            if (result.Status)
            {
                logger.LogInformation(result.Message + " in ProductController Get method");
                return Ok(result.List);
            }
            else
            {
                logger.LogError(result.Message + " in ProductController Get method");
                return NotFound(result.Message);
            }
        }

        [HttpPost("/product")]
        public async Task<IActionResult> Add(ProductAddDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            logger.LogInformation("Start Add method in ProductController.");
            var result = await productService.AddAsync(dto);
            if (result.Status)
            {
                logger.LogInformation(result.Message + " in ProductController Add method");
                return Ok();
            }
            else
            {
                logger.LogError(result.Message + " in ProductController Add method");
                return NotFound(result.Message);
            }
        }

        [HttpPut("/product")]
        public async Task<IActionResult> Update(ProductUpdateDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            logger.LogInformation("Start Update method in ProductController.");
            var result = await productService.UpdateAsync(dto);
            if (result.Status)
            {
                logger.LogInformation(result.Message + " in ProductController Update method");
                return Ok();
            }
            else
            {
                logger.LogError(result.Message + " in ProductController Update method");
                return NotFound(result.Message);
            }
        }

        [HttpDelete("/product/{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            logger.LogInformation("Start Delete method in ProductController.");
            var result = await productService.DeleteAsync(id);
            if (result.Status)
            {
                logger.LogInformation(result.Message + " in ProductController Delete method");
                return Ok();
            }
            else
            {
                logger.LogError(result.Message + " in ProductController Delete method");
                return NotFound(result.Message);
            }
        }

        [HttpGet("/GetById/{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            logger.LogInformation("Start GetById method in ProductController.");
            var result = await productService.GetByIdAsync(id, "Category");
            if (result.Status)
            {
                logger.LogInformation(result.Message + " in ProductController GetById method");
                return Ok(result.List);
            }
            else
            {
                logger.LogError(result.Message + " in ProductController GetById method");
                return NotFound(result.Message);
            }
        }
    }
}
