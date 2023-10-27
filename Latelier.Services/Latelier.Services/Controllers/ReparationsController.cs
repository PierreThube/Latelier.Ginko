using Latelier.Services.Models;
using Latelier.Services.Services;
using Microsoft.AspNetCore.Mvc;
using System.Xml;

namespace Latelier.Services.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ReparationsController : ControllerBase
    {
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

        /// <summary>
        /// sauvegarde d'une réparation
        /// </summary>
        /// <param name="reparation"></param>
        /// <returns></returns>
        [HttpPost("Add")]
        public IActionResult SaveReparation(Reparation reparation)
        {
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
            if (id != reparation.Id)
                return BadRequest();

            var existingRep = DataServices.Get(id);
            if (existingRep is null)
                return NotFound();

            DataServices.Update(reparation);
            return NoContent();
        }
    }
}
