using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Personas
    {
        [Key]
        public int PersonaId { get; set; }

        [Required(ErrorMessage ="El nombre es requerido")]
        public string? NombreCompleto { get; set; }

        [Required(ErrorMessage ="El Telefono es requerido")]
        public int Telefono { get; set; }

        [Required(ErrorMessage ="El Celular es requerido")]
        public int Celular { get; set; }

        [Required(ErrorMessage ="El Email es requerido")]
        public string? Email { get; set; }

        [Required(ErrorMessage ="La Direccion es requerido")]
        public string? Direccion { get; set; }

        [Required(ErrorMessage ="La Fecha es requerido")]
        public DateTimeOffset FechaNacimiento { get; set; }

        [ForeignKey("OcupacionId")]
        public int OcupacionId { get; set; }
}