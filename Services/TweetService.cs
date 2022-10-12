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
            //configureren van de authentication 
            _api = new API();
            _BearerToken = _api._BearerToken;
            _httpClient = new HttpClient();
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _BearerToken);
        }

        //haalt laatste 10 tweets van een user op
        public Tweets getTweetsFromUser(string username)
        {
            var url = string.Format("https://api.twitter.com/2/tweets/search/recent?query=from:{0}", username);

            return GetTweets(url);    
        }

        //Methode die voor meerdere endpoints gebruikt kan worden om tweets op te halen
        //geeft de tweets terug in een Tweets model
        private Tweets GetTweets(string url)
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
