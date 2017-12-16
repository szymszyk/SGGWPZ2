using System;
using System.ComponentModel.DataAnnotations;

namespace SGGWPZ.Models
{
    public class Cyklicznosci
    {
        [Key]
        public int cyklId { get; set; }
        public bool stacjonarnosc { get; set; }
        public bool jednorazowosc { get; set; }
    }
}
    
