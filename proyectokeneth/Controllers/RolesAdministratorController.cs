using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using proyectokeneth.Areas.Identity.Data;
using proyectokeneth.Models;
using proyectokeneth.Models.Entities;

namespace proyectokeneth.Controllers
{
    [Authorize]
    //   [Authorize(Roles ="Administrador")]
    public class RolesAdministratorController : Controller
    {
        private readonly RoleManager<IdentityRole> roleManager;

        public UserManager<proyectokenethUser> UserManager;

        public RolesAdministratorController(RoleManager<IdentityRole> roleMgr,
                                             UserManager<proyectokenethUser> userManager)
        {
            roleManager = roleMgr;
            UserManager = userManager;
        }


        [HttpGet]
        public IActionResult CreateRole()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateRole(CreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                IdentityRole identityRole = new IdentityRole
                {
                    Name = model.RoleName
                };
                IdentityResult result = await roleManager.CreateAsync(identityRole);

                if (result.Succeeded)
                {
                    return RedirectToAction("index", "home");
                }
                foreach (IdentityError error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }

            return View(model);
        }
        [HttpGet]
        public ViewResult ListRole() => View(roleManager.Roles);

        [HttpGet]
        public async Task<IActionResult> EditRole(string id)
        {
            var role = await roleManager.FindByIdAsync(id);

            if (role == null)
            {
                ViewBag.Error = $"rol con id = {id} no existe";
                return View("NotFound");
            }

            var model = new EditRoleViewModel
            {
                id = role.Id,
                RoleName = role.Name
            };

            foreach (var user in UserManager.Users)
            {
             if (await  UserManager.IsInRoleAsync(user, role.Name))
                {
                    model.Users.Add(user.UserName);
                }
            }
            return View(model);
        }


        [HttpPost]
        public async Task<IActionResult> EditRole(EditRoleViewModel model)
        {
            var role = await roleManager.FindByIdAsync(model.id);

            if (role == null)
            {
                ViewBag.Error = $"rol con id = {model.id} no existe";
                return View("NotFound");
            }
            else
            {
                role.Name = model.RoleName;
               var result =  await roleManager.UpdateAsync(role);
                if(result.Succeeded)
                {
                    return RedirectToAction("ListRole");
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
                return View(model);
            }

           
        }
        [HttpGet]
        public async Task<IActionResult> EditUserInRole(String roleId)
        {
            ViewBag.roleId = roleId; 

            var role = await roleManager.FindByIdAsync(roleId);

            if (role == null)
            {
                ViewBag.Error = $"rol con id = {roleId} no existe";
                return View("NotFound");
            }
            var model = new List<UserRolViewModel>();

            foreach(var user in UserManager.Users)
            {
                var userRolViewModel = new UserRolViewModel
                {
                    UserId = user.Id,
                    UserName = user.UserName,

                };
                if(await UserManager.IsInRoleAsync(user, role.Name))
                {
                    userRolViewModel.IsSelected = true;
                }
                else
                {
                    userRolViewModel.IsSelected = false;
                }
                model.Add(userRolViewModel);
            }
            return View(model);

        }
        [HttpPost]
        public async Task<IActionResult> EditUserInRole(List<UserRolViewModel> model ,String roleId)
        {
            var role = await roleManager.FindByIdAsync(roleId);

            if (role == null)
            {
                ViewBag.Error = $"rol con id = {roleId} no existe";
                return View("NotFound");
            }
            for(int i= 0; i < model.Count; i++)
            {
              var user = await UserManager.FindByIdAsync(model[i].UserId);

                IdentityResult result = null;

                if (model[i].IsSelected && !(await UserManager .IsInRoleAsync(user, role.Name)))
                {
                   result = await  UserManager.AddToRoleAsync(user, role.Name);
                }
                else if (!model[i].IsSelected && await UserManager.IsInRoleAsync(user, role.Name))
                {
                    result = await UserManager.RemoveFromRoleAsync(user, role.Name);
                }
                else
                {
                    continue;
                }
                if(result.Succeeded)
                {
                    if(i < (model.Count - 1))
                    {
                        continue;
                    }
                    else
                    {
                        return RedirectToAction("EditRole", new { Id = roleId });
                    }
                }
            }


            return RedirectToAction("EditRole", new { Id = roleId });
        }
     }
}