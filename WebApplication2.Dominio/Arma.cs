 namespace WebApplication2.Dominio

{
    public class Arma
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public Heroi Heroi { get; set; } // relacionamento de 1 pra muitos 
        public int HeroiId { get; set; }
    }
}

