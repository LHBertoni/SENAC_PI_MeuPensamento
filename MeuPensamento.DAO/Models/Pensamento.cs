using System;
using System.Collections.Generic;

namespace MeuPensamento.DAO.Models
{
    public partial class Pensamento
    {
        public Pensamento()
        {
            Reacoes = new HashSet<Reacoes>();
        }

        public long Id { get; set; }
        public int Idusuario { get; set; }
        public string MeuPensamento { get; set; } = null!;
        public string Situacao { get; set; } = null!;
        public int Raiva { get; set; }
        public int Angustia { get; set; }
        public int Tristeza { get; set; }
        public int Ansiedade { get; set; }
        public string? Sentimento { get; set; }
        public DateTime Datahora { get; set; }
        public bool Ativo { get; set; } = true;

        public virtual Usuario IdusuarioNavigation { get; set; } = null!;
        public virtual ICollection<Reacoes> Reacoes { get; set; }
    }
}
