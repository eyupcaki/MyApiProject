using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyApiProject.BusinesLayer.Abstract;
using MyApiProject.DtoLayer.CategoryDtos;
using MyApiProject.EntityLayer.Concrete;

namespace MyApiProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryControler : ControllerBase
    {

        private readonly ICategoryService _categoryService;

        public CategoryControler(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public IActionResult CategoryList()
        {
            var values = _categoryService.TGetAll();
            return Ok(values);
        }
        
        [HttpPost]
        public IActionResult Createategory(CreateCategoryDtos createCategoryDto)
        {
            Category category = new Category();
            category.CategoryName = createCategoryDto.CategoryName;
            _categoryService.TInsert(category);
            return Ok("Ekleme başarılı");
        }

        [HttpDelete]
        public IActionResult DeleteCategory(int id) 
        {
            _categoryService.TDelete(id);
            return Ok("silme başarılı");
        }

        [HttpGet("GetCategory")]

        public IActionResult GetCategory(int id)
        {
            var value=_categoryService.TGetById(id);
            return Ok(value);
        }

        [HttpPut]
        public IActionResult UpdateCategory(UpdateCategoryDto updateCategoryDto)
        {
            Category category=new Category();
            category.CategoryId=updateCategoryDto.CategoryId;
            category.CategoryName=updateCategoryDto.CategoryName;
            _categoryService.TUpdate(category);
            return Ok("Güncelleme başarılı");
        }

        [HttpGet("CategoryCount")]
        public IActionResult CategoryCount()
        {

            return Ok(_categoryService.TCategoryCount());

        }
    }
}
