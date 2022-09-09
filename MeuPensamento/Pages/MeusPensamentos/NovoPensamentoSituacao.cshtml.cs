using MeuPensamento.Pages.Base;
using MeuPensamento.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace MeuPensamento.Pages.MeusPensamentos
{
    public class NovoPensamentoSituacaoModel : BasePageModel
    {
        private readonly ILogger<NovoPensamentoSituacaoModel> _logger;
        private readonly SessionService _sessionService;

        public NovoPensamentoSituacaoModel(ILogger<NovoPensamentoSituacaoModel> logger,
            SessionService sessionService)
        {
            _logger = logger;
            _sessionService = sessionService;
        }

        [Required]
        [BindProperty]
        public string Situacao { get; set; } = string.Empty;
    
        public async Task<IActionResult> OnGet()
        {
            var pensamento = _sessionService.GetSession<Models.MeusPensamentos.MeuPensamento>(Infrastructure.SessionConstants.NovoPensamento);

            if(pensamento != null)
            {
                Situacao = pensamento.Situacao;

                return Page();
            }

            return RedirectToPage("/Index");
        }

        public async Task<IActionResult> OnPostAvancar()
        {
            if (ModelState.IsValid)
            {
                var pensamento = _sessionService.GetSession<Models.MeusPensamentos.MeuPensamento>(Infrastructure.SessionConstants.NovoPensamento);

                pensamento.Situacao = Situacao;

                _sessionService.SetSession(Infrastructure.SessionConstants.NovoPensamento, pensamento);

                return RedirectToPage("NovoPensamentoSentimentos");
            }
            else
            {
                AlertMsg = "Preencha a situação que o pensamento ocorreu!";

                return Page();
            }
        }

        public async Task<IActionResult> OnPostVoltar()
        {
            return this.RedirectToPage("NovoPensamento");
        }
    }
}
