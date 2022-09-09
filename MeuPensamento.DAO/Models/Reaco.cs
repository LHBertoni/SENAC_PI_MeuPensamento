using System;
using System.Collections.Generic;

namespace MeuPensamento.DAO.Models
{
    public partial class Reacoes
    {
        public long Id { get; set; }
        public long Idpensamento { get; set; }
        public string Reacao { get; set; } = null!;

        public virtual Pensamento IdpensamentoNavigation { get; set; } = null!;
    }
}
