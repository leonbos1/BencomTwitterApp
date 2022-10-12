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

            return View(Tweets);

        }

        public IActionResult setUser(string Username)
        {
            TwitterUsername = Username;
              
            return RedirectToAction(nameof(Index));
        }
    }
}
