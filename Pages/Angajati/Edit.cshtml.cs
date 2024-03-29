﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Proiect_Clinica.Data;
using Proiect_Clinica.Models;

namespace Proiect_Clinica.Pages.Angajati
{
    public class EditModel : AngajatCalificarePageModel
    {
        private readonly Proiect_Clinica.Data.Proiect_ClinicaContext _context;
        public EditModel(Proiect_Clinica.Data.Proiect_ClinicaContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Angajat Angajat { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Angajat == null)
            {
                return NotFound();
            }

            Angajat = await _context.Angajat
                .Include(a => a.AngajatCalificari).ThenInclude(ac => ac.Calificare)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.ID == id);

            if (Angajat == null)
            {
                return NotFound();
            }

            PopulateAssignedCalificare(_context, Angajat);
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id, string[] selectedCalificari)
        {
            if (id == null)
            {
                return NotFound();
            }

            var angajatToUpdate = await _context.Angajat
                .Include(a => a.AngajatCalificari)
                .ThenInclude(ac => ac.Calificare)
                .FirstOrDefaultAsync(s => s.ID == id);

            if (angajatToUpdate == null)
            {
                return NotFound();
            }

            // Asigură-te că toate proprietățile necesare sunt actualizate
            if (await TryUpdateModelAsync<Angajat>(
                angajatToUpdate,
                "Angajat", // Prefixul pentru formular
                a => a.Nume, a => a.Prenume, a => a.DataAngajare, a => a.Adresa))
            {
                UpdateAngajatCalificare(_context, selectedCalificari, angajatToUpdate);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }

            // Dacă actualizarea a eșuat, repopulează lista de calificări atribuite
            PopulateAssignedCalificare(_context, angajatToUpdate);
            return Page();
        }
    }
}