using System.Collections.Generic;

namespace Test.DomainModels.Provider
{
    public class ProviderTypes
    {
        public int Id { get; set; }
        public string Name { get; set; } 
        public ICollection<Providers> Providers { get; set; } 
    }
}
