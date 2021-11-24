using WebApplication1.Model;

namespace WebApplication2.Model
{
    public class IdentidadeSecreta
    {
        public int id { get; set; }
        public string NomeReal { get; set; }
        public int HeroiId { get; set; }
        public Heroi  Heroi { get; set; }
    }
}
