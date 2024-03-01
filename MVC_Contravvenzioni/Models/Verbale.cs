using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC_Contravvenzioni.Models
{
    public class Verbale
    {
        [Required(ErrorMessage = "L' IDVerbale è un campo obbligatorio")]
        public int IDVerbale { get; set; }

        [DisplayFormat(DataFormatString = "{0:d}")]
        [DisplayName("Data della Violazione (AAAA-MM-GG)")]
        [Required(ErrorMessage = "La Data della Violazione è un campo obbligatorio")]
        public DateTime DataViolazione { get; set; }

        [DisplayName("Indirizzo della Violazione")]
        [Required(ErrorMessage = "L' Indirizzo della Violazione è un campo obbligatorio"), MaxLength(50)]
        [StringLength(50, ErrorMessage = "L' Indirizzo della Violazione non può avere più di 50 caratteri")]
        public string IndirizzoViolazione { get; set; }

        [DisplayName("Nome e Cognome Agente")]
        [Required(ErrorMessage = "Il Nome e Cognome Agente è un campo obbligatorio"), MaxLength(50)]
        [StringLength(50, ErrorMessage = "Il Nome e Cognome Agente non può avere più di 50 caratteri")]
        public string NominativoAgente { get; set; }

        [DisplayFormat(DataFormatString = "{0:d}")]
        [DisplayName("Data della Trascrizione del Verbale (AAAA-MM-GG)")]
        [Required(ErrorMessage = "La Data della Trascrizione del Verbale è un campo obbligatorio")]
        public DateTime DataTrascrizioneVerbale { get; set; }

        [DisplayFormat(DataFormatString = "{0:n2}€")]
        [Required(ErrorMessage = "L' Importo è un campo obbligatorio")]
        public Int32 Importo {  get; set; }

        [DisplayName("Numero Punti Decurtati")]
        [Required(ErrorMessage = "Il Numero Punti Decurtati è un campo obbligatorio")]
        public int DecurtamentoPunti { get; set; }

        [Required(ErrorMessage = "L' IDAnagrafica è un campo obbligatorio")]
        public int IDAnagrafica { get; set; }
        public int IDViolazione { get; set; }
    }
}