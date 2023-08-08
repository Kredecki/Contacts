﻿using Contacts.API.BindingModels;
using Contacts.API.Interfaces;
using Contacts.API.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Contacts.API.Controllers
{
    public class AuthController : Controller
    {
        public readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> SignUp([FromForm] SignUp model)
        {
            if (ModelState.IsValid)
            {
                bool result = await _authService.SignUp(model);
                if (result)
                    return Ok();
            }

            return BadRequest();
        }


        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> SignIn([FromForm] SignIn model)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid username or password");

            bool result = await _authService.SignIn(model);

            if (result)
                return Ok(new { message = "Login successful" });

            return BadRequest("Invalid username or password");
        }
    }
}
