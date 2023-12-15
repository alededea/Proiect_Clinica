using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Policy;

namespace Proiect_Clinica.Models
{
    public class Angajat
    {
        public int ID { get; set; }
        public string Nume { get; set; }
        public string Prenume { get; set; }

        [Display(Name = "Data Angajarii")]

        [DataType(DataType.Date)]
        public DateTime DataAngajare { get; set; }
        public string? Adresa { get; set; }
        public ICollection<Serviciu>? Servicii { get; set; } //navigation property
        public ICollection<AngajatCalificare>? AngajatCalificari { get; set; }
    }
}
