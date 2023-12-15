﻿using System;
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
    public class IndexModel : PageModel
    {
        private readonly Proiect_Clinica.Data.Proiect_ClinicaContext _context;

        public IndexModel(Proiect_Clinica.Data.Proiect_ClinicaContext context)
        {
            _context = context;
        }

        public IList<Serviciu> Serviciu { get; set; } = default!;

        public string CurrentFilter { get; set; }

        public async Task OnGetAsync(string searchString)
        {
            CurrentFilter = searchString;

            IQueryable<Serviciu> serviciuIQ = _context.Serviciu.Include(b => b.Angajat);

            if (!String.IsNullOrEmpty(searchString))
            {
                serviciuIQ = serviciuIQ.Where(s => s.Nume.Contains(searchString));
            }

            Serviciu = await serviciuIQ.ToListAsync();
        }
    }
}
