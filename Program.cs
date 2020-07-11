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
                    ConsumerKey = "dAv6QDI0jUrYvbG6HrPTcEdey",
                    ConsumerSecret = "dhU6oak2Grs7A6KAlAqQ2mc0QfRN2n29esi5oMMlGggP2Le4Nk",
                    OAuthToken = "925200972-Z8BN4Bmd4n43SR6llbXM9FOtFIjFKfrnmFGhm82s",
                    OAuthTokenSecret = "bebuqbZccPhxwOfOA0Y3o8apbcfk8MbSA3rhUadrK1JRk"
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
