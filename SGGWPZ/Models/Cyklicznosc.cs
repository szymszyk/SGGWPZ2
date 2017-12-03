using System;
using System.ComponentModel.DataAnnotations;

public class Cyklicznosc {
    [Key]
    public int cyklId { get; set; }
	public bool stacjonarnosc { get; set; }
    public bool jednorazowosc { get; set; }

}
