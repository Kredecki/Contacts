using Contacts.API.Interfaces;
using Contacts.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace Contacts.API.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly ICategoriesService _categoriesService;

        //Dependency injection serwisu do kontrolera.
        public CategoriesController(ICategoriesService categoriesService)
        {
            _categoriesService = categoriesService;
        }

        //Endpoint REST API pobierający wszystkie kategorie.
        [HttpGet]
        [Route("[action]")]
        public async Task<List<Category>> GetCategories()
        {
            return await _categoriesService.GetCategories();
        }

        //Endpoint REST API zwracające subkategorie dla kategorii "Służbowy"
        [HttpGet]
        [Route("[action]")]
        public async Task<List<Subcategory>> GetBusinessSubCategories()
        {
            return await _categoriesService.GetBusinessSubCategories();
        }

        //Endpoint REST API tworzący nową kategorię.
        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> AddNewSubcategory(string subcategoryName)
        {
            await _categoriesService.AddNewSubcategory(subcategoryName);
            return Ok();
        }

        //Endpoint REST API z baaaardzo długą nazwą, który zwraca Id po nazwie subkategorii.
        [HttpGet]
        [Route("[action]")]
        public async Task<int> GetSubcategoryIdBySubcategoryName(string subcategoryName)
        {
            return await _categoriesService.GetSubcategoryIdBySubcategoryName(subcategoryName);
        }

        //Endpoint REST API zwracający nazwe subkategorii po jej id.
        [HttpGet]
        [Route("[action]")]
        public async Task<string> GetSubcategoryNameById(int id)
        {
            return await _categoriesService.GetSubcategoryNameById(id);
        }
    }
}
