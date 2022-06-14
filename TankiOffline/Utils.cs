using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace TankiOffline;
public static class Utils
{
    public static Random random = new Random();

    public static String GetInfo(params String?[] texts)
    {
        return String.Join("\n", texts.Where(t => !String.IsNullOrWhiteSpace(t)));
    }
}
public static class EnumExtensions
{
    public static String GetDisplayName<T>(this T value) where T : Enum
    {
        return value.GetType().GetMember(value.ToString()).First().GetCustomAttribute<DisplayAttribute>()?.GetName() ?? String.Empty;
    }
}
// Приведение типов
//    Tank[] tanks = new Tank[0] { };

//    if (tanks[0] is TankHealer tankHealer)
//    {
//    }

//    if (tanks[0] is TankHealer)
//    {
//        TankHealer healer = (TankHealer)tanks[0];

//        TankHealer? healer1 = tanks[0] as TankHealer;
//    }

//    TankHealer[] healers = tanks.OfType<TankHealer>().ToArray();
