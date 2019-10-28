using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using proyectokeneth.Models;
using proyectokeneth.Models.Entities;

namespace proyectokeneth.Controllers
{
    public class InstanciasPlantillasController : Controller
    {
        private readonly proyectokenethContext _context;

        public InstanciasPlantillasController(proyectokenethContext context)
        {
            _context = context;
        }

        // GET: InstanciasPlantillas
        public async Task<IActionResult> Index()
        {
            var pMStudioContext = _context.InstanciasPlantillas.Include(i => i.AspNetUserNavigation);
            return View(await pMStudioContext.ToListAsync());
        }

        // GET: InstanciasPlantillas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var instanciasPlantillas = await _context.InstanciasPlantillas
                .Include(i => i.AspNetUserNavigation)
                .FirstOrDefaultAsync(m => m.IdInstanciaPlantilla == id);
            if (instanciasPlantillas == null)
            {
                return NotFound();
            }

            return View(instanciasPlantillas);
        }

        // GET: InstanciasPlantillas/Create
        public IActionResult Create()
        {
            ViewData["AspNetUser"] = new SelectList(_context.Users, "Id", "Id");
            return View();
        }

        // POST: InstanciasPlantillas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdInstanciaPlantilla,Nombre,AspNetUser,Estado,Iniciada,Descripcion,Fecha")] InstanciasPlantillas instanciasPlantillas)
        {
            if (ModelState.IsValid)
            {
                _context.Add(instanciasPlantillas);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AspNetUser"] = new SelectList(_context.Users, "Id", "Id", instanciasPlantillas.AspNetUser);
            return View(instanciasPlantillas);
        }

        [HttpPost]
        [Route("InstanciasPlantillas/AddAssignment")]
        public IActionResult AddAssignment(InstanceAssignmentViewModel assignViewModel)
        {
            if(assignViewModel.Items == null)
            {
                assignViewModel.Items = new List<PasosInstanciasDatosDetalle>();
            }
            assignViewModel.Items.Add(new PasosInstanciasDatosDetalle());
            SetupAssignViewData(assignViewModel.Id);
            return View(nameof(Assign), assignViewModel);
        }

        public async Task<IActionResult> Assign(int id)
        {
            SetupAssignViewData(id);
            var model = new InstanceAssignmentViewModel
            {
                Id = id,
                Name = await _context.InstanciasPlantillas
                    .Where(a => a.IdInstanciaPlantilla == id)
                    .Select(a => a.Nombre)
                    .FirstOrDefaultAsync(),
                Items = new List<PasosInstanciasDatosDetalle>()
            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Assign(InstanceAssignmentViewModel assignViewModel)
        {
            if (ModelState.IsValid)
            {
                assignViewModel.Items.ForEach(a => a.SoloLectura = "0");
                _context.PasosInstanciasDatosDetalle.AddRange(assignViewModel.Items);
                await _context.SaveChangesAsync();
                TempData["Success"] = "Asignacion de pasos y capos con exito!";
                return RedirectToAction(nameof(Details), new { assignViewModel.Id });
            }
            else
            {
                SetupAssignViewData(assignViewModel.Id);
                return View(assignViewModel);
            }
        }

        private void SetupAssignViewData(int id)
        {
            var stepItems = _context.InstanciasPlantillasPasosDetalle
                .Include(a => a.PasoNavigation)
                .Where(a => a.InstanciaPlantilla == id)
                .Select(a => a.PasoNavigation);
            ViewData["Steps"] = new SelectList(stepItems, "IdPasoinstancia", "Nombre");
            ViewData["Fields"] = new SelectList(_context.InstanciasPlantillasDatosDetalle
                .Where(a => a.Instanciaplantilla == id), "IdInstanciaPlantillaDato", "NombreCampo");
        }

        // GET: InstanciasPlantillas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var instanciasPlantillas = await _context.InstanciasPlantillas.FindAsync(id);
            if (instanciasPlantillas == null)
            {
                return NotFound();
            }
            ViewData["AspNetUser"] = new SelectList(_context.Users, "Id", "Id", instanciasPlantillas.AspNetUser);
            return View(instanciasPlantillas);
        }

        // POST: InstanciasPlantillas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdInstanciaPlantilla,Nombre,AspNetUser,Estado,Iniciada,Descripcion,Fecha")] InstanciasPlantillas instanciasPlantillas)
        {
            if (id != instanciasPlantillas.IdInstanciaPlantilla)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(instanciasPlantillas);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InstanciasPlantillasExists(instanciasPlantillas.IdInstanciaPlantilla))
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
            ViewData["AspNetUser"] = new SelectList(_context.Users, "Id", "Id", instanciasPlantillas.AspNetUser);
            return View(instanciasPlantillas);
        }

        // GET: InstanciasPlantillas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var instanciasPlantillas = await _context.InstanciasPlantillas
                .Include(i => i.AspNetUserNavigation)
                .FirstOrDefaultAsync(m => m.IdInstanciaPlantilla == id);
            if (instanciasPlantillas == null)
            {
                return NotFound();
            }

            return View(instanciasPlantillas);
        }

        // POST: InstanciasPlantillas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var instanciasPlantillas = await _context.InstanciasPlantillas.FindAsync(id);
            _context.InstanciasPlantillas.Remove(instanciasPlantillas);
            await _context.SaveChangesAsync();
            TempData["Success"] = "Instancia eliminada.";
            return RedirectToAction(nameof(Index));
        }

        private bool InstanciasPlantillasExists(int id)
        {
            return _context.InstanciasPlantillas.Any(e => e.IdInstanciaPlantilla == id);
        }
    }
}
