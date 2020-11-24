using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AspnCrudDapper.Entities
{
    public class Funcionario
    {
        [Key]
        [Display(Name = "Id")]
        public int FuncionarioId { get; set; }

        [Required]
        [Display(Name = "Nome do Funcionário")]
        public string Nome { get; set; }

        [Required]
        [Display(Name = "Nome da Cidade")]
        public string Cidade { get; set; }

        [Display(Name = "Nome do Departamento")]
        public string Departamento { get; set; }

        [Required]
        [Display(Name = "Sexo")]
        public string Sexo { get; set; }

        [Required]
        [Display(Name = "Salario")]
        public float Salario { get; set; }
    }
}
