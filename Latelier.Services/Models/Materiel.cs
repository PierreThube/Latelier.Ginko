using Latelier.Services.Models.Enums;

namespace Latelier.Services.Models
{
    /// <summary>
    /// Représente un matériel à réparer (vélo, ski, ...)
    /// </summary>
    public class Materiel
    {
        /// <summary>
        /// Numéro de série
        /// </summary>
        public string NumSerie { get; set; }

        /// <summary>
        /// Type de matériel (vélo, ski, ...)
        /// </summary>
        public MaterielTypeEnum MaterielType { get; set; }

        /// <summary>
        /// Type de matériel (vélo, ski, ...)
        /// </summary>
        /// <remarks>Valeur int, utile pour sauvegarde dans la base de données</remarks>
        public int Type => MaterielType.ToInt();

        /// <summary>
        /// Client auquel appartient le matériel
        /// </summary>
        public int ClientId { get; set; }

        public Materiel(string numSerie, MaterielTypeEnum type, int clientId)
        {
            NumSerie = numSerie ?? throw new ArgumentNullException(nameof(numSerie));
            MaterielType = type;
            ClientId = clientId;
        }
    }
}
