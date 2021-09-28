using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace LojaDoces.Models
{
    public class Fornecedor
    {
        
        [Display(Name = "Código do Fornecedor")]
        [Required(ErrorMessage = "Este campo é obrigatório")]
        public int codForn { get; set; }

        [Display(Name = "Nome do Fornecedor")]
        [Required(ErrorMessage = "Este campo é obrigatório")]
        [StringLength(50, ErrorMessage = "Este campo deve conter no máximo 50 caracteres")]
        public string nomeForn { get; set; }

        [Display(Name = "Endereço do Fornecedor")]
        [Required(ErrorMessage = "Este campo é obrigatório")]
        [StringLength(50, ErrorMessage = "Este campo deve conter no máximo 50 caracteres")]
        public string enderecoForn { get; set; }

        [Display(Name = "Telefone do Fornecedor")]
        [Required(ErrorMessage = "Este campo é obrigatório")]
        [StringLength(11, ErrorMessage = "Este campo deve conter no máximo 11 caracteres")]
        [RegularExpression(@"^\d{2}\ \d{5}\-\d{4}$", ErrorMessage = "Digite um telefone válido!")]
        public string telefoneForn { get; set; }

        [Display(Name = "Email do Fornecedor")]
        [Required(ErrorMessage = "Este campo é obrigatório")]
        [StringLength(50, ErrorMessage = "Este campo deve conter no máximo 60 caracteres")]
        public string emailForn { get; set; }

    }
}