using Contacts.API.Interfaces;
using Contacts.API.Models;

namespace Contacts.API.Services
{
    //Rozdzieliliśmy serwis od kontrolera, aby trzymać w nim logike metod, a w kontrolerze zostawić tylko endpointy. Tutaj jak na cruda przystało logiki jest mało, ale w większych projektach to pomaga.
    public class CategoriesService : ICategoriesService //Dziedziczymy po interfejsie.
    {
        private readonly ICategoriesRepositroy _categoriesRepositroy;

        //Wstrzykujemy repozytorium do serwisu.
        public CategoriesService(ICategoriesRepositroy categoriesRepositroy)
        {
            _categoriesRepositroy = categoriesRepositroy;
        }

        //Pobieramy wszystkie kategorie z repo.
        public async Task<List<Category>> GetCategories()
        {
            return await _categoriesRepositroy.GetCategories();
        }

        //Pobieramy subkategorie z repo dla kategorii "Służbowy"
        public async Task<List<Subcategory>> GetBusinessSubCategories()
        {
            return await _categoriesRepositroy.GetBusinessSubCategories();
        }

        //Dodajemy nową subkategorię.
        public async Task AddNewSubcategory(string subcategoryName)
        {
            //Tworzymy nowy obiekt kategorii.
            Subcategory subcategory = new()
            {
                SubcategoryName = subcategoryName
                //Jeżeli mamy inne pola w modelu możemy je tutaj uwzględnić. Inaczej są defaultowe (Takie jak określilismy w modelu).
            };

            //Odwołanie do repo.
            await _categoriesRepositroy.subcategoryName(subcategory);
        }

        //Pobieramy id subkategorii po jej nazwie.
        public async Task<int> GetSubcategoryIdBySubcategoryName(string subcategoryName)
        {
            return await _categoriesRepositroy.GetSubcategoryIdBySubcategoryName(subcategoryName);
        }

        //Pobieramy nazwe subkategorii po jej id.
        public async Task<string> GetSubcategoryNameById(int id)
        {
            return await _categoriesRepositroy.GetSubcategoryNameById(id);
        }
    }
}
