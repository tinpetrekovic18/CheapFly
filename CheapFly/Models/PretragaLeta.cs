namespace CheapFly.Models
{
    public class PretragaLeta
    {
        public int Id { get; set; }
        public string polazniAerodrom { get; set; }
        public string odredisniAerodrom { get; set; }
        public DateTime datumPolaska { get; set; }
        public DateTime datumPovratka { get; set; }
        public int brojPutnika { get; set; }
        public string valuta { get; set; }
        public decimal ukupnaCijena { get; set; }
        public int brojPresjedanja { get; set; }
    }
}
