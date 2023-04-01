using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustProject.Domain.Entity
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Patronumic { get; set; }
        public string Email { get; set; }
        public int Phone { get; set; }
        public string Password { get; set; }

    }
}
