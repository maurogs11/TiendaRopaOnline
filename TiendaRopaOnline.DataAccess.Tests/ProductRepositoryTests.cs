using Microsoft.VisualStudio.TestTools.UnitTesting;
using TiendaRopaOnline.DataAccess.DataContext;
using Microsoft.EntityFrameworkCore;
using TiendaRopaOnline.Models;
using System.Drawing;
using TiendaRopaOnline.DataAccess.Repository;

namespace TiendaRopaOnline.DataAccess.Tests
{
    [TestClass]
    public class ProductRepositoryTests
    {

        private async Task<TiendaOnlineContext> GetDbContext()
        {

            var options = new DbContextOptionsBuilder<TiendaOnlineContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            var context = new TiendaOnlineContext(options);
            context.Database.EnsureCreated();

            if (await context.Products.CountAsync() < 0)
            {
                for (int i = 0; i < 10; i++)
                {
                    context.Products.Add(
                    new Product()
                    {
                        Size = "Test",
                        Color = "Test",
                        Price = (decimal)10.22,
                        Description = "Test"
                    });
                    await context.SaveChangesAsync();
                }

            }
            return context;
        }

        [TestMethod]
        public async void AddTest()
        {
            var product = new Product()
            {
                Size = "Test",
                Color = "Test",
                Price = (decimal)10.22,
                Description = "Test"
            };

            var context = await GetDbContext();
            var productRepository = new ProductRepository(context);

            var result = productRepository.Add(product);

            Assert.IsTrue(await result);
        }

        [TestMethod]
        public async void DeleteTest()
        {
            var id = 1;

            var context = await GetDbContext();
            var productRepository = new ProductRepository(context);

            var result = productRepository.Delete(id);

            Assert.IsTrue(await result);
        }

        [TestMethod]
        public async void EditTest()
        {
            var id = 1;

            var context = await GetDbContext();
            var productRepository = new ProductRepository(context);

            var product = await productRepository.FindById(id);
            product.Description = "New Test for EditTest";

            var result = productRepository.Edit(product);

            Assert.IsTrue(await result);

            var newProduct = await productRepository.FindById(id);
            Assert.IsTrue(newProduct.Description == "New Test for EditTest");
        }

        [TestMethod]
        public async void FindByIdTest()
        {
            var id = 1;

            var context = await GetDbContext();
            var productRepository = new ProductRepository(context);

            var result = productRepository.FindById(id);

            Assert.IsTrue(result.Id == 1);
        }
    }
}