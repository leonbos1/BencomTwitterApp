using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace BencomTwitterApp.Models
{
    //model voor de data in een tweet
    public class Tweet
    {
        public List<string>? edit_history_tweet_ids { get; set; }
        public string? id { get; set; }
        public string? text { get; set; }
    }

    //Model dat gebruikt wordt om een tweet json te deserializen
    public class Tweets
    {
        public List<Tweet>? data { get; set; }
    }

}
