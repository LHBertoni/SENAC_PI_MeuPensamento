namespace MeuPensamento.Models.MeusPensamentos
{
    public class MeuPensamento
    {
        public long Id { get; set; }
        public string Pensamento { get; set; } = string.Empty;
        public string Situacao { get; set; } = string.Empty;
        public List<string> Reacoes { get; set; } = new List<string>();
        public string SentimentoAdicional { get; set; } = string.Empty;
        public int Raiva { get; set; }
        public int Angustia { get; set; }
        public int Tristeza { get; set; }
        public int Ansiedade { get; set; }
        public DateTime DataHora { get; set; } = DateTime.Now;
    }
}
