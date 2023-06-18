using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JustProject.Domain.Entity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using JustProject.Domain.Entity.Test;

namespace JustProject.DAL
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
        public DbSet<User> User { get; set; }
        public DbSet<UserTests> UserTests { get; set; }
        public DbSet<UserAllowTest> UserAllowTest { get; set; }
        public DbSet<TestResult> TestResult { get; set; }        
        public DbSet<Reviews> Reviews { get; set; }


        public DbSet<Tests> Tests { get; set; }
        public DbSet<TestGroups> TestGroups { get; set; }
        public DbSet<Questions> Questions { get; set; }
        public DbSet<Answers> Answers { get; set; }
        public DbSet<GroupsResult> GroupsResult { get; set; }
    }

}
