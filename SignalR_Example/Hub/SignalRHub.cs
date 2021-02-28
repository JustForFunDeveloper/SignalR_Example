using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace SignalR_Example.Hub
{
    public class SignalRHub : Microsoft.AspNetCore.SignalR.Hub
    {
        private ILogger<SignalRHub> _logger;

        public SignalRHub(ILogger<SignalRHub> logger)
        {
            _logger = logger;
        }

        public async Task InitData(string testString)
        {
            _logger.LogInformation(testString);
            var data = new
            {
                TestStringAnswer = "??",
                TestInt = 42
            };
            // Using the Newtonsoft.Json NuGet package to serialize the object to a json string
            await Clients.All.SendAsync("TestClientCall", JsonConvert.SerializeObject(data));
        }
    }
}