﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JustProject.Domain.Entity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

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
        public DbSet<Tests> Tests { get; set; }
        public DbSet<Reviews> Reviews { get; set; }
    }

    //public class ApplicationDBContext : IdentityDbContext<ApplicationUser, IdentityRole<long>, long>
    //{
    //    public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
    //    {
    //        Database.Migrate();
    //    }

    //    public DbSet<User> User { get; set; }
    //    public DbSet<UserTests> UserTests { get; set; }
    //    public DbSet<UserAllowTest> UserAllowTest { get; set; }
    //    public DbSet<TestResult> TestResult { get; set; }
    //    public DbSet<Tests> Tests { get; set; }
    //    public DbSet<Reviews> Reviews { get; set; }
    //}

}
