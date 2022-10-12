using BencomTwitterApp.Models;
using Microsoft.AspNetCore.DataProtection.KeyManagement;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using BencomTwitterApp.Services;

namespace BencomTwitterApp.Controllers
{
    public class TwitterController : Controller
    {
        private static TweetService TweetService = new TweetService();
        private static Tweets Tweets = new Tweets();
        private static string TwitterUsername = "minpres";

        public IActionResult Index()
        {
            Tweets = TweetService.getTweetsFromUser(TwitterUsername);
            ViewBag.TwitterAccounts = GetTwitterAccounts();
            ViewBag.TwitterUsername = TwitterUsername;

            return View(Tweets);

        }

        public IActionResult setUser(string Username, string displayname)
        {
            TwitterUsername = Username;

            return RedirectToAction(nameof(Index));
        }

        private List<TwitterAccount> GetTwitterAccounts()
        {
            var twitterAccounts = new List<TwitterAccount>();
            twitterAccounts.Add(new TwitterAccount(){ DisplayName="Mark Rutte", Username="minpres"});
            twitterAccounts.Add(new TwitterAccount() { DisplayName = "Geert Wilders", Username = "geertwilderspvv" });
            twitterAccounts.Add(new TwitterAccount() { DisplayName = "Sigrid Kaag", Username = "Minister_FIN" });
            twitterAccounts.Add(new TwitterAccount() { DisplayName = "Rob Jetten", Username = "MinisterKenE" });
            twitterAccounts.Add(new TwitterAccount() { DisplayName = "Jesse Klaver", Username = "jesseklaver" });

            return twitterAccounts;
        }
    }
}
