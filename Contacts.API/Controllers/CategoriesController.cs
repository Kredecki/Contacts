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
    }
}
