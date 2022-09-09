using MeuPensamento.DAO.Services;
using MeuPensamento.Pages.Base;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MeuPensamento.Pages.MeusPensamentos
{
    public class DetalhesPensamentoModel : BasePageModel
    {
        private readonly ILogger<DetalhesPensamentoModel> _logger;
        private readonly PensamentoService _pensamentoService;

        public DetalhesPensamentoModel(ILogger<DetalhesPensamentoModel> logger, 
            PensamentoService pensamentoService)
        {
            _logger = logger;
            _pensamentoService = pensamentoService;
        }

        public long Id { get; set; }
        public string Pensamento { get; set; } = string.Empty;
        public string Situacao { get; set; } = string.Empty;        
        public string Sentimento { get; set; } = string.Empty;
        public DateTime DataHora { get; set; } = DateTime.Now;

        public void OnGet(int id)                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                      
        {
            var pensamento = _pensamentoService.GetPensamento(User.IdUsuario(), id);

            Id = pensamento.Id;
            Pensamento = pensamento.MeuPensamento;
            Situacao = pensamento.Situacao;

            List<string> sentimentos = new List<string>();
            if (pensamento.Raiva > 0)
                sentimentos.Add("Raiva");
            if (pensamento.Angustia > 0)
                sentimentos.Add("Angustia");
            if (pensamento.Ansiedade > 0)
                sentimentos.Add("Ansiedade");
            if (pensamento.Tristeza > 0)
                sentimentos.Add("Tristeza");
            if(!string.IsNullOrWhiteSpace(pensamento.Sentimento))
                sentimentos.Add(pensamento.Sentimento);

            Sentimento = string.Join(";", sentimentos);

            DataHora = pensamento.Datahora;
        }

        public async Task<IActionResult> OnPostVoltar()
        {
            return this.RedirectToPage("/Index");
        }

        public async Task<IActionResult> OnPostArquivar(int id)
        {
            _pensamentoService.DeleteLogicalPensamento(User.IdUsuario(), id);

            return this.RedirectToPage("PensametoArquivado");
        }
    }
}
