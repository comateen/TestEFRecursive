﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
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

           
        }
        public DbSet<Profile> listMeetings { get; set; }
        public DbSet<ProfileShared> listContactMeetings { get; set; }
    }
}
