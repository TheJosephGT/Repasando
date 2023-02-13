using System.ComponentModel.DataAnnotations;

public class Libros{
    [Key]

    public int LibroId {get;set;}
    [Required(ErrorMessage = "Este dato es obligatorio")]

    public string? Autor {get;set;}

    public string? Fecha {get; set;}

    public double Costo {get; set;}

}