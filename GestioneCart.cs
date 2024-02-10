using System.Collections.Generic;

namespace santana.luz._5i.SignUp_Purchase.Models
{
    public class GestioneCart
    {
        private static List<ArticoliCart> _articoliCarrello = new List<ArticoliCart>();

        public static void AggiungiAlCarrello(ArticoliCart articolo)
        {
            _articoliCarrello.Add(articolo);
        }

        public static List<ArticoliCart> GetArticoliCart()
        {
            return _articoliCarrello;
        }
    }
}
