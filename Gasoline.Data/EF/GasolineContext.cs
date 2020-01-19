using Gasoline.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gasoline.Data.EF
{
    public class GasolineContext : DbContext
    {

        public GasolineContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //Configure SQL server 
            optionsBuilder.UseSqlServer("Server=DESKTOP-NSLMOQH\\SQLEXPRESS;Database=Gasoline;Trusted_Connection=True;");

        }

        /// <summary>
        /// Table for all entities 
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <returns></returns>
        public IQueryable<TEntity> Table<TEntity>() where TEntity : class
        {
            return this.Set<TEntity>().AsQueryable();
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Set primary key for FuelTypes
            modelBuilder.Entity<FuelType>()
                .HasKey(x => x.Id);


            //Add data to FuelTypes table
            modelBuilder.Entity<FuelType>()
                .HasData(
                    new FuelType
                    {
                        Id = Guid.Parse("1b4da7c2-df0c-4e61-9e57-b39123b335db"),
                        FuelName = "Benzyna 95"
                    },
                    new FuelType
                    {
                        Id = Guid.Parse("2b29eff4-77c5-42d3-9ad4-dd32d4ccb41e"),
                        FuelName = "Benzyna 98"
                    },
                    new FuelType
                    {
                        Id = Guid.Parse("0fbaa67e-ce11-4e71-bb00-5a9c10701b34"),
                        FuelName = "Diesel"
                    },
                    new FuelType
                    {
                        Id = Guid.Parse("fb46fb8f-010c-4d05-b102-baae43dac348"),
                        FuelName = "LPG"
                    }
                );

            //Set primary key for GasStation
            modelBuilder.Entity<GasStation>().HasKey(x => x.Id);

            //Set primary keys for GasStationFuel
            modelBuilder.Entity<GasStationFuel>().HasKey(x => new { x.GasStationId, x.FuelTypeId });

            modelBuilder.Entity<GasStation>()
                .HasData(
                new GasStation
                {
                    Id = Guid.Parse("60a4ef9c-7664-440e-804c-a5acf530a529"),
                    Name = "Lotos",
                    City = "Czciana",
                    PostalCode = "69-666",
                    Street = "Czciana"
                },
                new GasStation
                {
                    Id = Guid.Parse("e64e5e92-9701-4f5f-95db-d55f20d20210"),
                    Name = "BP",
                    City = "Wysoka Gogolowska",
                    PostalCode = "36-061",
                    Street = "Strumykowa"
                });

            modelBuilder.Entity<GasStation>()
                .HasMany(x => x.GasStationFuels)
                .WithOne(x => x.GasStation);

            modelBuilder.Entity<GasStationFuel>()
                .HasOne(x => x.FuelType)
                .WithMany(x => x.GasStationFuels);
        }
    }
}