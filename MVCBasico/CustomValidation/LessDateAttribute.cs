using System;
using System.ComponentModel.DataAnnotations;

namespace MVCBasico.CustomValidation
{
    //[AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public class LessDateAttribute : ValidationAttribute
    {
        //public LessDateAttribute() : base("{0} La fecha no debe ser anterior a la fecha actual")
        //{

        //}

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            DateTime propValue = Convert.ToDateTime(value);
            if (propValue <= DateTime.Now)
                return new ValidationResult("La fecha no debe ser anterior a la fecha actual"); 
            else
                return ValidationResult.Success;

            
        }

    }
}
