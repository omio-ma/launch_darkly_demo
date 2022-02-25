using LaunchDarkly.Sdk.Server;
using LaunchDarkly.Sdk.Server.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WebApplication3.Models;

namespace WebApplication3.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ILdClient _ldClient;

        public HomeController(ILogger<HomeController> logger, ILdClient ldClient)
        {
            _logger = logger;
            _ldClient = ldClient;
        }

        public IActionResult Index()
        {
            //var user = LaunchDarkly.Sdk.User.WithKey("api-user-key");
            var user = LaunchDarkly.Sdk.User.WithKey("asdsad");
            var flags = _ldClient.AllFlagsState(user).ToValuesJsonMap();
            var featureval = _ldClient.BoolVariation("feature-one", user);
            var featureval2 = _ldClient.BoolVariation("admissions", user);

            return View(new HomeViewModel { FeatureOne = featureval, FeatureTwo = featureval2});
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
