namespace Latelier.Services.Models
{
    /// <summary>
    /// Représente un client
    /// </summary>
    public class Client
    {
        /// <summary>
        /// id du client
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// nom du client
        /// </summary>
        public string Nom { get; set; }

        /// <summary>
        /// prenom du client
        /// </summary>
        public string Prenom { get; set; }

        /// <summary>
        /// email du client
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// telephone du client (optionnel)
        /// </summary>
        public string Telephone { get; set; }

        public Client(int id, string prenom, string nom, string email, string telephone)
        {
            Id = id; Nom = prenom; Prenom = nom; Email = email; Telephone = telephone;
        }
    }
}
