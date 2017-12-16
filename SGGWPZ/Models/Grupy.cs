using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SGGWPZ.Models
{
    [Table("Grupy")]
    public partial class Grupy
    {
        [Key]
        public int grupaId { get; set; }
        public int rok { get; set; }
        public string kierunek { get; set; }
        public string tryb_studiow { get; set; }

    }
}

