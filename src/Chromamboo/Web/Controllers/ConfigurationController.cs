using System.Collections.Generic;
using System.Net.Mime;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Extensions.Primitives;

namespace Chromamboo.Web.Controllers
{
    [Route("config")]
    public class ConfigurationController : ControllerBase
    {
        public string Get()
        {
            this.Response.Headers.Add(new KeyValuePair<string, StringValues>("Access-Control-Allow-Origin", new StringValues("*")));
            return System.IO.File.ReadAllText("settings.json");
        }
    }
}