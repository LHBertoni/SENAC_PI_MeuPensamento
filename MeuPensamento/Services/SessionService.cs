namespace MeuPensamento.Services
{
    public class SessionService
    {
        private readonly IHttpContextAccessor _httpContextAcessor;

        public SessionService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAcessor = httpContextAccessor;
        }

        public void SetSession<T>(string sessionKey, T value)
            where T : new()
        {
            _httpContextAcessor?.HttpContext?.Session?.SetString(sessionKey, Newtonsoft.Json.JsonConvert.SerializeObject(value));
        }

        public void RemoveSesion(string sessionKey)
        {
            _httpContextAcessor?.HttpContext?.Session?.Remove(sessionKey);
        }

        public T? GetSession<T>(string sessionKey)
        {
            string str = string.Empty;

            if ((_httpContextAcessor?.HttpContext?.Session?.Keys.Contains(sessionKey) ?? false)
                && !string.IsNullOrWhiteSpace(str = _httpContextAcessor?.HttpContext?.Session?.GetString(sessionKey) ?? string.Empty))
                return Newtonsoft.Json.JsonConvert.DeserializeObject<T>(str) ?? default(T);

            return default(T);
        }
    }
}
