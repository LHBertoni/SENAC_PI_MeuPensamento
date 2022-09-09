using MeuPensamento.DAO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeuPensamento.DAO.Services
{
    public class SintomaService
    {
        private readonly MeuPensamentoContext _dbContext;

        public SintomaService(Models.MeuPensamentoContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Models.Sintoma> GetSintomas()
        {
            return _dbContext.Sintomas.ToList();
        }
    }
}
