using System;
using System.Collections.Generic;

namespace MeuPensamento.DAO.Models
{
    public partial class Cartaoenfrentamento
    {
        public long Id { get; set; }
        public int Idusuario { get; set; }
        public string Mensagem { get; set; } = null!;

        public virtual Usuario IdusuarioNavigation { get; set; } = null!;
    }
}
