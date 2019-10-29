using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
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
    public class PlantillasController : Controller
    {
        private readonly proyectokenethContext _context;
        private readonly UserManager<proyectokenethUser> _userManager;

        public PlantillasController(proyectokenethContext context, UserManager<proyectokenethUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        public async Task<IActionResult> InstanciarPlantilla(int id)
        {
            var model = new Plantillas { IdPlantilla = id };
            return View(model);
        }
        // GET: Plantillas
        public async Task<IActionResult> Index()
        {
            return View(await _context.Plantillas.ToListAsync());
        }

        // GET: Plantillas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var plantillas = await _context.Plantillas
                .Include(p => p.PlantillasPasosDetalle)
                    .ThenInclude(p => p.PasoNavigation)
                .Include(p => p.PlantillasPasosDetalle)
                    .ThenInclude(p => p.PlantillasPasosUsuariosDetalle)
                        .ThenInclude(p => p.AspNetUserNavigation)
                .Include(p => p.PlantillasCamposDetalle)
                    .ThenInclude(p => p.IdDatoTipoNavigation)
                .FirstOrDefaultAsync(m => m.IdPlantilla == id);
            if (plantillas == null)
            {
                return NotFound();
            }

            return View(plantillas);
        }

        // GET: Plantillas/Create
        [Route("Plantillas/Create")]
        [Route("Plantillas/Create/{steps}/{fields}")]
        public IActionResult Create(int? steps, int? fields)
        {
            var templateSteps = new List<PlantillasPasosDetalle>();
            for (int i = 0; i < steps.GetValueOrDefault(); i++)
            {
                templateSteps
                    .Add(new PlantillasPasosDetalle() { PlantillasPasosUsuariosDetalle = new List<PlantillasPasosUsuariosDetalle>() });
            }
            var templateFields = new List<PlantillasCamposDetalle>();
            for (int i = 0; i < fields.GetValueOrDefault(); i++)
            {
                templateFields
                    .Add(new PlantillasCamposDetalle());
            }
            var model = new Plantillas
            {
                PlantillasPasosDetalle = templateSteps,
                PlantillasCamposDetalle = templateFields
            };
            SetupCreateViewBag();
            return View(model);
        }

        [HttpPost]
        [Route("Plantillas/AddStep")]
        public IActionResult AddStep(Plantillas plantilla)
        {
            plantilla.PlantillasPasosDetalle
                .Add(new PlantillasPasosDetalle() { PlantillasPasosUsuariosDetalle = new List<PlantillasPasosUsuariosDetalle>() });
            SetupCreateViewBag();
            return View(nameof(Create), plantilla);
        }

        [HttpPost]
        [Route("Plantillas/AddField")]
        public IActionResult AddField(Plantillas plantilla)
        {
            plantilla.PlantillasCamposDetalle
                .Add(new PlantillasCamposDetalle());
            SetupCreateViewBag();
            return View(nameof(Create), plantilla);
        }

        [HttpPost]
        [Route("Plantillas/AddUser/{step}")]
        public IActionResult AddUser(Plantillas plantilla, int step)
        {
            if (plantilla.PlantillasPasosDetalle[step].PlantillasPasosUsuariosDetalle == null)
            {
                plantilla.PlantillasPasosDetalle[step].PlantillasPasosUsuariosDetalle = new List<PlantillasPasosUsuariosDetalle>
                {
                    new PlantillasPasosUsuariosDetalle()
                };
            }
            else
            {
                plantilla.PlantillasPasosDetalle[step].PlantillasPasosUsuariosDetalle.Add(new PlantillasPasosUsuariosDetalle());
            }
            SetupCreateViewBag();
            return View(nameof(Create), plantilla);
        }

        // POST: Plantillas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Plantillas/Create")]
        public async Task<IActionResult> Create(Plantillas plantillas)
        {
            if (ModelState.IsValid)
            {
                _context.Add(plantillas);
                await _context.SaveChangesAsync();
                TempData["Success"] = "Plantilla creada exitosamente";
                return RedirectToAction(nameof(Index));
            }
            SetupCreateViewBag();
            return View(plantillas);
        }

        private void SetupCreateViewBag()
        {
            ViewData["DataTypes"] = new SelectList(_context.DatoTipo, "IdDatoTipo", "Nombre");
            ViewData["Users"] = new SelectList(_userManager.Users, "Id", "UserName");
        }

        // GET: Plantillas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var plantillas = await _context.Plantillas.FindAsync(id);
            if (plantillas == null)
            {
                return NotFound();
            }
            return View(plantillas);
        }

        // POST: Plantillas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdPlantilla,Nombre,Descripcion")] Plantillas plantillas)
        {
            if (id != plantillas.IdPlantilla)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(plantillas);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PlantillasExists(plantillas.IdPlantilla))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(plantillas);
        }

        // GET: Plantillas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var plantillas = await _context.Plantillas
                .FirstOrDefaultAsync(m => m.IdPlantilla == id);
            if (plantillas == null)
            {
                return NotFound();
            }

            return View(plantillas);
        }

        // POST: Plantillas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var plantillas = await _context.Plantillas.FindAsync(id);
            _context.Plantillas.Remove(plantillas);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PlantillasExists(int id)
        {
            return _context.Plantillas.Any(e => e.IdPlantilla == id);
        }

        //[HttpPost]
      //  [Authorize(Roles = "Administrador")]
        [Route("Plantillas/Instance/{id}")]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Instance(int id)
        {
            var plantilla = await _context.Plantillas
                .Include(p => p.PlantillasPasosDetalle)
                    .ThenInclude(p => p.PasoNavigation)
                .Include(p => p.PlantillasPasosDetalle)
                    .ThenInclude(p => p.PlantillasPasosUsuariosDetalle)
                        .ThenInclude(p => p.AspNetUserNavigation)
                .Include(p => p.PlantillasCamposDetalle)
                    .ThenInclude(p => p.IdDatoTipoNavigation)
                .FirstOrDefaultAsync(m => m.IdPlantilla == id);
            if (plantilla == null)
            {
                return NotFound();
            }

            var currentUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var steps = new List<InstanciasPlantillasPasosDetalle>();
            foreach (var templateStep in plantilla.PlantillasPasosDetalle)
            {
                var templateStepsUsers = new List<PasosUsuariosDetalle>();
                foreach (var usersInStep in templateStep.PlantillasPasosUsuariosDetalle)
                {
                    templateStepsUsers.Add(
                        new PasosUsuariosDetalle
                        {
                            AspNetUser = usersInStep.AspNetUser
                        }
                    );
                }
                steps.Add(
                    new InstanciasPlantillasPasosDetalle
                    {
                        AspNetUser = currentUserId,
                        PasosUsuariosDetalle = templateStepsUsers,
                        PasoNavigation = new PasosInstancias
                        {
                            Nombre = templateStep.PasoNavigation.Nombre,
                            Descripcion = templateStep.PasoNavigation.Descripcion
                        }
                    }
                );
            }

            var fields = new List<InstanciasPlantillasDatosDetalle>();
            foreach (var templateField in plantilla.PlantillasCamposDetalle)
            {
                fields.Add(
                    new InstanciasPlantillasDatosDetalle
                    {
                        NombreCampo = templateField.NombreCampo,
                        IdDatoTipo = templateField.IdDatoTipo,
                    }
                );
            }

            var instance = new InstanciasPlantillas
            {
                Nombre = $"{plantilla.Nombre}",
                Descripcion = plantilla.Descripcion,
                AspNetUser = currentUserId,
                Fecha = DateTime.Now,
                Estado = "0",
                Iniciada = "0",
                InstanciasPlantillasPasosDetalle = steps,
                InstanciasPlantillasDatosDetalle = fields,
            };

            _context.Add(instance);
            await _context.SaveChangesAsync();

            TempData["Success"] = "Plantilla instanciada exitosamente.";
            return RedirectToAction(nameof(InstanciasPlantillasController.Assign), nameof(InstanciasPlantillas), new { id = instance.IdInstanciaPlantilla });
        }
    }
}