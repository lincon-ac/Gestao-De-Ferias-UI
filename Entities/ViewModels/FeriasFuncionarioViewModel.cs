using Entities.Entidades;
using Entities.Enums;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Entities.ViewModels
{
    public class FeriasFuncionarioViewModel
    {
        [Display(Name = "Código")]
        [Key]
        public int Id { get; set; }
        public int Mes { get; set; }
        public int Ano { get; set; }

        public EnumTipoFerias TipoFerias { get; set; }

        public DateTime DataInicio { get; set; }
        public DateTime DataEncerramento { get; set; }

        public DateTime DataCadastro { get; set; }

        public DateTime DataAlteracao { get; set; }

        public DateTime DataPagamento { get; set; }

        public DateTime DataVencimento { get; set; }

        public bool Pago { get; set; }

        public bool FeriasAntrasada { get; set; }

        [ForeignKey("Funcionario")]
        public int FuncionarioId { get; set; }
    }
}
