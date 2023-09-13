using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using TestEFRecursive.DataSet;
using TestEFRecursive.Entities;
using TestEFRecursive.EntitiesConfiguration;

namespace TestEFRecursive
{
    public class DataContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionBuilder)
        {
            optionBuilder.UseSqlServer(
                    @"Server=(localdb)\mssqllocaldb;Database=testRecursive"
                );
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProfileConfiguration());
            modelBuilder.ApplyConfiguration(new ProfileDataSet());

            modelBuilder.ApplyConfiguration(new ProfileSharedConfiguration());
            modelBuilder.ApplyConfiguration(new ProfileSharedDataSet());

            //modelBuilder.Entity<Profile>()
            //            .HasMany(p => p.ProfilesBase)
            //            .WithMany(p => p.ProfilesShared)
            //            .UsingEntity<ProfileShared>(
            //                    e => e.HasOne<Profile>().WithMany().HasForeignKey(e => e.BasedUserId),
            //                    e => e.HasOne<Profile>().WithMany().HasForeignKey(e => e.SharedProfileId));


        }
        public DbSet<Profile> listMeetings { get; set; }
        public DbSet<ProfileShared> listContactMeetings { get; set; }
    }
}

//modelBuilder.Entity<Product>().HasMany(x => x.RelatedProducts)
//                              .WithMany(r => r.RelatedProductsOf)
//                              .UsingEntity<ProductAssociation>(x => x.HasOne(p => p.RelatedProduct)
//                              .WithMany().HasForeignKey(f => f.RelatedProductID), x => x.HasOne(p => p.Product)
//                              .WithMany().HasForeignKey(f => f.ProductID).OnDelete(DeleteBehavior.NoAction));
