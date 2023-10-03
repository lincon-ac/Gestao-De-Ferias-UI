using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Entidades
{

    [Table("Funcionario")]
    public class Funcionario : Base
    {
        public string Matricula { get; set; }
        public int Mes { get; set; }
        public int Ano { get; set; }
        public int DiaFechamento { get; set; }
        public bool GerarCopiaFerias { get; set; }

        [ForeignKey("Departamento")]
        public int DepartamentoId { get; set; }
        public virtual Departamento Departamento { get; set; }

        public bool ValidarPropriedadeString(string nome)
        {
            return nome.Length > 1;
        }
    }
}
