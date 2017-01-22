using System.Net.Mime;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;

namespace Chromamboo.Web.Controllers
{
    [Route("config")]
    public class ConfigurationController : ControllerBase
    {
        public string Get()
        {
            return System.IO.File.ReadAllText("settings.json");
        }
    }
}