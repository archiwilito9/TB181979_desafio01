using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TB181979_desafio01.Models
{
    public class Transacciones
    {
        [Key]
        public int id { get; set; }



        [RegularExpression("(^[0-9]+$)", ErrorMessage = "Solo se permiten números positivos")]
        [Range(1, float.MaxValue, ErrorMessage = "El monto debe ser mayor a 0")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Campo Monto requeridos")]
        public float Monto { get; set; }

        [StringLength(100)]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Campo estado requerido")]
        public String Estado { get; set; }


        [Display(Name = "Fecha de transacción")]
        [Required(ErrorMessage = "Campo fecha de transacción requerido")]
        [DataType(DataType.Date)]
        public DateTime FechaTransaccion { get; set; }


        [Display(Name = "Fecha de aplicación")]
        [Required(ErrorMessage = "Campo fecha de aplicación requerido")]
        [DataType(DataType.Date)]
        public DateTime FechaAplicación { get; set; }

        [Display(Name = "Cuenta bancaria")]
        public int? CuentaBancariaId { get; set; }
        public virtual CuentaBancaria CuentaBancarias { get; set; }

        [Display(Name = "Tipo de transacción")]
        public int? TipoTransaccionId { get; set; }
        public virtual TipoTransaccion TipoTransacciones { get; set; }
    }
}