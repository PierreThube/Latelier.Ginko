using Latelier.Services.Controllers;
using Latelier.Services.Services;

namespace Latelier.Services.Tests
{
    [TestClass]
    public class ReparationsControllerTests
    {
        private int ReparationId = 0;

        public ReparationsControllerTests()
        {
            Console.WriteLine($"Machine name = {Environment.MachineName}");
            ReparationId = Environment.MachineName switch
            {
                "PIERRE-PC" => 1,
                _ => 0
            };
        }

        [TestMethod]
        public void SearchReparationById_ShouldFind()
        {
            var reparation = DataServices.Get(ReparationId);
            if (reparation == null)
                Assert.Inconclusive($"Aucune réparation pour l'id : {ReparationId}");

            var services = new ReparationsController();
            var result = services.SearchReparationById(ReparationId);
            Assert.IsNotNull(result);
            Assert.AreEqual(result?.Value?.Id, ReparationId);
        }
    }
}