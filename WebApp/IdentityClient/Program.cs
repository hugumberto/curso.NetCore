using System;
using IdentityModel.Client;
namespace IdentityClient
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var discoveryClient =  DiscoveryClient.GetAsync("https://localhost:44395/").GetAwaiter().GetResult();
            var token = new TokenClient(discoveryClient.TokenEndpoint, "hugo.goncalves", "123456789");
                var response = token.RequestClientCredentialsAsync("com.primeit").GetAwaiter().GetResult();

            Console.WriteLine(response.Json);
        }
    }
}
