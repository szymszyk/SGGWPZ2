using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SGGWPZ.Models
{
    [Table("Typy_przedmiotu")]
    public partial class Typy_przedmiotu
    {
        [Key]
        public int typId { get; set; }
        public string nazwa { get; set; }

    }
}


    
