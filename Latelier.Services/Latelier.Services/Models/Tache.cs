using Latelier.Services.Models.Enums;
using System.Runtime.CompilerServices;

namespace Latelier.Services.Models
{
    public class Tache
    {
        /// <summary>
        /// Identifiant de la tache
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Durée estimée de la tache (en minutes)
        /// </summary>
        public int Duree { get; set; }

        /// <summary>
        /// description de la tache
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Prix de base
        /// </summary>
        public int Prix { get; set; }

        /// <summary>
        /// Prix calculé en fonction de la tâche à réaliser et du type de facturation
        /// </summary>
        /// <remarks>Inclu le prix des pièces si nécessaire</remarks>
        public int PrixCalcule
        {
            get
            {
                if (FacturationType == FacturationTypeEnum.Forfait)
                    return Prix;

                var prix = Prix * Duree;
                if (Pieces?.Any() ?? false)
                {
                    prix += Pieces.Select(p => p.Prix).Sum();
                }
                return prix;
            }
        }

        /// <summary>
        /// type de facturation
        /// </summary>
        public FacturationTypeEnum FacturationType { get; set; }

        /// <summary>
        /// Liste des pièces à changer si nécessaire
        /// </summary>
        public List<Piece> Pieces { get; set; }

        public Tache(int id, int duree, string description, int prix, FacturationTypeEnum facturationType)
        {
            Id = id;
            Duree = duree;
            Description = description ?? throw new ArgumentNullException(nameof(description));
            Prix = prix;
            FacturationType = facturationType;
            Pieces = new List<Piece>();
        }

        /// <summary>
        /// Permet d'ajouter une ou plusieurs pièces à la tache
        /// </summary>
        /// <param name="pieces"></param>
        /// <returns></returns>
        public Tache WithPieces(params Piece[] pieces)
        {
            if (!Pieces?.Any() ?? true)
                Pieces = new List<Piece>();
            Pieces.AddRange(pieces);
            return this;
        }
    }
}
