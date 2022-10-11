using BencomTwitterApp.Models;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Net.Http.Headers;

namespace BencomTwitterApp.Services
{
    public class TweetService
    {

        public Tweets getTweetsFromUser(string username)
        {
            API api = new API();

            var bearer_token = api.getBearerToken();

            var url = string.Format("https://api.twitter.com/2/tweets/search/recent?query=from:{0}", username);
            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", bearer_token);

            try
            {
                var response = client.GetAsync(url).Result;
                string jsonResponse = response.Content.ReadAsStringAsync().Result;
                Debug.WriteLine(jsonResponse);

                Tweets tweets = JsonConvert.DeserializeObject<Tweets>(jsonResponse);
                tweets.Username = username;

                return tweets;

            }

            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);

            }

            return new Tweets(username);
        }

    }
}
