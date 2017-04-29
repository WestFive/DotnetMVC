using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using MvcTest.Models;

namespace MvcTest.Data_Access_Laye
{
    public class SalesERPDAL : DbContext
    {
        public SalesERPDAL() : base("name=SalesERPDAL")
        {

        }
        public DbSet<Employee> Employees { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().ToTable("tb_employees");
            base.OnModelCreating(modelBuilder);
        }


    }
}