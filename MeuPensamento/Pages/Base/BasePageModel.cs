using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MeuPensamento.Pages.Base
{
    [Authorize()]
    public class BasePageModel : PageModel
    {
        public string AlertMsg { get; set; } = string.Empty;

        public async Task<IActionResult> OnGetSingOut()
        {
            await HttpContext.SignOutAsync();

            return this.RedirectToPage("/Login");
        }
    }
}
