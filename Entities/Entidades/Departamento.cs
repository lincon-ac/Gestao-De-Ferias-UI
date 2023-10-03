using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Entidades
{
    [Table("Departamento")]
    public class Departamento : Base
    {
        public bool ValidarPropriedadeString(string nome)
        {
            return nome.Length >= 1;
        }
    }
}
