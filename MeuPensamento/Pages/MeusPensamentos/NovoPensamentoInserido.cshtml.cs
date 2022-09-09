using MeuPensamento.Pages.Base;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MeuPensamento.Pages.MeusPensamentos
{
    public class NovoPensamentoInseridoModel : BasePageModel
    {
        private readonly ILogger<NovoPensamentoInseridoModel> _logger;

        public NovoPensamentoInseridoModel(ILogger<NovoPensamentoInseridoModel> logger)
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
