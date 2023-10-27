namespace Latelier.Services.Models
{
    /// <summary>
    /// Représente un technicien
    /// </summary>
    public class Technicien
    {
        /// <summary>
        /// id du technicien
        /// </summary>
        public int Id { get; set; }
        
        /// <summary>
        /// nom du technicien
        /// </summary>
        public string Nom { get; set; }

        /// <summary>
        /// prenom du technicien
        /// </summary>
        public string Prenom { get; set; }

        public Technicien(int id, string nom, string prenom)
        {
            Id = id;
            Nom = nom ?? throw new ArgumentNullException(nameof(nom));
            Prenom = prenom ?? throw new ArgumentNullException(nameof(prenom));
        }
    }
}
