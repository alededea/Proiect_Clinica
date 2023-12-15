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
    public class DetailsModel : PageModel
    {
        private readonly Proiect_Clinica.Data.Proiect_ClinicaContext _context;

        public DetailsModel(Proiect_Clinica.Data.Proiect_ClinicaContext context)
        {
            _context = context;
        }

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
    }
}
