using TiendaRopaOnline.Web.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TiendaRopaOnline.DataAccess.DataContext;
using Microsoft.EntityFrameworkCore;
using TiendaRopaOnline.Models;
using System.Drawing;

namespace TiendaRopaOnline.Web.Tests
{
    [TestClass]
    public class ProductControllerTests
    {
        private async Task<TiendaOnlineContext> GetDbContext() {

            var options = new DbContextOptionsBuilder<TiendaOnlineContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            var context = new TiendaOnlineContext(options);
            context.Database.EnsureCreated();

            if (await context.Products.CountAsync() < 0) {
                for (int i = 0; i < 10; i++) {
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
        public void TestMethod1()
        {
            int id = 1;

            var test = new ProductController();
        }
    }
}