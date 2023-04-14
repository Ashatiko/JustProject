using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustProject.Domain.Entity
{
    public class Tests
    {
        public int Id { get; set; }
        public string NameTest { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
        public decimal Cost { get; set; }
    }
}
