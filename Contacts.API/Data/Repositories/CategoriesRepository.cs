using Contacts.API.Interfaces;
using Contacts.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Contacts.API.Data.Repositories
{
    //Rozdzielamy repozytorium do serwisu, aby zostawić w nim samą logikę. W repo łączymy się z bazą danych, na której wykonujemy operacje.
    public class CategoriesRepository : ICategoriesRepositroy //Dziedziczymy po interface
    {
        private readonly DataContext _db;
        //Wstrzykujemy kontekst bazy danych do repo.
        public CategoriesRepository(DataContext db)
        {
            _db = db;
        }

        //Pobieramy wszystkie kategorie.
        public async Task<List<Category>> GetCategories()
        {
            return await _db.Categories.ToListAsync();
        }

        //Pobieramy subkategoire dla kategorii "służbowy"
        public async Task<List<Subcategory>> GetBusinessSubCategories()
        {
            return await _db.Subcategories.Where(subcategory => subcategory.SubcategoryId == 1 || subcategory.SubcategoryId == 2).ToListAsync(); //Nasze subkategorie mają na "sztywno" id 1, 2. Nie jest to najlepsze rozwiązanie dla rozwoju, chociaż spełnia wymagania.
        }

        //Dodajemy nową subkategorie.
        public async Task subcategoryName(Subcategory subcategory) //Na wejściu przyjmujemy obiekt.
        {
            _db.Subcategories.Add(subcategory); //Dodajemy
            await _db.SaveChangesAsync(); //Zapis zmian.
        }

        //Pobieramy subkategoria id po jej nazwie.
        public async Task<int> GetSubcategoryIdBySubcategoryName(string subcategoryName)
        {
            var subcategory = await _db.Subcategories.FirstOrDefaultAsync(x => x.SubcategoryName == subcategoryName);
            return subcategory.SubcategoryId;
        }

        //Pobieramy nazwe subkategorii po id.
        public async Task<string> GetSubcategoryNameById(int id)
        {
            var subcategory = await _db.Subcategories.FirstOrDefaultAsync(x => x.SubcategoryId == id);
            return subcategory.SubcategoryName;
        }
    }
}
