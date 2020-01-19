using Gasoline.Api;
using Gasoline.Data.Services;
using System;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using Xunit;
using Xunit.Abstractions;
using System.Net.Http;
using Gasoline.Data.EF;
using Microsoft.EntityFrameworkCore;
using System.Collections;
using Gasoline.Data.Models;
using System.Collections.Generic;
using System.Linq;
using Xunit.Sdk;

namespace Gasoline.Test
{
    [TestCaseOrderer("Gasoline.Test.UnitTest", "OrderTestCases")]
    public class UnitTest : ITestCaseOrderer
    {
        private readonly FuelTypeService fuelTypeService;
        DbContextOptions<GasolineContext> options;


        public UnitTest(ITestOutputHelper output)
        {
            options = new DbContextOptionsBuilder<GasolineContext>()
                .UseInMemoryDatabase("Test")
                .Options;

            fuelTypeService = new FuelTypeService(new GasolineContext(options));
        }

        [Fact]
        public async Task Test1()
        {
            using (var context = new GasolineContext(options))
            {
                var x = await context.AddAsync(new Data.Models.FuelType { Id = Guid.Parse("74d5aaf9-f5f1-45fe-bc79-1ab94eddb806"), FuelName = "Benzyna 95" });
                await context.SaveChangesAsync();
            }

            using (var context = new GasolineContext(options))
            {
                var service = new FuelTypeService(context);
                IEnumerable<FuelType> result = await service.BrowseAsync();

                // Check if FuelType was added
                Assert.Single(result.ToList());
            }
        }

        [Fact]
        public async Task Test2()
        {
            using (var context = new GasolineContext(options))
            {
                var service = new FuelTypeService(context);
                IEnumerable<FuelType> result = await service.BrowseAsync();

                // Check if FuelType was added
                Assert.Single(result.ToList());
            }
        }

        [Fact]
        public async Task Test3()
        {
            using (var context = new GasolineContext(options))
            {
                var service = new FuelTypeService(context);
                await service.AddAsync(new Data.Models.FuelType { Id = Guid.Parse("74d5aaf9-f5f1-45fe-bc79-1ab94eddb806"), FuelName = "Benzyna 95" });
                IEnumerable<FuelType> result = await service.BrowseByNameAsync("Benzyna");

                Assert.Single(result.ToList());
            }
        }


        [Fact]
        public async Task Test4()
        {
            using (var context = new GasolineContext(options))
            {
                var service = new FuelTypeService(context);
                var x = await service.RemoveAsync(Guid.Parse("74d5aaf9-f5f1-45fe-bc79-1ab94eddb806"));

                var result = await service.BrowseAsync();

                Assert.Empty(result.ToList());
            }
        }

        public IEnumerable<TTestCase> OrderTestCases<TTestCase>(IEnumerable<TTestCase> testCases)
            where TTestCase : ITestCase
        {
            var result = testCases.ToList();
            result.Sort((x, y) => string.CompareOrdinal(x.TestMethod.Method.Name, y.TestMethod.Method.Name));
            return result;
        }
    }
}