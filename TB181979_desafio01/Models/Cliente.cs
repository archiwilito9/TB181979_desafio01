using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TB181979_desafio01.Models
{
    public class Cliente
    {
        [Key]
        public int id { get; set; }


        [StringLength(100)]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Campo nombres requerido")]
        public String nombres { get; set; }

        [Display(Name = "Primer apellido")]
        [StringLength(100)]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Campo primer apellido requerido")]
        public String primerApellido { get; set; }

        [Display(Name = "Segundo apellido")]
        [StringLength(100)]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Campo segundo apellido requerido")]
        public String segundoApellido { get; set; }

        [RegularExpression("(^[0-9]+$)", ErrorMessage = "Ingrese un número de teléfono válido")]
        [MinLength(length: 8)]
        [MaxLength(length: 8)]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Campo teléfono requerido")]
        public string Telefono { get; set; }


        [Display(Name = "Correo")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Campo correo requerido")]
        [StringLength(100)]
        [EmailAddress(ErrorMessage = "El correo no cumple con el formato correcto")]
        public string email { get; set; }
    }
}