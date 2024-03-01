using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC_Contravvenzioni.Models
{
    public class Persona
    {
        public int IDAnagrafica { get; set; }

        [Required(ErrorMessage = "Il Nome è un campo obbligatorio"), MaxLength(50)]
        [StringLength(50, ErrorMessage = "Il Nome non può avere più di 50 caratteri")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Il Cognome è un campo obbligatorio"), MaxLength(50)]
        [StringLength(50, ErrorMessage = "Il Cognome non può avere più di 50 caratteri")]
        public string Cognome { get; set; }

        [Required(ErrorMessage = "L' Indirizzo è un campo obbligatorio"), MaxLength(50)]
        [StringLength(50, ErrorMessage = "L' Indirizzo non può avere più di 50 caratteri")]
        public string Indirizzo { get; set; }

        [Required(ErrorMessage = "La Città è un campo obbligatorio"), MaxLength(50)]
        [StringLength(50, ErrorMessage = "La Città non può avere più di 50 caratteri")]
        [DisplayName("Città")]
        public string Citta { get; set; }

        [Required(ErrorMessage = "Il Cap è un campo obbligatorio"), MaxLength(5)]
        [StringLength(5, ErrorMessage = "Il Cap non può avere più di 5 caratteri")]
        public string Cap {  get; set; }

        [Required(ErrorMessage = "Il Codice Fiscale è un campo obbligatorio"), MaxLength(16)]
        [StringLength(16, ErrorMessage = "Il Codice Fiscale non può avere più di 16 caratteri")]
        [DisplayName("Codice Fiscale")]
        public string CodiceFiscale {  get; set; }

        [DisplayName("Totale delle Multe")]
        public int TotaleMulte { get; set; }

        [DisplayName("Somma Punti Decurtati")]
        public int SommaPuntiDecurtati { get; set; }

        [DisplayName("Punti Decurtati")]
        public int PuntiDecurtati { get; set; }

        [DisplayFormat(DataFormatString = "{0:n2}€")]
        public int Importo { get; set; }

        [DisplayFormat(DataFormatString = "{0:d}")]
        [DisplayName("Data della Violazione")]
        public DateTime DataViolazione { get; set; }

    }
}