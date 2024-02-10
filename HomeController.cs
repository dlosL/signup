using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging; // Aggiunto per risolvere l'errore del logger
using santana.luz._5i.SignUp_Purchase.Models;

namespace santana.luz._5i.SignUp_Purchase.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger)); // Corretto l'errore del logger
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [HttpGet]
        public IActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SignUp(string nome, string email, string cognome, DateTime datadinascita, string genere, string ruolo)
        {
            ViewData["Nome"] = nome;
            ViewData["Email"] = email;
            ViewData["Cognome"] = cognome;
            ViewData["DataNascita"] = datadinascita.ToString("yyyy-MM-dd"); // Formattato come stringa
            ViewData["Ruolo"] = ruolo;
            ViewData["Genere"] = genere;
            return View("SignUpConferma");
        }

        public IActionResult SignUpConferma()
        {
            return View();
        }

        public IActionResult Cart()
        {
            // Recupera gli elementi dal carrello dal servizio
            var articoliCarrello = GestioneCart.GetArticoliCart();

            return View(articoliCarrello);
        }

        [HttpGet]
        public IActionResult Purchase()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Purchase(string nomeProdotto, int quantita)
        {
            GestioneCart.AggiungiAlCarrello(new ArticoliCart { NomeProdotto = nomeProdotto, Quantita = quantita });
            return RedirectToAction("Cart"); // Corretto il nome dell'azione da "Carrello" a "Cart"
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
