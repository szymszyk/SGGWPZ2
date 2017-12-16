using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SGGWPZ.Models
{
    [Table("Wydzialy")]
    public class Wydzialy
    {
        [Key]
        public int wydzialId { get; set; }
        public string nazwa { get; set; }
    }
}
