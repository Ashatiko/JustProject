using JustProject.Domain.Entity;
using JustProject.Domain.Entity.Test;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustProject.Domain.ViewModels.Tests
{
    public class CommonTestResultViewModel
    {
        public IEnumerable<GroupsResult> GroupsResult { get;set;}
        public TestResult TestResult { get; set; }
    }
}
