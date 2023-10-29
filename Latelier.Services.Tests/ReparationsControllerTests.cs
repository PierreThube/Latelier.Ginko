using Latelier.Services.Controllers;
using Latelier.Services.Models;
using Latelier.Services.Requests;
using Latelier.Services.Services;
using Microsoft.AspNetCore.Mvc;

namespace Latelier.Services.Tests
{
    [TestClass]
    public class ReparationsControllerTests
    {
        private int ReparationId = 0;

        public ReparationsControllerTests()
        {
            Console.WriteLine($"Machine name = {Environment.MachineName}");

            // initialisation variable de test en fonction de la machine
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

        [TestMethod]
        public void SearchReparationById_ShouldNotFind()
        {
            var reparations = DataServices.GetAll();
            if (reparations == null || reparations.Count() == 0)
                Assert.Inconclusive($"Aucune réparations");

            // récupération d'un id qui n'existe pas
            var nextId = reparations.Select(r => r.Id).Max() + 1;

            // vérification qu'aucune réparation n'est trouvé
            var services = new ReparationsController();
            var result = services.SearchReparationById(nextId);
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result.Result, typeof(NotFoundResult));
        }

        [TestMethod]
        public void SaveReparation_ShouldBeOk()
        {
            var reparation = new Reparation(1, 1, 1, 1, DateTime.Now, null, "052413N4");

            var services = new ReparationsController();
            var result = services.SaveReparation(reparation);
            Assert.IsNotNull(((result as CreatedAtActionResult)?.Value as Reparation)?.Id != 0);
        }

        [TestMethod]
        public void SearchReparations()
        {
            var request = new SearchReparationsRequest().WithTechniciensIds(1);
            var services = new ReparationsController();
            var result = services.SearchReparations(request);
            Assert.IsNotNull(result?.Value);
            Assert.IsTrue(result.Value.All(r => r.TechnicienId == 1));
        }
    }
}