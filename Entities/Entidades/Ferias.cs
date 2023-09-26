using Entities.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Entidades
{

    [Table("Ferias")]
    public  class Ferias : Base
    {

        public decimal Valor { get; set; }
        public int Mes { get; set; }
        public int Ano { get; set; }

        public EnumTipoFerias TipoFerias { get; set; }

        public DateTime DataCadastro { get; set; }

        public DateTime DataAlteracao { get; set; }

        public DateTime DataPagamento { get; set; }

        public DateTime DataVencimento { get; set; }

        public bool Pago { get; set; }

        public bool FeriasAntrasada { get; set; }

        [ForeignKey("Departamento")]
        [Column(Order = 1)]
        public int IdDepartamento { get; set; }

        public bool ValidarPropriedadeString(string nome, string v)
        {
            throw new NotImplementedException();
        }
        //public virtual Departamento Departamento { get; set; }
    }
}
