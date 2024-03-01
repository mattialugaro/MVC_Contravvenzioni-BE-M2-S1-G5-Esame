using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC_Contravvenzioni.Models
{
    public class TipoViolazione
    {
        public int IDViolazione { get; set; }

        [Required(ErrorMessage = "La Descrizione è un campo obbligatorio"), MaxLength(50)]
        [StringLength(50, ErrorMessage = "La Descrizione non può avere più di 500 caratteri")]
        [DisplayName("Tipologia di Trasgressione")]
        public string Descrizione { get; set; }

        [Required(ErrorMessage = "L' IDAnagrafica è un campo obbligatorio")]
        public int IDAnagrafica { get; set; }

        [Required(ErrorMessage = "La Trasgressione è contestabile è un campo obbligatorio")]
        [DisplayName("La Trasgressione è contestabile")]
        public bool Contestabile {  get; set; }

    }
}