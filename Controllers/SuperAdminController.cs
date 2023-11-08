using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using liveraryIdentity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;

namespace liveraryIdentity.Controllers
{
    [Authorize(Roles="SuperAdmin")]
    public class SuperAdmin : Controller
    {
        private readonly UserManager<IdentityUser> userManager;
        public SuperAdmin(UserManager<IdentityUser> userManager)
        {
            this.userManager = userManager;
        }

        public async Task<IActionResult> DeleteUser(string id)
        {
            var user = await userManager.FindByIdAsync(id);

            if(user == null)
            {
                ViewBag.ErrorMessage = $"User with Id = {id} cannot be found";
                return View("NotFound");
            }
            else
            {
                var result = await userManager.DeleteAsync(user);

                if(result.Succeeded)
                {
                    return RedirectToAction("UserList", "SuperAdmin");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }

                return View("UserList");
            }
        }

        [HttpGet]
        public IActionResult UserList()
        {
            var users = userManager.Users;
            return View(users);
        }

        [HttpGet]
        public async Task<IActionResult> ViewDetails(string id)
        {
            var user = await userManager.FindByIdAsync(id);

            if(user == null)
            {
                ViewBag.ErrorMessage = $"User with Id = {id} cannot be found";
                return View("NotFound");
            }
            
            var model = new EditViewModel
            {
                Id = user.Id,
                Email = user.Email,
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> ViewDetails(EditViewModel model)
        {
            var user = await userManager.FindByIdAsync(model.Id);

            if(user == null)
            {
                ViewBag.ErrorMessage = $"User with Id = {model.Id} cannot be found";
                return View("NotFound");
            } else {
                user.Email = model.Email;
                user.UserName = model.Email;


                var result = await userManager.UpdateAsync(user);

                if(result.Succeeded)
                {
                    return RedirectToAction("UserList", "SuperAdmin");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }

                return View(model);
            }
            
            
        }
        

        
    }
}