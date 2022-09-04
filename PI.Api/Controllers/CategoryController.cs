using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PL.Business.Abstract.Services;
using PL.Business.Concrete.Dtos.CategoryDtos;

namespace PI.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ILogger<CategoryController> logger;
        private readonly ICategoryService categoryService;

        public CategoryController(ILogger<CategoryController> logger, ICategoryService categoryService)
        {
            this.logger = logger;
            this.categoryService = categoryService;
        }

        [HttpGet("/categories")]
        public async Task<IActionResult> Get()
        {
            logger.LogInformation("Start Get method in CategoryController.");
            var result = await categoryService.GetAllForStateAsync(true, "Products");

            if (result.Status)
            {
                logger.LogInformation(result.Message + " in CategoryController Get method");
                return Ok(result.List);
            }
            else
            {
                logger.LogError(result.Message + " in CategoryController Get method");
                return NotFound(result.Message);
            }
        }
        [HttpPost("/category")]
        public async Task<IActionResult> Add(CategoryAddDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            logger.LogInformation("Start Add method in ProductController.");
            var result = await categoryService.AddAsync(dto);
            if (result.Status)
            {
                logger.LogInformation(result.Message + " in CategoryController Add method");
                return Ok();
            }
            else
            {
                logger.LogError(result.Message + " in CategoryController Add method");
                return NotFound(result.Message);
            }
        }
        [HttpPut("/category")]
        public async Task<IActionResult> Update(CategoryUpdateDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            logger.LogInformation("Start Update method in CategoryController.");
            var result = await categoryService.UpdateAsync(dto);
            if (result.Status)
            {
                logger.LogInformation(result.Message + " in CategoryController Update method");
                return Ok();
            }
            else
            {
                logger.LogError(result.Message + " in CategoryController Update method");
                return NotFound(result.Message);
            }
        }

        [HttpDelete("/category/{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            logger.LogInformation("Start Delete method in CategoryController.");
            var result = await categoryService.DeleteAsync(id);
            if (result.Status)
            {
                logger.LogInformation(result.Message + " in CategoryController Delete method");
                return Ok();
            }
            else
            {
                logger.LogError(result.Message + " in CategoryController Delete method");
                return NotFound(result.Message);
            }
        }

        [HttpGet("/category/{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            logger.LogInformation("Start GetById method in CategoryController.");
            var result = await categoryService.GetByIdAsync(id, "Products");
            if (result.Status)
            {
                logger.LogInformation(result.Message + " in CategoryController GetById method");
                return Ok(result.List);
            }
            else
            {
                logger.LogError(result.Message + " in CategoryController GetById method");
                return NotFound(result.Message);
            }
        }
    }
}
