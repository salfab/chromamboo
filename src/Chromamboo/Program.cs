using System;
using System.IO;
using System.Linq;

using Chromamboo.Web;

using Microsoft.AspNetCore.Hosting;

using Ninject;
using Ninject.Extensions.Conventions;

namespace Chromamboo
{
    public class Program
    {
        private static void Main(string[] args)
        {
            if (args.Contains("config"))
            {
                StartConfig();
            }
            else
            {
                var kernel = BuildKernel();
                var bootstrapper = kernel.Get<IBoostrapper>();
                bootstrapper.Start();        
            }
                
            Console.WriteLine("Hit any key to exit...");
            Console.ReadKey();
        }

        private static void StartConfig()
        {
            var host = new WebHostBuilder()
           .UseKestrel()
           .UseContentRoot(Directory.GetCurrentDirectory())
           .UseStartup<Startup>()
           .Build();

            host.Run();
        }

        private static IKernel BuildKernel()
        {
            var kernel = new StandardKernel();

            kernel.Bind(x =>
                x.FromThisAssembly()
                    .IncludingNonePublicTypes()
                    .SelectAllClasses()
                    .Where(type => type.GetInterfaces().Length == 1)
                    .BindSelection((type, types) => type.GetInterfaces().Take(1)));

            return kernel;
        }
    }
}
