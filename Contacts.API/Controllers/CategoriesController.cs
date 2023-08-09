using Contacts.API.Interfaces;
using Contacts.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace Contacts.API.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly ICategoriesService _categoriesService;

        public CategoriesController(ICategoriesService categoriesService)
        {
            _categoriesService = categoriesService;
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<List<Category>> GetCategories()
        {
            return await _categoriesService.GetCategories();
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<List<Subcategory>> GetBusinessSubCategories()
        {
            return await _categoriesService.GetBusinessSubCategories();
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> AddNewSubcategory(string subcategoryName)
        {
            await _categoriesService.AddNewSubcategory(subcategoryName);
            return Ok();
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<int> GetSubcategoryIdBySubcategoryName(string subcategoryName)
        {
            return await _categoriesService.GetSubcategoryIdBySubcategoryName(subcategoryName);
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<string> GetSubcategoryNameById(int id)
        {
            return await _categoriesService.GetSubcategoryNameById(id);
        }
    }
}
