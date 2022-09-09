using MeuPensamento.DAO.Services;
using MeuPensamento.Tools.Util;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;

namespace MeuPensamento.Pages
{
    public class LoginModel : PageModel
    {
        private readonly ILogger<LoginModel> _logger;
        private readonly UsuarioService _usuarioService;
        private readonly CriptografiaProvider _criptografiaProvider;

        [Required]
        [BindProperty]
        public string Email { get; set; }

        [Required]
        [BindProperty]
        public string Password { get; set; }

        public string AlertMsg { get; set; }

        public LoginModel(ILogger<LoginModel> logger, UsuarioService usuarioService, Tools.Util.CriptografiaProvider criptografiaProvider)
        {
            _logger = logger;
            _usuarioService = usuarioService;
            _criptografiaProvider = criptografiaProvider;
        }

        public void OnGet()
        {
            _logger.LogInformation("acessando login");

            this.SignOut();
        }

        public async Task<IActionResult> OnPostLogin()
        {
            if (ModelState.IsValid)
            {
                _logger.LogInformation("validando login para email {0}", Email);

                var usuario = _usuarioService.GetUsuario(Email);

                if (usuario != null && (usuario?.Senha?.Equals(_criptografiaProvider.MD5Hash(Password)) ?? false))
                {
                    _logger.LogInformation("login válido, realizando authenticacao");

                    List<Claim> claims = new List<Claim>();

                    claims.Add(new Claim(ClaimTypes.Name, Email));
                    claims.Add(new Claim("IdUsuario", usuario.Id.ToString()));

                    ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme));

                    await HttpContext.SignInAsync(
                                CookieAuthenticationDefaults.AuthenticationScheme,
                                claimsPrincipal);

                    //this.SignIn(claimsPrincipal, CookieAuthenticationDefaults.AuthenticationScheme);

                    return RedirectToPage("Index");
                }
                else
                {
                    AlertMsg = "As informações para login incorretas";

                    _logger.LogInformation("email e senha informdos inválidos. email {0}", Email);
                }
            }
            else
            {
                AlertMsg = "As informações devem ser preenchidas";

                _logger.LogInformation("informações não preenchidas corretamente", Email);
            }

            return Page();
        }

        public async Task<IActionResult> OnPostCadastrar()
        {
            _logger.LogInformation("método cadastrar não implementado");

            return Page();
        }
    }
}
