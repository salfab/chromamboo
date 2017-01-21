using System;
using System.Linq;

using Chromamboo.Contracts;

using Ninject;
using Ninject.Extensions.Conventions;

namespace Chromamboo
{
    public class Program
    {
        private static void Main(string[] args)
        {
            var kernel = BuildKernel();
            var bootstrapper = kernel.Get<IBoostrapper>();
            bootstrapper.Start();        
                
            Console.WriteLine("Hit any key to exit...");
            Console.ReadKey();
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
