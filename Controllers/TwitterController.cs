using Microsoft.AspNetCore.DataProtection.KeyManagement;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Net.Http.Headers;

namespace BencomTwitterApp.Controllers
{
    public class TwitterController : Controller
    {
 
        public IActionResult Index()
        {

            var bearer_token = "AAAAAAAAAAAAAAAAAAAAAEswiAEAAAAAN5n12SejPIh8osChcGjzXK%2BXiqw%3DBrgpvcLXgQ6iROiZ139Cq4QVRLjDTZXlq6f9NKlPBhjF3HjBOj";

            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", bearer_token);
                var endpoint = new Uri("https://api.twitter.com/2/tweets?ids=1228393702244134912");
                var result = client.GetAsync(endpoint).Result;
                var json = result.Content.ReadAsStringAsync().Result;
                //Debug.WriteLine(result);
                Debug.WriteLine(json);

            }
      
            return View();
        }
    }
}
