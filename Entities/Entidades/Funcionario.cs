using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Entidades
{

    [Table("Funcionario")]
    public class Funcionario: Base
    {
        public string Matricula { get; set; }
        public string Departamento { get; set; }
        public int Mes { get; set; }
        public int Ano { get; set; }
        public int DiaFechamento { get; set; }
        public bool GerarCopiaFerias { get; set; }
        public int MesCopia { get; set; }
        public int AnoCopia { get; set; }

        public bool ValidarPropriedadeString(string nome)
        {
            return nome.Length > 1;
        }
    }
}
