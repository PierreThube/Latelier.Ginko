using Latelier.Services.Models;

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

            Taches = new List<Tache>
            {
                new Tache(1, 15, "Affutage et fartage", 20, Models.Enums.FacturationTypeEnum.Forfait),
                new Tache(2, 0, "Réparation skis", 1, Models.Enums.FacturationTypeEnum.TempsPasse),
                new Tache(3, 45, "Révision annuelle", 50, Models.Enums.FacturationTypeEnum.Forfait),
                new Tache(4, 0, "Réparation vélo", 1, Models.Enums.FacturationTypeEnum.TempsPasse),
            };

            Materiels = new List<Materiel>
            {
                new Materiel("052413N4", Models.Enums.MaterielTypeEnum.Velo, 1),
                new Materiel("12F45HJ", Models.Enums.MaterielTypeEnum.Ski, 1),
                new Materiel("E6F4E3F5", Models.Enums.MaterielTypeEnum.Velo, 2),
                new Materiel("H9S34FG7", Models.Enums.MaterielTypeEnum.Ski, 2),
            };

            Reparations = new List<Reparation>
            {
                new Reparation(1, 1, 1, 1, DateTime.Now, null, null, "052413N4")
            };
        }

        public static List<Reparation> GetAll() => Reparations;

        public static Reparation? Get(int id) => Reparations.FirstOrDefault(p => p.Id == id);

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
