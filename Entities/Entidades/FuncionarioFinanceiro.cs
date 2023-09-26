using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Entidades
{

    [Table("FuncionarioFinanceiro")]
    public class FuncionarioFinanceiro : Base
    {
        public string Matricula { get; set; }
        public int Mes { get; set; }
        public int Ano { get; set; }
        public int DiaFechamento { get; set; }
        public bool GerarCopiaFerias { get; set; }
        public int MesCopia { get; set; }
        public int AnoCopia { get; set; }

        public bool ValidarPropriedadeString(string nome, string v)
        {
            throw new NotImplementedException();
        }
    }
}
