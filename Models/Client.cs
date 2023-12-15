using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Policy;

namespace Proiect_Clinica.Models
{
    public class Client
    {
        public int ID { get; set; }
        public string? Nume { get; set; }
        public string? Prenume { get; set; }
        public string Email { get; set; }
        public string? Telefon { get; set; }

        [Display(Name = "Nume Complet")]
        public string? NumeComplet
        {
            get
            {
                return Nume + " " + Prenume;
            }
        }

        // O colecție de Programari asociate cu clientul
        public ICollection<Programare>? Programari { get; set; }
    }
}
