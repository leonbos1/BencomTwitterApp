using BencomTwitterApp.Models;
using Microsoft.AspNetCore.Mvc;
using BencomTwitterApp.Services;

namespace BencomTwitterApp.Controllers
{
    public class TwitterController : Controller
    {
        private static TweetService _TweetService = new TweetService();
        private static Tweets? Tweets = new Tweets();
        private static string? TwitterUsername;
        private static List<TwitterAccount> TwitterAccounts = new List<TwitterAccount>();

        public IActionResult Index()
        {
            //check of de accounts al initialized zijn
            if (TwitterAccounts.Count == 0)
            {
                InitTwitterAccounts();
            }

            Tweets = _TweetService.getTweetsFromUser(TwitterUsername);
            ViewBag.TwitterUsername = TwitterUsername;
            ViewBag.TwitterAccounts = TwitterAccounts;

            return View(Tweets);

        }

        //veranderen van twitter gebruiker
        //deze method wordt aangeroepen vanuit de dropdown
        //na het aanroepen staan er tweets van de aangeroepen gebruiker in de view
        public IActionResult SetUser(string Username)
        {
            TwitterUsername = Username;

            return RedirectToAction(nameof(Index));
        }

        //initializen van de twitter accounts in de dropdown
        private void InitTwitterAccounts()
        {
            AddTwitterAccount("Mark Rutte", "minpres");
            AddTwitterAccount("Geert Wilders", "geertwilderspvv");
            AddTwitterAccount("Sigrid Kaag", "Minister_FIN");
            AddTwitterAccount("Rob Jetten", "MinisterKenE");
            AddTwitterAccount("Jesse Klaver", "jesseklaver");
            //om te voorkomen dat er een lege pagina wordt weergegeven, is de eerste gebruiker in de dropdown, de standaard gebruiker
            TwitterUsername = TwitterAccounts[0].Username;
        }

        //aparte functie voor toevoegen van accounts zodat de applicatie eventueel uitgebreid kan worden met extra accounts toevoegen aan dropdown
        private void AddTwitterAccount(string Displayname, string Username)
        {
            TwitterAccounts.Add(new TwitterAccount() { DisplayName = Displayname, Username = Username });
        }
    }
}
