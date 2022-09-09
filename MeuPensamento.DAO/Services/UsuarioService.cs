using MeuPensamento.DAO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeuPensamento.DAO.Services
{
    public class UsuarioService
    {
        private readonly MeuPensamentoContext _dbContext;

        public UsuarioService(Models.MeuPensamentoContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Models.Usuario GetUsuario(string email)
        {
            if (_dbContext.Usuarios.Any(u => u.Email == email))
                return _dbContext.Usuarios.First(u => u.Email == email);

            return default;
        }
    }
}
