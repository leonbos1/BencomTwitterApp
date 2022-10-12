using BencomTwitterApp.Data;
using BencomTwitterApp.Models;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Net.Http.Headers;

namespace BencomTwitterApp.Services
{
    public class TweetService
    {
        private API _api;
        private string _BearerToken;
        private HttpClient _httpClient;

        public TweetService()
        {
            _api = new API();
            _BearerToken = _api._BearerToken;
            _httpClient = new HttpClient();
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _BearerToken);
        }

        public Tweets getTweetsFromUser(string username)
        {
            var url = string.Format("https://api.twitter.com/2/tweets/search/recent?query=from:{0}", username);

            return Get(url);    
        }

        private Tweets Get(string url)
        {
            try
            {
                var response = _httpClient.GetAsync(url).Result;
                string jsonResponse = response.Content.ReadAsStringAsync().Result;
                Tweets tweets = JsonConvert.DeserializeObject<Tweets>(jsonResponse);

                return tweets;
            }

            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return new Tweets();

            }
        }

    }
}
