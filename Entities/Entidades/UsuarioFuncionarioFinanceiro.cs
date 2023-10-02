using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Entidades
{

    [Table("UsuarioFuncionarioFinanceiro")]
    public class UsuarioFuncionarioFinanceiro
    {
        public int Id { get; set; }
        public string EmailUsuario { get; set; }
        public bool Administrador { get; set; }
        public bool FuncionarioAtual { get; set; }


        [ForeignKey("Funcionario")]
        [Column(Order = 1)]
        public int IdFuncionario { get; set; }
        public virtual Funcionario Funcionario { get; set; }
    }
}
