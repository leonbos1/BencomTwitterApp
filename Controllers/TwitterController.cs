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
        private TweetService TweetService = new TweetService();
        private static Tweets Tweets;

        public IActionResult Index()
        {
            if (Tweets == null)
            {
                Debug.WriteLine("here");
                return View();
            }

            Tweets = TweetService.getTweetsFromUser(Tweets.Username);
            return View(Tweets);

        }

        public IActionResult setUser(string Username)
        {
            if (Username == null)
            {
                
                return RedirectToAction(nameof(Index));
            }

            if (Tweets == null)
            {
                Tweets = new Tweets(Username);
            }
            else
            {
                Tweets.Username = Username;
            }
            
            return RedirectToAction(nameof(Index));
        }
    }
}
