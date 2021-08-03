using Test.CustomModels.Group;
using Test.CustomModels.ProviderType;

namespace Test.CustomModels.Provider
{
    public class ProviderResponseModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ProviderTypeResponseModel ProviderType { get; set; }
        public GroupResponseModel Group { get; set; }
    }
}
