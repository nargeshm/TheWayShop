using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PresentataionHost.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WS.Infrastruture.Sql;

namespace PresentataionHost.Controllers
{
    public class AdminController : Controller
    {
        private readonly UserManager<AppUser> userManager;
        private readonly IPasswordHasher<AppUser> hasher;

        public AdminController(UserManager<AppUser> userManager, IPasswordHasher<AppUser> hasher)
        {
            this.userManager = userManager;
            this.hasher = hasher;
        }
        [Authorize(Roles = "Admin")]
        public IActionResult Index()
        {
            var users = userManager.Users.ToList();
            List<UserViewModel> result = new List<UserViewModel>();
            foreach (var item in users)
            {
                result.Add(new UserViewModel()
                {
                    Email = item.Email
                    ,
                    Password = item.PasswordHash
                    ,
                    UserName = item.UserName
                    ,
                    PhoneNumber=item.PhoneNumber
                });
            }
            return View(result);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(UserViewModel model)
        {
            if (ModelState.IsValid)
            {
                AppUser appUser = new AppUser()
                {
                    UserName = model.UserName,
                    PhoneNumber=model.PhoneNumber,
                    Email = model.Email
                };
                IdentityResult result = userManager.CreateAsync(appUser, model.Password).Result;

                if (result.Succeeded)
                {
                    var r = userManager.AddToRoleAsync(appUser, "Guest").Result;
                    return RedirectToAction("index");
                }

                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError("", item.Description);
                }
            }
            return View(model);
        }

        public IActionResult Edit(string username)
        {
            AppUser user = userManager.FindByNameAsync(username).Result;
            UserViewModel result = new UserViewModel()
            {
                Email = user.Email,
                Password = user.PasswordHash,
                PhoneNumber=user.PhoneNumber,
                UserName = user.UserName
            };
            return View(result);
        }

        [HttpPost]
        public IActionResult Edit(UserViewModel userModel)
        {
            AppUser user = userManager.FindByNameAsync(userModel.UserName).Result;
            user.PasswordHash = hasher.HashPassword(user, userModel.Password);
            var result = userManager.UpdateAsync(user).Result;
            if (result.Succeeded)
            {
                return RedirectToAction("index");
            }

            foreach (var item in result.Errors)
            {
                ModelState.AddModelError("", item.Description);
            }
            return View(userModel);
        }



        public IActionResult Delete(string username)
        {
            AppUser user = userManager.FindByNameAsync(username).Result;
            if (user != null)
            {
                var result = userManager.DeleteAsync(user).Result;
            }
            return RedirectToAction("index");
        }
    }
}
