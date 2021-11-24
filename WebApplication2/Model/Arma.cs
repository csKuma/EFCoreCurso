namespace WebApplication1.Model
{
    public class Arma
    {
        public int id { get; set; }
        public string Nome { get; set; }
        public Heroi Heroi { get; set; } // relacionamento de 1 pra muitos 
        public int HeroiId { get; set; }
    }
}

