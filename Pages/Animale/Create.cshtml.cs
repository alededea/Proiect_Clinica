using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Proiect_Clinica.Data;
using Proiect_Clinica.Models;

namespace Proiect_Clinica.Pages.Animale
{

    public class CreateModel : PageModel
    {
        private readonly Proiect_Clinica.Data.Proiect_ClinicaContext _context;

        public CreateModel(Proiect_Clinica.Data.Proiect_ClinicaContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["ClientID"] = new SelectList(_context.Client, "ID", "NumeComplet");
            return Page();
        }

        [BindProperty]
        public Animal Animal { get; set; } = default!;


        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid || _context.Animale == null || Animal == null)
            {
                return Page();
            }

            _context.Animale.Add(Animal);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }

    }
}
