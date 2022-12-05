using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WebElReyCan.Models
{
    public class Turno
    {
        public int TurnoId { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime Fecha { get; set; }
        [Required]
        public string  Nombre { get; set; }
        public string Raza { get; set; }
        public int Edad { get; set; }
        [Required]
        [DisplayName("Nombre del dueño")]
        public string NombreDuenio { get; set; }
        [Required]
        public string Telefono { get; set; }
    }
}

