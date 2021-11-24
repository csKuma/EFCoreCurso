using System.Collections.Generic;
using WebApplication2.Model;

namespace WebApplication1.Model
{
    public class Heroi
    {
        public int id { get; set; }
        public string Nome { get; set; }
        public string Batalha { get; set; }
        public IdentidadeSecreta Identidade { get; set; } // relacionamento 1 pra 1
        public List<Arma> Armas { get; set; } //relacionamento de muitos pra muitos
        public List<HeroiBatalha> HeroisBatalhas { get; set; }//relacionamento de muitos pra muitos
    }
}
