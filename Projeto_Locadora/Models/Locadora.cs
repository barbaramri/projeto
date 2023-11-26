namespace Projeto_Locadora.Models
{
    public abstract class EntidadeBase
    {
        public long? Id { get; set; }
    }

    public class Locadora : EntidadeBase
    {
        public string Nome { get; set; }
        public string Descricao { get; set; }
    }
}