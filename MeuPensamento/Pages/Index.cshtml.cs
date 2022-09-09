using MeuPensamento.DAO.Services;
using MeuPensamento.Models.CartoesEnfrentamentos;
using MeuPensamento.Pages.Base;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MeuPensamento.Pages
{
    public class IndexModel : BasePageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly CartaoEnfrentamentoService _cartaoEnfrentamentoService;


        public List<CartaoEnfrentamento> CartoesEnfrentamentos { get; set; } = new List<CartaoEnfrentamento>();

        public IndexModel(ILogger<IndexModel> logger,
            CartaoEnfrentamentoService cartaoEnfrentamentoService)
        {
            _logger = logger;
            _cartaoEnfrentamentoService = cartaoEnfrentamentoService;
        }

        public void OnGet()
        {
            var cartoes = _cartaoEnfrentamentoService.GetCartoes(User.IdUsuario(), 2);

            CartoesEnfrentamentos = cartoes.Select(c => new CartaoEnfrentamento() { Mensagem = c.Mensagem }).ToList();
        }
    }
}