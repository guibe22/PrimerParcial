using System.ComponentModel.DataAnnotations;

public class Libros
{
     [Key]
    public int LibroId { get; set; }

    public String? Titulo { get; set; }

    public Double Precio { get; set; }
}
