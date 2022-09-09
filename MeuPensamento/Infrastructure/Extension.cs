using System.Security.Claims;

namespace MeuPensamento
{
    public static class Extension
    {
        public static int IdUsuario(this ClaimsPrincipal claimsPrincipal)
        {
            if (claimsPrincipal.Claims.Any(i => i.Type == "IdUsuario"))
                return int.Parse(claimsPrincipal.Claims.First(i => i.Type == "IdUsuario").Value);

            return default;
        }
    }
}
