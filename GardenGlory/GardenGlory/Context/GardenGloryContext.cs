using System;
using System.Collections.Generic;
using System.Text;
using GardenGlory.EfClasses;
using GardenGlory.EfCode.Configuration;
using Microsoft.EntityFrameworkCore;

namespace GardenGlory.Context
{
    public class GardenGloryContext : DbContext
    {
        public DbSet<AccessRestriction> AccessRestrictions { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<EmployeeStatus> EmployeeStatuses { get; set; }
        public DbSet<EmployeeType> EmployeeTypes { get; set; }
        public DbSet<Equipment> Equipments { get; set; }
        public DbSet<EquipmentRepair> EquipmentRepairs { get; set; }
        public DbSet<EquipmentUsage> EquipmentUsages { get; set; }
        public DbSet<ExperienceLevel> ExperienceLevels { get; set; }
        public DbSet<Owner> Owners { get; set; }
        public DbSet<OwnerType> OwnerTypes { get; set; }
        public DbSet<Payment> Payments{ get; set; }
        public DbSet<PaymentMethod> PaymentMethods { get; set; }
        public DbSet<Property> Properties { get; set; }
        public DbSet<PropertyDescription> PropertyDescriptions{ get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<ServiceType> ServiceTypes { get; set; }
        public DbSet<Task> Tasks { get; set; }
        public DbSet<TrainedEmployee> TrainedEmployees { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(connectionString: @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=GardenGlory;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AccessRestrictionConfig());
            modelBuilder.ApplyConfiguration(new AccountConfig());
            modelBuilder.ApplyConfiguration(new EmployeeConfig());
            modelBuilder.ApplyConfiguration(new EmployeeStatusConfig());
            modelBuilder.ApplyConfiguration(new EmployeeTypeConfig());
            modelBuilder.ApplyConfiguration(new EquipmentConfig());
            modelBuilder.ApplyConfiguration(new EquipmentRepairConfig());
            modelBuilder.ApplyConfiguration(new EquipmentUsageConfig());
            modelBuilder.ApplyConfiguration(new ExperienceLevelConfig());
            modelBuilder.ApplyConfiguration(new OwnerConfig());
            modelBuilder.ApplyConfiguration(new OwnerTypeConfig());
            modelBuilder.ApplyConfiguration(new PaymentConfig());
            modelBuilder.ApplyConfiguration(new PaymentMethodConfig());
            modelBuilder.ApplyConfiguration(new PropertyConfig());
            modelBuilder.ApplyConfiguration(new PropertyDescriptionConfig());
            modelBuilder.ApplyConfiguration(new RoleConfig());
            modelBuilder.ApplyConfiguration(new ServiceConfig());
            modelBuilder.ApplyConfiguration(new ServiceTypeConfig());
            modelBuilder.ApplyConfiguration(new TaskConfig());
            modelBuilder.ApplyConfiguration(new TrainedEmployeeConfig());
        }
    }

}
