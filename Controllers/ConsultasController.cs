﻿#nullable disable
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
    public class ConsultasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ConsultasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Consultas
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Consultas.Include(c => c.Paciente);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Consultas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var consulta = await _context.Consultas
                .Include(c => c.Paciente)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (consulta == null)
            {
                return NotFound();
            }

            return View(consulta);
        }

        // GET: Consultas/Create
        public IActionResult Create()
        {
            ViewData["PacienteId"] = new SelectList(_context.Pacientes, "Id", "Nombre");
            return View();
        }

        // POST: Consultas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Fecha,Presion1,Presion2,Peso,Altura,PacienteId,Sintomas,Diagnostico,Medicamentos")] Consulta consulta)
        {
            if (consulta.PacienteId != 0)
            {
                _context.Add(consulta);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PacienteId"] = new SelectList(_context.Pacientes, "Id", "Nombre", consulta.PacienteId);
            return View(consulta);
        }

        // GET: Consultas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var consulta = await _context.Consultas.FindAsync(id);
            if (consulta == null)
            {
                return NotFound();
            }
            ViewData["PacienteId"] = new SelectList(_context.Pacientes, "Id", "Nombre", consulta.PacienteId);
            return View(consulta);
        }

        // POST: Consultas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Fecha,Presion1,Presion2,Peso,Altura,PacienteId,Sintomas,Diagnostico,Medicamentos")] Consulta consulta)
        {
            if (id != consulta.Id)
            {
                return NotFound();
            }

            if (consulta.PacienteId != 0)
            {
                try
                {
                    _context.Update(consulta);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ConsultaExists(consulta.Id))
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
            ViewData["PacienteId"] = new SelectList(_context.Pacientes, "Id", "Nombre", consulta.PacienteId);
            return View(consulta);
        }

        // GET: Consultas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var consulta = await _context.Consultas
                .Include(c => c.Paciente)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (consulta == null)
            {
                return NotFound();
            }

            return View(consulta);
        }

        // POST: Consultas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var consulta = await _context.Consultas.FindAsync(id);
            _context.Consultas.Remove(consulta);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ConsultaExists(int id)
        {
            return _context.Consultas.Any(e => e.Id == id);
        }
    }
}
