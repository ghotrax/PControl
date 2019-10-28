using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using proyectokeneth.Areas.Identity.Data;
using proyectokeneth.Models;
using proyectokeneth.Models.Entities;

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
        [Route("Usuarios/MisPasos")]
        public async Task<IActionResult> Steps()
        {
            var steps = await _context.PasosUsuariosDetalle
                .Include(p => p.PlantillaPasoDetalleNavigation)
                    .ThenInclude(p => p.PasoNavigation)
                .Include(p => p.PlantillaPasoDetalleNavigation)
                    .ThenInclude(p => p.EstadoNavigation)
                .Where(p => p.AspNetUser == User.FindFirstValue(ClaimTypes.NameIdentifier))
                .ToListAsync();
            return View(steps);
        }

        [HttpGet]
        [Route("Usuarios/MisPasos/Gestionar/{id}")]
        public async Task<IActionResult> ManageUserSteps(int id)
        {
            ViewData["Status"] = new SelectList(_context.Acciones, "IdAccion", "Nombre");
            var model = await _context.PasosUsuariosDetalle
                .Include(p => p.PlantillaPasoDetalleNavigation)
                    .ThenInclude(p => p.PasoNavigation)
                        .ThenInclude(p => p.PasosInstanciasDatosDetalle)
                            .ThenInclude(p => p.InstanciaPlantillaDatoNavigation)
                                .ThenInclude(p => p.IdDatoTipoNavigation)
                .Where(p => p.IdPasosUsuarios == id)
                .FirstOrDefaultAsync();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Usuarios/MisPasos/Gestionar/{id}")]
        public async Task<IActionResult> ManageUserSteps(int id, PasosUsuariosDetalle step)
        {
            if (ModelState.IsValid)
            {
                var stepInDb = await _context.PasosUsuariosDetalle
                .Include(p => p.PlantillaPasoDetalleNavigation)
                    .ThenInclude(p => p.PasoNavigation)
                        .ThenInclude(p => p.PasosInstanciasDatosDetalle)
                            .ThenInclude(p => p.InstanciaPlantillaDatoNavigation)
                                .ThenInclude(p => p.IdDatoTipoNavigation)
                .Where(p => p.IdPasosUsuarios == id)
                .FirstOrDefaultAsync();
                stepInDb.PlantillaPasoDetalleNavigation.Estado = step.PlantillaPasoDetalleNavigation.Estado;
                foreach (var i in step.PlantillaPasoDetalleNavigation.PasoNavigation.PasosInstanciasDatosDetalle)
                {
                    foreach (var j in stepInDb.PlantillaPasoDetalleNavigation.PasoNavigation.PasosInstanciasDatosDetalle)
                    {
                        if (i.IdPasosInstanciasDatos == j.IdPasosInstanciasDatos)
                        {
                            j.InstanciaPlantillaDatoNavigation.DatoTexto = i.InstanciaPlantillaDatoNavigation.DatoTexto;
                            j.InstanciaPlantillaDatoNavigation.DatoFecha = i.InstanciaPlantillaDatoNavigation.DatoFecha;
                            j.InstanciaPlantillaDatoNavigation.DatoNumerico = i.InstanciaPlantillaDatoNavigation.DatoNumerico;
                            j.InstanciaPlantillaDatoNavigation.DatoDecimal = i.InstanciaPlantillaDatoNavigation.DatoDecimal;
                        }
                    }
                }
                _context.PasosUsuariosDetalle.Update(stepInDb);
                await _context.SaveChangesAsync();
                TempData["Success"] = "Actualizacion de paso exitoso.";
                return RedirectToAction(nameof(Steps));
            }
            else
            {
                ViewData["Status"] = new SelectList(_context.Acciones, "IdAccion", "Nombre");
                return View(step);
            }
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
        public async Task<IActionResult> AssignSteps(int userName)
        {
            ViewData["UserName"] = userName;
            return View();
        }
    }
}