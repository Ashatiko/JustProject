using JustProject.Domain.Entity.Test;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustProject.Domain.ViewModels.Tests
{
    public class CommonTestsViewModel
    {
        public IEnumerable<Answers> Answers { get; set; }
        public IEnumerable<Questions> Questions { get; set; }
        public TestGroups TestGroups{ get;set; }
    }
}
