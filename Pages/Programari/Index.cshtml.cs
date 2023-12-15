using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Proiect_Clinica.Data;
using Proiect_Clinica.Models;

namespace Proiect_Clinica.Pages.Programari
{
    public class IndexModel : PageModel
    {
        private readonly Proiect_Clinica.Data.Proiect_ClinicaContext _context;

        public IndexModel(Proiect_Clinica.Data.Proiect_ClinicaContext context)
        {
            _context = context;
        }

        public IList<Programare> Programare { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Programare != null)
            {
                Programare = await _context.Programare
                    .Include(p => p.Client)
                    .Include(p => p.Serviciu)
                    .ToListAsync();
            }    
        }
    }
}
