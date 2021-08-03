using Test.CustomModels.GroupType;

namespace Test.CustomModels.Group
{
    public class GroupResponseModel
    {
        public int Id { get; set; }
        public string Name { get; set; } 
        public GroupTypeResponseModel GroupType { get; set; }
    }
}
