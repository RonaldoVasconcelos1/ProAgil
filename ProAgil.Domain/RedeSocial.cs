namespace ProAgil.Domain
{
    public class RedeSocial
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string URL { get; set; }
        public int? EventoId { get; set; }//Chave Estrangeira do Banco de dados
        public int? PalestranteId { get; set; }//Chave Estrangeira do Banco de dados
        public Palestrante Palestrante { get; }
        public Evento Evento { get; }
    }
}