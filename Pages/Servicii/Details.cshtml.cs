using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Proiect_Clinica.Data;
using Proiect_Clinica.Models;

namespace Proiect_Clinica.Pages.Servicii
{
    public class DetailsModel : PageModel
    {
        private readonly Proiect_Clinica.Data.Proiect_ClinicaContext _context;

        public DetailsModel(Proiect_Clinica.Data.Proiect_ClinicaContext context)
        {
            _context = context;
        }

      public Serviciu Serviciu { get; set; } = default!;
        public Angajat Angajat { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Serviciu == null)
            {
                return NotFound();
            }

            Serviciu = await _context.Serviciu.FirstOrDefaultAsync(m => m.ID == id);

            if (Serviciu == null)
            {
                return NotFound();
            }

            Angajat = await _context.Angajat.FirstOrDefaultAsync(c => c.ID == Serviciu.AngajatID);

            if (Angajat == null)
            {
                return NotFound();
            }

            return Page();
        }

    }
}
