using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyApiProject.BusinesLayer.Abstract;
using MyApiProject.DtoLayer.CategoryDtos;
using MyApiProject.DtoLayer.ProductDtos;
using MyApiProject.EntityLayer.Concrete;

namespace MyApiProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        public readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public IActionResult ProductList()
        {
            var values = _productService.TGetAll();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateProduct(CreateProductDto createCategoryDto)
        {
            Product product = new Product();
            product.ProductStock = createCategoryDto.ProductStock;
            product.ProductPrice = createCategoryDto.ProductPrice;
            product.ProductName = createCategoryDto.ProductName;
            product.CategoryId= createCategoryDto.CategoryId;
            _productService.TInsert(product);
            return Ok("Ekleme başarılı");
        }

        [HttpDelete]
        public IActionResult DeleteProduct(int id) 
        {
            _productService.TDelete(id);
            return Ok("işlem başarılı");
        }

        [HttpGet("GetProduct")]
        public IActionResult GetProduct(int id) 
        {

            var value = _productService.TGetById(id);
            return Ok(value);
        }

        [HttpPut]
        public IActionResult UpdateProduct(UpdateProductDto updateProductDto)
        {
            Product product = new Product();
            product.ProductStock = updateProductDto.ProductStock;
            product.ProductPrice = Convert.ToInt32(updateProductDto.ProductPrice);
            product.ProductId = updateProductDto.ProductId;
            product.ProductName= updateProductDto.ProductName;  
            _productService.TUpdate(product);
            return Ok("Güncelleme başarılı");

        }
    }
}
