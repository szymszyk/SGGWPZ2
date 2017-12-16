using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace SGGWPZ.Models
{
    [Table("Sale")]
    public partial class Sale
    {
        [Key]
        public int salaId { get; set; }
        public string nr_sali { get; set; }
        public int budynek { get; set; }

    }
}

    
