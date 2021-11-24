using WebApplication1.Model;

namespace WebApplication2.Model
{
    public class HeroiBatalha
    {
        public Heroi Heroi { get; set; }
        public int HeroiId { get; set; }

        public int BatalhaId { get; set; }
        public Batalha Batalha { get; set; }
    }
}
