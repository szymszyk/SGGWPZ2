using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace SGGWPZ.Models
{
    [Table("Przedmioty")]
    public partial class Przedmioty
    {
        [Key]
        public int przedmiotId { get; set; }
        public string skrot { get; set; }
        public string kierunek { get; set; }
        public string rodzaj_studiow { get; set; }
        public string stopien { get; set; }
        public int semestr { get; set; }
        public int rok { get; set; }
        public int typId { get; set; }
        public string nazwa { get; set; }

    }
}

    
