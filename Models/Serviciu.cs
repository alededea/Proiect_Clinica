﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Policy;

namespace Proiect_Clinica.Models
{
    public class Serviciu
    {
        public int ID { get; set; }

        [Display(Name = "Numele Serviciului")]
        public string Nume { get; set; }

        
        [Display(Name = "Durata sedinta(minute)")]
        public int Durata { get; set; }

        [Column(TypeName = "decimal(6, 2)")]
        [Display(Name = "Pret(lei)")]
        public decimal Pret { get; set; }
        public int? AngajatID { get; set; }
        public Angajat? Angajat { get; set; } //navigation property

    }
}
