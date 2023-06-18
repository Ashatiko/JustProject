using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustProject.Domain.Entity.Test
{
    public class GroupsResult
    {
        public int GroupsResultId { get; set; }
        public int TestResultId { get; set; }
        public string GroupName { get; set; }
        public int GroupCorrectAns { get; set;}        
        public int UserTestsId { get;set; }
    }
}
