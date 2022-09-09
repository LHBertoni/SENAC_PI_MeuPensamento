using System;
using System.Collections.Generic;

namespace MeuPensamento.DAO.Models
{
    public partial class Usuario
    {
        public Usuario()
        {
            Cartaoenfrentamentos = new HashSet<Cartaoenfrentamento>();
            Pensamentos = new HashSet<Pensamento>();
        }

        public int Id { get; set; }
        public string Email { get; set; } = null!;
        public string? Senha { get; set; }

        public virtual ICollection<Cartaoenfrentamento> Cartaoenfrentamentos { get; set; }
        public virtual ICollection<Pensamento> Pensamentos { get; set; }
    }
}
