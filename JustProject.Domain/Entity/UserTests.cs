using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustProject.Domain.Entity
{
    public class UserTests
    {
        public int Id { get; set; }
        public int Tests { get; set; }
        public string NameTest { get; set; }
        public string Type { get; set; }
        public DateTime Date { get; set; }
        public int Complete { get; set; }
    }
}
