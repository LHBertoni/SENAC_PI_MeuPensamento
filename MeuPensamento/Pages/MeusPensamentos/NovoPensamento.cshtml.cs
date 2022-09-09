using MeuPensamento.Pages.Base;
using MeuPensamento.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace MeuPensamento.Pages.MeusPensamentos
{
    public class NovoPensamentoModel : BasePageModel
    {
        private readonly ILogger<NovoPensamentoModel> _logger;
        private readonly SessionService _sessionService;

        public NovoPensamentoModel(ILogger<NovoPensamentoModel> logger,
            SessionService sessionService)
        {
            _logger = logger;
            _sessionService = sessionService;
        }

        [Required]
        [BindProperty]
        public string NovoPensamento { get; set; } = string.Empty;

        public void OnGet()
        {
            NovoPensamento = _sessionService.GetSession<Models.MeusPensamentos.MeuPensamento>(Infrastructure.SessionConstants.NovoPensamento)?.Pensamento ?? String.Empty;
        }

        public async Task<IActionResult> OnPostAvancar()
        {
            if (ModelState.IsValid)
            {
                Models.MeusPensamentos.MeuPensamento pensamento = _sessionService.GetSession<Models.MeusPensamentos.MeuPensamento>(Infrastructure.SessionConstants.NovoPensamento)  ?? new Models.MeusPensamentos.MeuPensamento();

                pensamento.Pensamento = NovoPensamento;

                _sessionService.SetSession(Infrastructure.SessionConstants.NovoPensamento, pensamento);

                return RedirectToPage("NovoPensamentoSituacao");
            }
            else
            {
                AlertMsg = "Preencha o novo pensamento!";

                return Page();
            }
        }

        public async Task<IActionResult> OnPostVoltar()
        {
            _sessionService.RemoveSesion(Infrastructure.SessionConstants.NovoPensamento);

            return this.RedirectToPage("/Index");
        }
    }
}
