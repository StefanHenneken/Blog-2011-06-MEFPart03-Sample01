using System;
using System.ComponentModel.Composition;
using CarContract;

namespace CarMercedes
{ 
    [Export(typeof(ICarContract))]
    public class Mercedes : ICarContract, IPartImportsSatisfiedNotification
    {
        private Mercedes()
        {
            Console.WriteLine("Mercedes constructor.");
        }
        public string StartEngine(string name)
        {
            return String.Format("{0} starts the Mercedes.", name);
        }
        public void OnImportsSatisfied()
        {
            Console.WriteLine("Mercedes import is satisfied.");
        }
    }
}
