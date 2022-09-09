using MeuPensamento.Pages.Base;
using MeuPensamento.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace MeuPensamento.Pages.MeusPensamentos
{
    public class NovoPensamentoSentimentosModel : BasePageModel
    {
        private readonly ILogger<NovoPensamentoSentimentosModel> _logger;
        private readonly SessionService _sessionService;

        public NovoPensamentoSentimentosModel(ILogger<NovoPensamentoSentimentosModel> logger,
            SessionService sessionService)
        {
            _logger = logger;
            _sessionService = sessionService;
        }
    

        [Required]
        [BindProperty]
        public int Raiva { get; set; }

        [Required]
        [BindProperty]
        public int Angustia { get; set; }

        [Required]
        [BindProperty]
        public int Tristeza { get; set; }

        [Required]
        [BindProperty]
        public int Ansiedade { get; set; }

        [BindProperty]
        [Required(AllowEmptyStrings = true)]
        public string SentimentoAdicional { get; set; } = string.Empty;

        public async Task<IActionResult> OnGet()
        {
            var  pensamento = _sessionService.GetSession<Models.MeusPensamentos.MeuPensamento>(Infrastructure.SessionConstants.NovoPensamento);

            if(pensamento != null)
            {
                Raiva = pensamento.Raiva;
                Angustia = pensamento.Angustia;
                Tristeza = pensamento.Tristeza;
                Ansiedade = pensamento.Ansiedade;
                SentimentoAdicional = pensamento.SentimentoAdicional;

                return Page();
            }

            return this.RedirectToPage("/Index");
        }

        public async Task<IActionResult> OnPostAvancar()
        {
            if (ModelState.IsValid)
            {
                var pensamento = _sessionService.GetSession<Models.MeusPensamentos.MeuPensamento>(Infrastructure.SessionConstants.NovoPensamento);

                pensamento.Raiva = Raiva;
                pensamento.Angustia = Angustia;
                pensamento.Tristeza = Tristeza;
                pensamento.Ansiedade = Ansiedade;
                pensamento.SentimentoAdicional = SentimentoAdicional;

                _sessionService.SetSession(Infrastructure.SessionConstants.NovoPensamento, pensamento);

                return RedirectToPage("NovoPensamentoReacoes");
            }
            else
            {
                AlertMsg = "Preencha os campos!";

                return Page();
            }
        }

        public async Task<IActionResult> OnPostVoltar()
        {
            return this.RedirectToPage("NovoPensamentoSituacao");
        }
    }
}
