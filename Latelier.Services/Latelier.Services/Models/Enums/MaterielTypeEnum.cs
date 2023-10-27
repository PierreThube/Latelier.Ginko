namespace Latelier.Services.Models.Enums
{
    public enum MaterielTypeEnum
    {
        Velo,
        Ski
    }

    public static class MaterielTypeEnumExtensions
    {
        public static int ToInt(this MaterielTypeEnum type)
        {
            return type switch
            {
                MaterielTypeEnum.Velo => 0,
                MaterielTypeEnum.Ski => 1,
                _ => throw new ArgumentException("Valeur non supportée"),
            };
        }
    }
}
