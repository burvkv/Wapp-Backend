
using Core.Entity.Concrete;
using Entity.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace DataAccess.Concrete
{
    
    public class TwAppContext:DbContext
    {

        public DbSet<DebitStatus> DebitStatuses { get; set; }
        public DbSet<Debit> Debits { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Hardware> Hardwares { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserOperationClaim> UserOperationClaims { get; set; }
        public DbSet<OperationClaim> OperationClaims { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Model> Models { get; set; }
        public DbSet<Label> Labels { get; set; }

        public DbSet<Image> Images { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL("server=mysql06.trwww.com;database=arcaserv_wappdb;user=trenkwalder;password=TrenkWalder1!");
        }
       
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Debit>(entity =>
            {
                entity.HasKey(e => e.DebitId);
              
            });

            modelBuilder.Entity<Label>(entity =>
            {
                entity.HasKey(e => e.LabelId);

            });

            


            modelBuilder.Entity<DebitStatus>(entity =>
            {
                entity.HasKey(e => e.Id);  
            });

            modelBuilder.Entity<Employee>(e =>
            {
                e.HasKey(e => e.EmployeeId);
            });

            modelBuilder.Entity<Hardware>(entity =>
            {
                entity.HasKey(e => e.Id);
            });

          

            modelBuilder.Entity<Project>(entity =>
            {
                entity.HasKey(e => e.ProjectId);
            });

            modelBuilder.Entity<Model>(entity =>
            {
                entity.HasKey(e => e.ModelId);
            });
        }

    }
}
