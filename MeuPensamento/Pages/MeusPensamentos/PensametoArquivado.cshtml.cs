using MeuPensamento.Pages.Base;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MeuPensamento.Pages.MeusPensamentos
{
    public class PensametoArquivadoModel : BasePageModel
    {
        private readonly ILogger<PensametoArquivadoModel> _logger;

        public PensametoArquivadoModel(ILogger<PensametoArquivadoModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostOk()
        {
            return RedirectToPage("MeusPensamentos");
        }

    }
}
