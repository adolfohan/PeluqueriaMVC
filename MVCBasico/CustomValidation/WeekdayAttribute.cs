using System;
using System.ComponentModel.DataAnnotations;


namespace MVCBasico.CustomValidation
{
    public class WeekdayAttribute : ValidationAttribute
    {

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            DayOfWeek today = DateTime.Today.DayOfWeek;

            if (today == DayOfWeek.Saturday || today == DayOfWeek.Sunday)
                return new ValidationResult("Debe elegir un día de semana");
            else
                return ValidationResult.Success;


        }


    }
}
