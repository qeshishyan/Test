using Test.DomainModels.Group;

namespace Test.DomainModels.Provider
{
    public class Providers
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ProviderTypeId { get; set; }
        public int GroupId { get; set; }
        public ProviderTypes ProviderTypes { get; set; }
        public Groups Groups { get; set; }
    }
}
