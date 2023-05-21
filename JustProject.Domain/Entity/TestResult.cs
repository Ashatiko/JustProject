using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustProject.Domain.Entity
{
    public class TestResult
    {
        public int Id { get; set; }
        public int UserTestId { get; set; }
        public int TestId { get; set; }
        public string NameTest { get; set; }
        public int FirstStep { get; set; }
        public int SecondStep { get; set; }
        public int ThirdStep { get; set; }
        public int FourthStep { get; set; }
        public int Result { get; set; }
    }
}
