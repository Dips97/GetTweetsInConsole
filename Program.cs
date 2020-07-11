using LinqToTwitter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitterAPIApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var auth = new SingleUserAuthorizer
            {
                CredentialStore = new InMemoryCredentialStore
                {
                    ConsumerKey = "Consumer Key",
                    ConsumerSecret = "Consumer Key Secret",
                    OAuthToken = "Access Token",
                    OAuthTokenSecret = "Access Token Secret"
                }
            };
            
            var twitterCtx = new TwitterContext(auth);
            Console.WriteLine("Enter the username whose tweets you want to see");
            var userInput = Console.ReadLine();
            Console.WriteLine("Loading Top 10 Tweets\n");
            
            var tweets = (from tweet in twitterCtx.Status
                          where tweet.Type == StatusType.User
                          && tweet.ScreenName == userInput
                         select tweet).Take(10);

            foreach (var tweet in tweets)
            {
                Console.WriteLine($"{tweet.User.Name} - {tweet.Text.Trim()}\n");
            }
            Console.ReadLine();
        }
    }
}
