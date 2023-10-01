﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Entidades
{

    [Table("Departamento")]
    public class Departamento : Base
    {
        [ForeignKey("FuncionarioFinanceiro")]
        [Column(Order = 1)]
        public int IdFuncionario { get; set; }

        public bool ValidarPropriedadeString(string nome)
        {
            return nome.Length > 1;
        }
        // public virtual FuncionarioFinanceiro FuncionarioFinanceiro { get; set; }
    }
}
