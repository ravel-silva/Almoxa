namespace Almoxa.Domain.Entities
{
    public class Categoria : Entidade
    {
        public string Nome { get; private set; } = string.Empty;

        protected Categoria() { }

        public Categoria(string nome)
        {
            Nome = nome;
        }

        public void Renomear(string nome)
        {
           if (string.IsNullOrWhiteSpace(nome))
                throw new DomainException("O nome da categoria é obrigatório.");
            Nome = nome;
        }
    }
}