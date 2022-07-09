using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVCBasico.Models
{
    public class Turno
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Display(Name = "Cliente")]
        public Cliente Cliente { get; set; }

        [Required(ErrorMessage = "Ingrese un cliente")]
        [Display(Name = "Cliente")]
        public int ClienteId { get; set; }

        [Display(Name = "Peluquero/a")]
        public Peluquero Peluquero { get; set; }

        [Required(ErrorMessage = "Ingrese un/a peluquero/a")]
        [Display(Name = "Peluquero/a")]
        public int PeluqueroId { get; set; }

        [Required(ErrorMessage = "Seleccione un servicio")]
        [Display(Name = "Servicio")]
        public Servicio Servicio { get; set; }

        [Required(ErrorMessage = "Ingrese una fecha válida")]
        //[RegularExpression("^([0-9][0-9][0-9][0-9])[-/.](0[1-9]|1[012])[-/.](0[1-9]|[12][0-9]|3[01])T(1[0-9]):(00)$", ErrorMessage = "Los turnos se toman de 10:00 a 19:00" +
        //    " [La hora debe ser en punto]")]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Fecha")]
        public DateTime FechaInscripto { get; set; }
    }

}
