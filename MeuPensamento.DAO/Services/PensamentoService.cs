using MeuPensamento.DAO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeuPensamento.DAO.Services
{
    public class PensamentoService
    {
        private readonly MeuPensamentoContext _dbContext;

        public PensamentoService(Models.MeuPensamentoContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Models.Pensamento GetPensamento(int idUsuario, long idPensamento)
        {
            if (_dbContext.Pensamentos.Any(p => p.Idusuario == idUsuario && p.Id == idPensamento && p.Ativo))
                return _dbContext.Pensamentos.First(p => p.Id == idPensamento);

            return default;
        }

        public List<Models.Pensamento> GetPensamentos(int idUsuario, int? qtdMax = null)
        {
            var pensamentos = _dbContext.Pensamentos.Where(p => p.Idusuario == idUsuario && p.Ativo);

            if (qtdMax.HasValue)
                pensamentos = pensamentos.Take(qtdMax.Value);

            return pensamentos.ToList();
        }

        public void InsertPensamento(Models.Pensamento pensamento)
        {
            _dbContext.Pensamentos.Add(pensamento);

            _dbContext.SaveChanges();
        }

        public void DeleteLogicalPensamento(int idUsuario, long idPensamento)
        {
            if (_dbContext.Pensamentos.Any(p => p.Idusuario == idUsuario && p.Id == idPensamento && p.Ativo))
            {
                var pensamento = _dbContext.Pensamentos.First(p => p.Id == idPensamento);

                pensamento.Ativo = false;

                _dbContext.Update(pensamento);

                _dbContext.SaveChanges();
            }
        }
    }
}
