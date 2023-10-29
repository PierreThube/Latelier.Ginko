using Latelier.Services.Extensions;

namespace Latelier.Services.Requests
{
    /// <summary>
    /// Classe de requete de recherche de réparations
    /// </summary>
    public class SearchReparationsRequest
    {
        /// <summary>
        /// identifiants de réparations
        /// </summary>
        public List<int>? Ids { get; set; }

        /// <summary>
        /// identifiants de clients
        /// </summary>
        public List<int>? ClientIds { get; set; }

        /// <summary>
        /// identifiants de taches
        /// </summary>
        public List<int>? TacheIds { get; set; }

        /// <summary>
        /// Identifiants de techniciens
        /// </summary>
        public List<int>? TechniciensIds { get; set; }

        /// <summary>
        /// champs texte pour support omnibox
        /// </summary>
        public string Omnibox { get; set; }

        public SearchReparationsRequest()
        {
            
        }

        /// <summary>
        /// permet d'ajouter des valeurs à <see cref="TechniciensIds"/>
        /// </summary>
        /// <param name="techIds"></param>
        /// <returns></returns>
        public SearchReparationsRequest WithTechniciensIds(params int[] techIds)
        {
            if (TechniciensIds.IsNullOrEmpty())
                TechniciensIds = new List<int>();

            TechniciensIds.AddRange(techIds);
            return this;
        }

        // idem pour les autres attributs...
    }
}
