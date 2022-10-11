using BencomTwitterApp.Models;
using Microsoft.AspNetCore.DataProtection.KeyManagement;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace BencomTwitterApp.Controllers
{
    public class TwitterController : Controller
    {

        public static string TwitterUsername = "geertwilderspvv";

        public IActionResult Index()
        {
         
            var bearer_token = "AAAAAAAAAAAAAAAAAAAAAEswiAEAAAAAN5n12SejPIh8osChcGjzXK%2BXiqw%3DBrgpvcLXgQ6iROiZ139Cq4QVRLjDTZXlq6f9NKlPBhjF3HjBOj";
            Debug.WriteLine(TwitterUsername);

            var url = string.Format("https://api.twitter.com/2/tweets/search/recent?query=from:{0}", TwitterUsername);
            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", bearer_token);

            try
            {
                var response = client.GetAsync(url).Result;
                string jsonResponse = response.Content.ReadAsStringAsync().Result;
                Debug.WriteLine(jsonResponse);

                var tweets = JsonConvert.DeserializeObject<Root>(jsonResponse);

                //Debug.WriteLine(tweets.data[0].text);

                return View(tweets);

            }

            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);

            }

            return View();

        }

        public IActionResult setUser(string Username)
        {
            if (TwitterUsername != "")
            {
                TwitterUsername = Username;
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
