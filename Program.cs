using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using CarContract;

namespace CarHost
{
    class Program : IPartImportsSatisfiedNotification
    {
        [ImportMany(typeof(ICarContract))]
        private IEnumerable<Lazy<ICarContract>> CarParts { get; set; }

        static void Main(string[] args)
        {
            new Program().Run();
        }
        void Run()
        {          
            var catalog = new DirectoryCatalog(".");
            var container = new CompositionContainer(catalog);
            container.ComposeParts(this);
            foreach (Lazy<ICarContract> car in CarParts)
                Console.WriteLine(car.Value.StartEngine("Sebastian"));
            container.Dispose();
        }
        public void OnImportsSatisfied()
        {
            Console.WriteLine("CarHost imports are satisfied.");
        }
    }
}
