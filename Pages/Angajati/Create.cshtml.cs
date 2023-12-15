using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Proiect_Clinica.Data;
using Proiect_Clinica.Models;

namespace Proiect_Clinica.Pages.Angajati
{
    [Authorize(Roles = "Admin")]
    public class CreateModel : AngajatCalificarePageModel
    {
        private readonly Proiect_ClinicaContext _context;

        public CreateModel(Proiect_ClinicaContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            // Inițializăm AssignedCalificareList pentru a afișa lista de calificări
            var angajat = new Angajat();
            PopulateAssignedCalificare(_context, angajat);
            return Page();
        }

        [BindProperty]
        public Angajat Angajat { get; set; }

        public async Task<IActionResult> OnPostAsync(string[] selectedCalificari)
        {
            if (string.IsNullOrEmpty(Angajat.Adresa))
            {
                // Setează adresa cu o valoare implicită sau arată o eroare
                Angajat.Adresa = "Adresa implicită"; // sau orice altă valoare adecvată
            }

            if (selectedCalificari != null)
            {
                Angajat.AngajatCalificari = new List<AngajatCalificare>();
                foreach (var cal in selectedCalificari)
                {
                    var calToAdd = new AngajatCalificare
                    {
                        CalificareID = int.Parse(cal)
                    };
                    Angajat.AngajatCalificari.Add(calToAdd);
                }
            }

            if (!ModelState.IsValid)
            {
                PopulateAssignedCalificare(_context, Angajat);
                return Page();
            }

            _context.Angajat.Add(Angajat);
            await _context.SaveChangesAsync();
            return RedirectToPage("./Index");
        }
    }
}