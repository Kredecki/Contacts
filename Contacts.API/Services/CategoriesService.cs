﻿using Contacts.API.Interfaces;
using Contacts.API.Models;

namespace Contacts.API.Services
{
    public class CategoriesService : ICategoriesService
    {
        private readonly ICategoriesRepositroy _categoriesRepositroy;
        public CategoriesService(ICategoriesRepositroy categoriesRepositroy)
        {
            _categoriesRepositroy = categoriesRepositroy;
        }

        public async Task<List<Category>> GetCategories()
        {
            return await _categoriesRepositroy.GetCategories();
        }
    }
}