using Latelier.Services.Models;
using Latelier.Services.Models.Enums;
using Latelier.Services.Requests;
using Latelier.Services.Extensions;
using Microsoft.VisualBasic;

namespace Latelier.Services.Services
{
    /// <summary>
    /// Classe static pour initialiser des données dans le cache au lancement de l'application
    /// </summary>
    public static class DataServices
    {
        static List<Technicien> Techniciens { get; }
        static List<Client> Clients { get; }
        static List<Tache> Taches { get; }
        static List<Materiel> Materiels { get; }

        static List<Reparation> Reparations { get; }
        static int nextId = 2;

        static DataServices()
        {
            // Ajout de données de tests
            // Attention les données ne sont pas forcement pertinentes et cohérentes
            // à remplacer par une base de données + tard

            Techniciens = new List<Technicien>
            {
                new Technicien(1, "Jean", "Valjean"),
                new Technicien(2, "Tech", "Nicien"),
                new Technicien(3, "Emma", "Nuelle"),
            };

            Clients = new List<Client>
            {
                new Client(1, "Alain", "Deloin", "alain.deloin@gmail.com", "06.64.32.42.00"),
                new Client(2, "Bob", "Lennon", "bob.lennon@gmail.com", "06.64.32.42.00")
            };

            var pieces = new[] {
                new Piece(2, "Plaquettes de frein", 50, MaterielTypeEnum.Velo),
                new Piece(3, "Pneu", 25, MaterielTypeEnum.Velo)
            };
            Taches = new List<Tache>
            {
                new Tache(1, 15, "Affutage et fartage", 20, FacturationTypeEnum.Forfait),
                new Tache(2, 0, "Réparation skis", 1, FacturationTypeEnum.TempsPasse)
                    .WithPieces(new Piece(1, "Fixations", 20, MaterielTypeEnum.Ski)),
                new Tache(3, 0, "Révision annuelle", 50, FacturationTypeEnum.Forfait),
                new Tache(4, 0, "Réparation vélo", 1, FacturationTypeEnum.TempsPasse)
                    .WithPieces(pieces)
            };

            Materiels = new List<Materiel>
            {
                new Materiel("052413N4", MaterielTypeEnum.Velo, 1),
                new Materiel("12F45HJ", MaterielTypeEnum.Ski, 1),
                new Materiel("E6F4E3F5", MaterielTypeEnum.Velo, 2),
                new Materiel("H9S34FG7", MaterielTypeEnum.Ski, 2),
            };

            Reparations = new List<Reparation>
            {
                new Reparation(1, 1, 1, 1, DateTime.Now, null, "052413N4"),
                new Reparation(2, 1, 1, 1, DateTime.Now, DateTime.Now.AddDays(1), "12F45HJ"),
                new Reparation(3, 2, 2, 1, DateTime.Now, DateTime.Now.AddDays(2), "E6F4E3F5"),
            };
        }

        public static List<Reparation> GetAll() => Reparations;

        public static List<Reparation> SearchReparations(SearchReparationsRequest request)
        {
            if (request == null)
                return new List<Reparation>();

            // si on filtre sur des identifiants, on retourne le resultat directement
            if (!request.Ids.IsNullOrEmpty())
                return Reparations.Where(r => request.Ids.Contains(r.Id)).ToList();

            // sinon on applique les autres filtres
            var reparations = Reparations.AsEnumerable();

            if (!request.TechniciensIds.IsNullOrEmpty())
                reparations = reparations.Where(r => request.TechniciensIds.Contains(r.TechnicienId));

            if (!string.IsNullOrWhiteSpace(request.Omnibox))
            {
                reparations = reparations.Where(r => r.NumSerieMateriel.ToUpper().Contains(request.Omnibox.ToUpper()));
                // dans un monde ou la classe/entité inclues les autres classes/entitées, continuer la recherche sur les autres champs texte...
            }

            // appliquer les autres filtres ...

            return reparations.ToList();
        }

        public static Reparation? Get(int id) => Reparations.FirstOrDefault(p => p.Id == id);

        public static Materiel? GetMateriel(string numSerie) => Materiels.FirstOrDefault(m => m.NumSerie == numSerie);

        public static Tache? GetTache(int id) => Taches.FirstOrDefault(m => m.Id == id);

        public static Client? GetClient(int id) => Clients.FirstOrDefault(c => c.Id == id);

        public static void Add(Reparation rep)
        {
            rep.Id = nextId++;
            Reparations.Add(rep);
        }

        public static void Delete(int id)
        {
            var pizza = Get(id);
            if (pizza is null)
                return;

            Reparations.Remove(pizza);
        }

        public static void Update(Reparation rep)
        {
            var index = Reparations.FindIndex(p => p.Id == rep.Id);
            if (index == -1)
                return;

            Reparations[index] = rep;
        }
    }
}
