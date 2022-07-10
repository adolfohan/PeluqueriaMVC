using MVCBasico.CustomValidation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static MVCBasico.CustomValidation.WeekdayAttribute;

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

        [Display(Name = "Fecha")]
        [Required(ErrorMessage = "Ingrese una fecha")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy HH:mm}", ApplyFormatInEditMode = false)]
        [LessDate]
        //[Weekday]
        public DateTime FechaInscripto { get; set; }
    }

}
