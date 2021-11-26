using System.Collections.Generic;


namespace WebApplication2.Dominio
{
    public class Heroi
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Batalha { get; set; }
        
        public IdentidadeSecreta Identidade { get; set; } // relacionamento 1 pra 1
        public List <Arma> Armas { get; set; } //relacionamento de muitos pra muitos
        public List <HeroiBatalha> HeroisBatalhas { get; set; }//relacionamento de muitos pra muitos
    }
}
