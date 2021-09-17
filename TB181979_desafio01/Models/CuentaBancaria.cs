using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TB181979_desafio01.Models
{
    public class CuentaBancaria
    {
        [Key]
        public int id { get; set; }


        [Display(Name = "Cliente")]
        public int? ClienteId { get; set; }
        public virtual Cliente Clientes { get; set; }

        [StringLength(100)]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Campo moneda requerido")]
        public String Moneda { get; set; }



        [Display(Name = "Tipo de cuenta bancaria")]
        public int? TipoCuentaBancariaId { get; set; }
        public virtual TipoCuentaBancaria TipoCuentaBancarias { get; set; }
    }
}