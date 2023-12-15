using Proiect_Clinica.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace Proiect_Clinica.Models
{
    public class Animal
    {
        public int ID { get; set; }

        public string Nume { get; set; }

        public string Rasa { get; set; }

        [DataType(DataType.Date)]

        [Display(Name = "Data Nasterii")]
        public DateTime DataNastere { get; set; }

        public string Sex { get; set; }

        //[Range(0, double.MaxValue, ErrorMessage = "Greutatea trebuie să fie un număr pozitiv")]
        public double Greutate { get; set; }

        // Cheia străină pentru Client
        public int ClientID { get; set; }

        // Proprietatea de navigare pentru Client
        public Client Client { get; set; }
    }
}