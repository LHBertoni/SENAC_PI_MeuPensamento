using MeuPensamento.DAO.Services;
using MeuPensamento.Models.MeusPensamentos;
using MeuPensamento.Pages.Base;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Linq;

namespace MeuPensamento.Pages.MeusPensamentos
{
    public class MeusPensamentosModel : BasePageModel
    {
        private readonly ILogger<MeusPensamentosModel> _logger;
        private readonly PensamentoService _pensamentoService;

        [BindProperty]
        public List<MeuPensamentoDataSimples> DataPensamentos { get; set; } = new List<MeuPensamentoDataSimples>();

        public MeusPensamentosModel(ILogger<MeusPensamentosModel> logger, PensamentoService pensamentoService)
        {
            _logger = logger;
            _pensamentoService = pensamentoService;
        }

        public void OnGet()
        {
            var pensamentos = _pensamentoService.GetPensamentos(User.IdUsuario()).OrderByDescending(i => i.Datahora);

            foreach (var pensamentoData in pensamentos.GroupBy(i => i.Datahora.Date))
                DataPensamentos.Add(new MeuPensamentoDataSimples()
                {
                    Data = pensamentoData.Key,
                    Pensamentos = pensamentoData
                    .Select(p => new MeuPensamentoSimples()
                    {
                        DataHora = p.Datahora,
                        Id = p.Id,
                        Pensamento = p.MeuPensamento
                    })
                    .ToList()
                });
        }
    }
}
