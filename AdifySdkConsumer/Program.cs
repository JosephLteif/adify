using AdifyContracts.Identity;
using AdifySdk;
using Refit;
using System;
using System.Threading.Tasks;


namespace AdifySdkConsumer
{
    class Program
    {
        static async Task Main(string[] args)
        {
             var identityApi = RestService.For<IIdentityApi>("http://localhost:5002");


            /*var registerResponse = await identityApi.RegisterAsync(new RegisterRequest
            {
                Email = "mhamadali_hariri@hotmaildd1.com",
                Username = "Mhamadalihariri1",
                Password = "TestPass.2"
            });*/
            var loginResponse = await identityApi.LoginAsync(new LoginRequest
            {
                Username = "Mhamadalihariri",
                Password = "TestPass.2"
            });
            Console.WriteLine(loginResponse.Content);
            var adApi = RestService.For<IAdApi>("https://localhost:5006");
            var randomAd = await adApi.GetRandomAdAsync();
            Console.WriteLine(randomAd);

            var apByCampain = await adApi.GetAdByCampainAsync(2);
            Console.WriteLine(apByCampain);

        }
    }
}
