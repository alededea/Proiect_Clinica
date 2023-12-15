using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Proiect_Clinica.Data;
using Proiect_Clinica.Models;

namespace Proiect_Clinica.Pages.Angajati
{
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
            var newAngajat = new Angajat();

            if (selectedCalificari != null)
            {
                newAngajat.AngajatCalificari = new List<AngajatCalificare>();
                foreach (var cal in selectedCalificari)
                {
                    var calToAdd = new AngajatCalificare
                    {
                        CalificareID = int.Parse(cal)
                    };
                    newAngajat.AngajatCalificari.Add(calToAdd);
                }
            }

            if (!ModelState.IsValid)
            {
                PopulateAssignedCalificare(_context, newAngajat);
                return Page();
            }

            _context.Angajat.Add(newAngajat);
            await _context.SaveChangesAsync();
            return RedirectToPage("./Index");
        }
    }
}