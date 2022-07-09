using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVCBasico.Models
{
    public abstract class Persona
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Ingrese un nombre"), MaxLength(30), MinLength(1)]
        [RegularExpression("^[a-zA-Z]*$", ErrorMessage = " El nombre no es válido")]
        public string Nombre { get; set; }
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Ingrese un apellido"), MaxLength(30), MinLength(1)]
        [RegularExpression("^[a-zA-Z]*$", ErrorMessage = " El apellido no es válido")]
        public string Apellido { get; set; }
        [Required(ErrorMessage = "Ingrese un DNI")]
        [MinLength(7), MaxLength(8)]
        [RegularExpression("^[0-9]{1,3}.?[0-9]{3,3}.?[0-9]{3,3}$", ErrorMessage = " El número de DNI no es válido.")]
        public string Dni { get; set; }
        [Display(Name = "Teléfono")]
        [DataType(DataType.PhoneNumber)]
        [Required(ErrorMessage = "Ingrese un número de teléfono")]        
        [RegularExpression(@"^\(?([1-9]{2})\)?[-. ]?([0-9]{4})[-. ]?([0-9]{4})$",
                   ErrorMessage = "Ingrese un número de teléfono válido")]
        public string Telefono { get; set; }

        public string NombreCompleto()
        {
            return Nombre + " " + Apellido;
        }    
    }

}       
