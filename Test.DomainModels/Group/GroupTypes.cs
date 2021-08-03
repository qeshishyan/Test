using System.Collections.Generic;

namespace Test.DomainModels.Group
{
    public class GroupTypes
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Groups> Groups { get; set; }
    }
}
