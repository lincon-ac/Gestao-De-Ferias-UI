using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Entidades
{

    [Table("UsuarioFuncionarioFinanceiro")]
    public class UsuarioFuncionarioFinanceiro
    {
        public int Id { get; set; }
        public string EmailUsuario { get; set; }
        public bool Administrador { get; set; }
        public bool FuncionarioAtual { get; set; }


        [ForeignKey("FuncionarioFinanceiro")]
        [Column(Order = 1)]
        public int IdFuncionario { get; set; }
        public virtual FuncionarioFinanceiro FuncionarioFinanceiro { get; set; }
    }
}
