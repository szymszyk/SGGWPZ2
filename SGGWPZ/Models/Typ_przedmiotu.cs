using System;
using System.ComponentModel.DataAnnotations;

public class Typ_przedmiotu {
    [Key]
    public int typId { get; set; }
    public string nazwa { get; set; }

}
