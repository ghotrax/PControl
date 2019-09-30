using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using proyectokeneth.Areas.Identity.Data;
using proyectokeneth.Models;

namespace proyectokeneth.Controllers
{
    [Authorize]
    public class UsuariosController : Controller
    {
        private readonly proyectokenethContext _context;
        private readonly UserManager<proyectokenethUser> _userManager;

        public UsuariosController(
            proyectokenethContext context,
            UserManager<proyectokenethUser> userManager,
            IHttpContextAccessor httpContextAccessor,
            IAuthorizationService authorizationService)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var users = await _userManager.Users
                .Take(30)
                .ToListAsync();
            return View(users.OrderBy(u => u.Email));
        }

        [HttpGet]
        [Route("Usuarios/Eliminar/{userName}")]
        public async Task<IActionResult> Delete(string userName)
        {
            var user = await _userManager.Users
                .FirstOrDefaultAsync(u => u.UserName == userName);

            if (user == null)
            {
                NotFound();
            }
            return View(user);
        }

        [HttpPost]
        [Route("Usuarios/Eliminar/{userName}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string userName)
        {
            var user = await _userManager.Users
                .FirstOrDefaultAsync(u => u.UserName == userName);

            if (user == null)
            {
                NotFound();
            }

            var userEmail = user.Email;

            var result = await _userManager.DeleteAsync(user);
            if (!result.Succeeded)
            {
                TempData["Warning"] = "El usuario no ha podido ser eliminado (Ya no existe?).";
            }
            else
            {
                TempData["Success"] = $"El usuario {userEmail} fue eliminado exitosamente.";
            }
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        [Route("Usuarios/AsignarPasos/{userName}")]
        public async Task<IActionResult> AssignSteps(string userName)
        {
            ViewData["UserName"] = userName;
            return View();
        }
    }
}