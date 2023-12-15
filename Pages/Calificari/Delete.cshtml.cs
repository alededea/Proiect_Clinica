using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Proiect_Clinica.Data;
using Proiect_Clinica.Models;

namespace Proiect_Clinica.Pages.Calificari
{
    public class DeleteModel : PageModel
    {
        private readonly Proiect_Clinica.Data.Proiect_ClinicaContext _context;

        public DeleteModel(Proiect_Clinica.Data.Proiect_ClinicaContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Calificare Calificare { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Calificare == null)
            {
                return NotFound();
            }

            var calificare = await _context.Calificare.FirstOrDefaultAsync(m => m.ID == id);

            if (calificare == null)
            {
                return NotFound();
            }
            else 
            {
                Calificare = calificare;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Calificare == null)
            {
                return NotFound();
            }
            var calificare = await _context.Calificare.FindAsync(id);

            if (calificare != null)
            {
                Calificare = calificare;
                _context.Calificare.Remove(Calificare);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
