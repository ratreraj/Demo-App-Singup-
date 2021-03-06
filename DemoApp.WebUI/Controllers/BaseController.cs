using DemoApp.WebUI.Sweatalert;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace DemoApp.WebUI.Controllers
{
    public class BaseController : Controller
    {

        public void Notify(string message, string title = "Demo App",
                                    NotificationType notificationType = NotificationType.success)
        {

            //var options = new JsonSerializerOptions
            //{
            //    //PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            //    WriteIndented = true
            //};
            var msg = new
            {
                message = message,
                title = title,
                icon = notificationType.ToString(),
                type = notificationType.ToString(),
                provider = GetProvider()
            };

           

            TempData["Message"] = JsonSerializer.Serialize(msg);
        }

        private string GetProvider()
        {
            var builder = new ConfigurationBuilder()
                            .SetBasePath(Directory.GetCurrentDirectory())
                            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                            .AddEnvironmentVariables();

            IConfigurationRoot configuration = builder.Build();

            var value = configuration["NotificationProvider"];

            return value;
        }
    }
}
