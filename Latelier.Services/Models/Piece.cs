using Latelier.Services.Models.Enums;

namespace Latelier.Services.Models
{
    /// <summary>
    /// représente une pièce à réparer/changer
    /// </summary>
    public class Piece
    {
        /// <summary>
        /// id
        /// </summary>
        public int Id { get; set; }
        
        /// <summary>
        /// Nom
        /// </summary>
        public string Name { get; set; }
                
        /// <summary>
        /// prix unitaire
        /// </summary>
        public int Prix { get; set; }

        /// <summary>
        /// type de matériel lié à la pièce
        /// </summary>
        public MaterielTypeEnum MaterielType { get; set; }

        public Piece(int id, string name, int prix, MaterielTypeEnum materielType)
        {
            Id = id;
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Prix = prix;
            MaterielType = materielType;
        }
    }
}
