namespace Latelier.Services.Models
{
    /// <summary>
    /// Représente une réparation
    /// </summary>
    public class Reparation
    {
        /// <summary>
        /// id de la réparation
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Id du technicien
        /// </summary>
        public int TechnicienId { get; set; }
        
        /// <summary>
        /// Id du client
        /// </summary>
        public int ClientId { get; set; }
        
        /// <summary>
        /// Id du type de tache
        /// </summary>
        public int TacheId { get; set; }

        /// <summary>
        /// date/heure de début
        /// </summary>
        public DateTime DateDebut { get; set; }

        /// <summary>
        /// date/heure de fin
        /// </summary>
        public DateTime? DateFin { get; set; }

        /// <summary>
        /// Prix de la réparation
        /// </summary>
        public double? Prix { get; set; }

        /// <summary>
        /// numéro de série du matériel à réparer
        /// </summary>
        public string NumSerieMateriel { get; set; }

        public Reparation(int id, int technicienId, int clientId, int tacheId, DateTime dateDebut, DateTime? dateFin, double? prix, string numSerieMateriel)
        {
            Id = id;
            TechnicienId = technicienId;
            ClientId = clientId;
            TacheId = tacheId;
            DateDebut = dateDebut;
            DateFin = dateFin;
            Prix = prix;
            NumSerieMateriel = numSerieMateriel ?? throw new ArgumentNullException(nameof(numSerieMateriel));
        }
    }
}
