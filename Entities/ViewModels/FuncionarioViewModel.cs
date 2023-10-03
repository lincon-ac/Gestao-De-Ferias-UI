using Entities.Entidades;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.ViewModels
{
    public class FuncionarioViewModel : Base
    {
        public string Matricula { get; set; }
        public int Mes { get; set; }
        public int Ano { get; set; }
        public int DiaFechamento { get; set; }
        public bool GerarCopiaFerias { get; set; }
        public int AnoCopia { get; set; }

        [ForeignKey("Departamento")]
        public int DepartamentoId { get; set; }
    }
}
