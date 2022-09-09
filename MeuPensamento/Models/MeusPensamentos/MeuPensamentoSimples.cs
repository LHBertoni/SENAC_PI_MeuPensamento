namespace MeuPensamento.Models.MeusPensamentos
{
    public class MeuPensamentoSimples
    {
        public long Id { get; set; }
        public string Pensamento { get; set; } = string.Empty;
        public DateTime DataHora { get; set; }
    }

    public class MeuPensamentoDataSimples
    {
        public DateTime Data { get; set; }

        public List<MeuPensamentoSimples> Pensamentos { get; set; } = new List<MeuPensamentoSimples>(); 
    }
}
