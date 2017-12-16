using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace SGGWPZ.Models
{
    [Table("Rezerwacje")]
    public partial class Rezerwacje
    {
        [Key]
        public int rezerwacjaId { get; set; }
        public string data { get; set; }
        public int wykladowcaId { get; set; }
        public int grupaId { get; set; }
        public int salaId { get; set; }
        public int przedmiotId { get; set; }
        public int cyklId { get; set; }

    }
}

    
