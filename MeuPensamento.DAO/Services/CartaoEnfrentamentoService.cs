using MeuPensamento.DAO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeuPensamento.DAO.Services
{
    public class CartaoEnfrentamentoService
    {
        private readonly MeuPensamentoContext _dbContext;

        public CartaoEnfrentamentoService(Models.MeuPensamentoContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Models.Cartaoenfrentamento> GetCartoes(int idUsuario, int? qtdMax = null)
        {
            var cartoes = _dbContext.Cartaoenfrentamentos.Where(p => p.Idusuario == idUsuario);

            if (qtdMax.HasValue)
                cartoes = cartoes.Take(qtdMax.Value);

            return cartoes.ToList();
        }
    }
}
