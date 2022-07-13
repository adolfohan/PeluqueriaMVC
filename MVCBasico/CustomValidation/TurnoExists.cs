using MVCBasico.Context;
using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace MVCBasico.CustomValidation
{
    public class TurnoExists : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var context = new PeluqueriaDatabaseContext();

            DateTime Fecha = (DateTime)value;

            if (context.Turnos.Where(d=> d.FechaInscripto == Fecha).Count() > 0)
            {
                return new ValidationResult("El turno ya existe");
            }

            return ValidationResult.Success;
        }

    }
}
