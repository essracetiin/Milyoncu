using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Milyoncu.Entity.Concrete;
using Milyoncu.Repos.Abstract;
using Milyoncu.Repos.Concrete;
using Milyoncu.Uow;
using System.Net.Mime;

namespace Milyoncu.API.Controllers
{
    [Route("api/[controller]")]
    [Produces(MediaTypeNames.Application.Json)]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryRep _categoryRep;
        IUow _uow;
        public CategoryController(ICategoryRep categoryRep, IUow uow)
        {
            _categoryRep = categoryRep;
            _uow = uow;
        }
        [HttpGet]
        public IActionResult GetCategories()
        {
            var categories = _categoryRep.GetCategories();
            return this.Ok(categories);
        }
        [HttpGet("GetCategoryById")]
        public IActionResult GetCategoryById(int CategoryId)
        {
            var categories = _categoryRep.GetCategoryById(CategoryId);
            return this.Ok(categories);

        }
        [HttpPost]
        public IActionResult Create(Category category)
        {
            var categories = _categoryRep.CreateCategory(category);
            _uow.Commit();
            return this.Ok(categories);
        }
        [HttpPut]
        public IActionResult Update(Category category)
        {
            var categories = _categoryRep.UpdateCategory(category);
            _uow.Commit();
            return this.Ok(categories);
        }
        [HttpDelete]
        public IActionResult Delete(Category category)
        {
            var categories = _categoryRep.DeleteCategory(category);
            _uow.Commit();
            return this.Ok(categories);
        }
    }
}