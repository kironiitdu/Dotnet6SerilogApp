using AzureAdMicrosoftGraph.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Graph;
using Microsoft.Identity.Web;
using System.Diagnostics;
using System.Security.Claims;

namespace AzureAdMicrosoftGraph.Controllers
{
   
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly GraphServiceClient _graphServiceClient;
        public HomeController(ILogger<HomeController> logger,
                         GraphServiceClient graphServiceClient)
        {
            _logger = logger;
            _graphServiceClient = graphServiceClient;
        }
        [AuthorizeForScopes(ScopeKeySection = "DownstreamApi:Scopes")]
        public async Task<IActionResult> Index()
        {
            var givenName = HttpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Name)?.Value;
            var users = await _graphServiceClient
                       .Me
                       .Request()
                       .GetAsync()
                       .ConfigureAwait(false);
            var getNameFromGraph = users.DisplayName;
            var surname = users.Surname;
            @ViewData["GraphApiResult"] = getNameFromGraph;
            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }
        [AllowAnonymous]
        public async Task<IActionResult> SendEmailFromGraphAPI()
        {
            try
            {
                var message = new Message
                {
                    Subject = "Email From Microsoft Graph API?",
                    Body = new ItemBody
                    {
                        ContentType = BodyType.Text,
                        Content = "The new cafeteria is open."
                    },
                    ToRecipients = new List<Recipient>()
                        {
                            new Recipient
                            {
                                EmailAddress = new EmailAddress
                                {
                                   // Address = "fannyd@contoso.onmicrosoft.com"
                                    Address = "kironiitdu@outlook.com"
                                }
                            }
                        },
                    CcRecipients = new List<Recipient>()
                            {
                                new Recipient
                                {
                                    EmailAddress = new EmailAddress
                                    {
                                        Address = "kironiitdu@gmail.com"
                                    }
                                }
                            }
                };

                var saveToSentItems = false;

                await _graphServiceClient.Me
                    .SendMail(message, saveToSentItems)
                    .Request()
                    .PostAsync();
            }
            catch (Exception ex)
            {

                throw;
            }

            
            return Ok();
        }
        [AllowAnonymous]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}