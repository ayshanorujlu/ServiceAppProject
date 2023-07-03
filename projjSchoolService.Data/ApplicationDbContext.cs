using Microsoft.EntityFrameworkCore;
using projSchoolService.Models.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projjSchoolService.Data_
{
    public class ApplicationDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder.UseSqlServer("Data Source=WIN-2FA9I1VU4LK;Initial Catalog=ServiceDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>()
                     .HasOne(s => s.Class)
                     .WithMany(c => c.Students)
                     .HasForeignKey(s => s.ClassId)
                     .OnDelete(DeleteBehavior.NoAction);


            //modelBuilder.Entity<Student>()
            //			 .HasOne(s => s.Ride)
            //			 .WithMany(r => r.Students)
            //			 .HasForeignKey(s => s.RideId);


            modelBuilder.Entity<Student>()
                         .HasOne(s => s.Parent)
                         .WithMany(p => p.Students)
                         .HasForeignKey(s => s.ParentId);



            modelBuilder.Entity<Parent>()
                        .HasMany(p => p.Students)
                        .WithOne(s => s.Parent)
                        .HasForeignKey(s => s.ParentId)
                        .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Class>()
                    .HasMany(c => c.Students)
                    .WithOne(s => s.Class)
                    .HasForeignKey(s => s.ClassId)
                    .OnDelete(DeleteBehavior.Cascade);



            modelBuilder.Entity<Car>()
                         .HasOne(c => c.Driver)
                         .WithOne(d => d.Car)
                         .HasForeignKey<Driver>(d => d.CarId);

            modelBuilder.Entity<Driver>()
                .HasOne(d => d.Car)
               .WithOne(c => c.Driver)
               .HasForeignKey<Driver>(d => d.CarId);

            modelBuilder.Entity<Ride>()
            .HasOne(r => r.Driver)
           .WithOne(d => d.Ride)
           .HasForeignKey<Driver>(d => d.RideId);



        }
    }
}
