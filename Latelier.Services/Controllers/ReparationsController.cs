using Latelier.Services.Models;
using Latelier.Services.Requests;
using Latelier.Services.Services;
using Microsoft.AspNetCore.Mvc;

namespace Latelier.Services.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ReparationsController : ControllerBase
    {
        #region Réparations API

        [HttpGet]
        public ActionResult<List<Reparation>> Reparations()
            => DataServices.GetAll();

        /// <summary>
        /// recherche d'une réparation
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("Search/{id}")]
        public ActionResult<Reparation> SearchReparationById(int id)
        {
            var rep = DataServices.Get(id);
            if (rep == null)
                return NotFound();

            return rep;
        }

        [HttpPost("SearchReparations")]
        public ActionResult<List<Reparation>> SearchReparations(SearchReparationsRequest request)
            => DataServices.SearchReparations(request);

        /// <summary>
        /// sauvegarde d'une réparation
        /// </summary>
        /// <param name="reparation"></param>
        /// <returns></returns>
        [HttpPost("Add")]
        public IActionResult SaveReparation(Reparation reparation)
        {
            // ici par exemple on peut valider que les donnés envoyées sont correctes
            if (!ValidateDatas(reparation))
                return BadRequest();

            // NB : on peut imaginer d'autres vérifications comme par exemple
            //  - que la tache et le matériel correspondent
            //  - que les pièces à changer correspondent au matériel
            // etc...
            // évidement cela n'empêche pas de faire des choses côté consommateur pour s'assurer d'avoir des données correctes ici

            var tache = DataServices.GetTache(reparation.TacheId);
            reparation.Prix = tache?.PrixCalcule;

            // sauvegarde
            DataServices.Add(reparation);
            return CreatedAtAction(nameof(SaveReparation), new { id = reparation.Id }, reparation);
        }

        /// <summary>
        /// Mise à jour d'une réparation
        /// </summary>
        /// <param name="id"></param>
        /// <param name="reparation"></param>
        /// <returns></returns>
        [HttpPut("Update/{id}")]
        public IActionResult UpdateReparation(int id, Reparation reparation)
        {
            if (id != reparation.Id || !ValidateDatas(reparation))
                return BadRequest();

            var existingRep = DataServices.Get(id);
            if (existingRep is null)
                return NotFound();

            DataServices.Update(reparation);
            return NoContent();
        }

        /// <summary>
        /// Validation des données
        /// </summary>
        /// <param name="reparation"></param>
        /// <returns></returns>
        private static bool ValidateDatas(Reparation reparation)
        {
            var materiel = DataServices.GetMateriel(reparation.NumSerieMateriel);
            var tache = DataServices.GetTache(reparation.TacheId);
            var client = DataServices.GetClient(reparation.ClientId);

            return materiel != null && tache != null && client != null;
        }

        #endregion
    }
}
