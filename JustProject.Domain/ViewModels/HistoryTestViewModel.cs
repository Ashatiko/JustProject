using JustProject.Domain.Entity;
using JustProject.Domain.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustProject.Domain.ViewModels
{
    public class HistoryTestViewModel
    {
        public User User { get; set; }

        public IEnumerable<UserTests> Tests { get; set; }
    }
}
