using MeuPensamento.DAO.Services;
using MeuPensamento.Pages.Base;
using MeuPensamento.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace MeuPensamento.Pages.MeusPensamentos
{
    public class NovoPensamentoReacoesModel : BasePageModel
    {
        private readonly ILogger<NovoPensamentoReacoesModel> _logger;
        private readonly SessionService _sessionService;
        private readonly PensamentoService _pensamentoService;

        public NovoPensamentoReacoesModel(ILogger<NovoPensamentoReacoesModel> logger,
            SessionService sessionService,
            PensamentoService pensamentoService)
        {
            _logger = logger;
            _sessionService = sessionService;
            _pensamentoService = pensamentoService;
        }

        [BindProperty]
        [Required(AllowEmptyStrings = true)]
        public string Reacoes { get; set; } = string.Empty;

        public List<string> ReacoesSelecionadas { get; set; } = new List<string>();

        public async Task<IActionResult> OnGet()
        {
            var pensamento = _sessionService.GetSession<Models.MeusPensamentos.MeuPensamento>(Infrastructure.SessionConstants.NovoPensamento);

            if (pensamento != null)
            {
                Reacoes = String.Join(";", pensamento.Reacoes);

                ReacoesSelecionadas = pensamento.Reacoes;

                return Page();
            }

            return RedirectToPage("Index");
        }

        public async Task<IActionResult> OnPostAvancar()
        {
            if (ModelState.IsValid)
            {
                var pensamento = _sessionService.GetSession<Models.MeusPensamentos.MeuPensamento>(Infrastructure.SessionConstants.NovoPensamento);

                pensamento.Reacoes = Reacoes.Split(";", StringSplitOptions.RemoveEmptyEntries).ToList();

                _sessionService.RemoveSesion(Infrastructure.SessionConstants.NovoPensamento);

                _pensamentoService.InsertPensamento(new DAO.Models.Pensamento()
                {
                    MeuPensamento = pensamento.Pensamento,
                    Sentimento = pensamento.SentimentoAdicional,
                    Situacao = pensamento.Situacao,
                    Idusuario = User.IdUsuario(),
                    Angustia = pensamento.Angustia,
                    Ansiedade = pensamento.Ansiedade,
                    Raiva = pensamento.Raiva,
                    Tristeza = pensamento.Tristeza,
                    Datahora = pensamento.DataHora,
                    Reacoes = pensamento.Reacoes.Select(p => new DAO.Models.Reacoes() { Reacao = p }).ToList()
                });

                return RedirectToPage("NovoPensamentoInserido");
            }
            else
            {
                AlertMsg = "Preencha os campos!";

                return Page();
            }
        }

        public async Task<IActionResult> OnPostVoltar()
        {
            return this.RedirectToPage("NovoPensamentoSentimentos");
        }
    }
}
