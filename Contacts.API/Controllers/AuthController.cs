﻿using Microsoft.AspNetCore.Mvc;

namespace Contacts.API.Controllers
{
    public class AuthController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
