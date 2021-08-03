using System.Collections.Generic;
using Test.DomainModels.Provider;

namespace Test.DomainModels.Group
{
    public class Groups
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int GroupTypeId { get; set; }
        public GroupTypes GroupTypes { get; set; }
        public ICollection<Providers> Providers { get; set; }
    }
}
