using System.ComponentModel.DataAnnotations;

namespace Proiect_Clinica.Models
{
    public class AssignedCalificare
    {
        public int CalificareID { get; set; }

        [Display(Name = "Tipul Calificarii")]
        public string Tip { get; set; }
        public bool Assigned { get; set; }
    }
}
