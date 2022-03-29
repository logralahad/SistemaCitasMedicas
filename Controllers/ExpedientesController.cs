#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SistemaCitasMedicas.Data;
using SistemaCitasMedicas.Models;

namespace SistemaCitasMedicas.Controllers
{
    public class ExpedientesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ExpedientesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Expedientes
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Expedientes.Include(e => e.Empleado).Include(e => e.Paciente);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Expedientes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var expediente = await _context.Expedientes
                .Include(e => e.Empleado)
                .Include(e => e.Paciente)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (expediente == null)
            {
                return NotFound();
            }

            return View(expediente);
        }

        // GET: Expedientes/Create
        public IActionResult Create()
        {
            ViewData["EmpleadoId"] = new SelectList(_context.Empleados, "Id", "Nombre");
            ViewData["PacienteId"] = new SelectList(_context.Pacientes, "Id", "Nombre");
            return View();
        }

        // POST: Expedientes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,PacienteId,EmpleadoId,Presion1,Presion2,Peso,Altura,CronicoDegenerativa,Operaciones,Alergias,Reflejos,Movimientos,Observaciones")] Expediente expediente)
        {
            if (expediente.EmpleadoId != 0 && expediente.PacienteId != 0)
            {
                _context.Add(expediente);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EmpleadoId"] = new SelectList(_context.Empleados, "Id", "Nombre", expediente.EmpleadoId);
            ViewData["PacienteId"] = new SelectList(_context.Pacientes, "Id", "Nombre", expediente.PacienteId);
            return View(expediente);
        }

        // GET: Expedientes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var expediente = await _context.Expedientes.FindAsync(id);
            if (expediente == null)
            {
                return NotFound();
            }
            ViewData["EmpleadoId"] = new SelectList(_context.Empleados, "Id", "Nombre", expediente.EmpleadoId);
            ViewData["PacienteId"] = new SelectList(_context.Pacientes, "Id", "Nombre", expediente.PacienteId);
            return View(expediente);
        }

        // POST: Expedientes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,PacienteId,EmpleadoId,Presion1,Presion2,Peso,Altura,CronicoDegenerativa,Operaciones,Alergias,Reflejos,Movimientos,Observaciones")] Expediente expediente)
        {
            if (id != expediente.Id)
            {
                return NotFound();
            }

            if (expediente.EmpleadoId != 0 && expediente.PacienteId != 0)
            {
                try
                {
                    _context.Update(expediente);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ExpedienteExists(expediente.Id))
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
            ViewData["EmpleadoId"] = new SelectList(_context.Empleados, "Id", "Nombre", expediente.EmpleadoId);
            ViewData["PacienteId"] = new SelectList(_context.Pacientes, "Id", "Nombre", expediente.PacienteId);
            return View(expediente);
        }

        // GET: Expedientes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var expediente = await _context.Expedientes
                .Include(e => e.Empleado)
                .Include(e => e.Paciente)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (expediente == null)
            {
                return NotFound();
            }

            return View(expediente);
        }

        // POST: Expedientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var expediente = await _context.Expedientes.FindAsync(id);
            _context.Expedientes.Remove(expediente);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ExpedienteExists(int id)
        {
            return _context.Expedientes.Any(e => e.Id == id);
        }
    }
}
