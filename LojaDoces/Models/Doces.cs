using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace LojaDoces.Models
{
    public class Doces
    {
        [Display(Name = "Código do Produto")]
        [Required(ErrorMessage = "Este campo é obrigatório")]
        public int codDoce { get; set; }

        [Display(Name = "Tipo de doce")]
        [Required(ErrorMessage = "Este campo é obrigatório")]
        [StringLength(30, ErrorMessage = "Este campo deve conter no máximo 30 caracteres")]
        public string tipoDoce { get; set; }

        [Display(Name = "Fabricante do doce")]
        [Required(ErrorMessage = "Este campo é obrigatório")]
        [StringLength(50, ErrorMessage = "Este campo deve conter no máximo 50 caracteres")]
        public string fornecedorDoce { get; set; }

        [Display(Name = "Peso do doce (g)")]
        [Required(ErrorMessage = "Este campo é obrigatório")]
        public int pesoDoce { get; set; }

        [Display(Name = "Quantidade em estoque")]
        [Required(ErrorMessage = "Este campo é obrigatório")]
        public int estoqDoce { get; set; }
    }
}