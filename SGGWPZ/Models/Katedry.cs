using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SGGWPZ.Models
{
    [Table("Katedry")]
    public partial class Katedry
    {
        [Key]
        public int katedraId { get; set; }
        public string nazwa { get; set; }
        public string wydzial { get; set; }

    }
}

    
