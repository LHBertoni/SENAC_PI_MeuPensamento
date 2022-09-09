using MeuPensamento.DAO.Models;
using MeuPensamento.DAO.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeuPensamento.DAO.Infrastructure
{
    public static class Extensions
    {
        public static IServiceCollection AddDaoServices(this IServiceCollection service, IConfiguration configutarion)
        {
            service.AddDbContext<MeuPensamentoContext>(options => options.UseSqlServer(configutarion.GetConnectionString("MeuPensamentoDbContext")));
            service.AddScoped<UsuarioService>();
            service.AddScoped<PensamentoService>();
            service.AddScoped<CartaoEnfrentamentoService>();
            service.AddScoped<SintomaService>();

            return service;
        }
    }
}
