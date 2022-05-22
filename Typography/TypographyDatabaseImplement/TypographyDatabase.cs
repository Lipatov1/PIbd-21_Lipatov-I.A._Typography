﻿using TypographyDatabaseImplement.Models;
using Microsoft.EntityFrameworkCore;

namespace TypographyDatabaseImplement {
    public class TypographyDatabase : DbContext {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            if (optionsBuilder.IsConfigured == false) {
                optionsBuilder.UseSqlServer(@"Data Source=localhost;Initial Catalog=TypographyDatabase;Integrated Security=True;MultipleActiveResultSets=True;");
            }
            base.OnConfiguring(optionsBuilder);
        }

        public virtual DbSet<Component> Components { set; get; }
        public virtual DbSet<Printed> Printeds { set; get; }
        public virtual DbSet<PrintedComponent> PrintedComponents { set; get; }
        public virtual DbSet<Order> Orders { set; get; }
        public virtual DbSet<Client> Clients { set; get; }
        public virtual DbSet<WarehouseComponent> WarehouseComponents { get; set; }
        public virtual DbSet<Warehouse> Warehouses { get; set; }
        public virtual DbSet<Implementer> Implementers { get; set; }
        public virtual DbSet<MessageInfo> MessageInfoes { get; set; }
    }
}