﻿using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace BencomTwitterApp.Models
{
    public class Tweet
    {
        public List<string> edit_history_tweet_ids { get; set; }
        public string id { get; set; }
        public string text { get; set; }
    }

    public class Tweets
    {
        public List<Tweet> data { get; set; }
    }

}
