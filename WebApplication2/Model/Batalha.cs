using System;
using System.Collections.Generic;
using WebApplication2.Model;

namespace WebApplication1.Model
{
    public class Batalha
    {
        public int id { get; set; }
        public string Nome { get; set; }
        public string Descrição { get; set; }
        public  DateTime DtInicio { get; set; }
        public DateTime DtFim { get; set; }
        public List<HeroiBatalha> HeroisBatalhas { get; set; }
    }
}

