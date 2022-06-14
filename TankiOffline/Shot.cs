using TankiOffline.Tanks;

namespace TankiOffline;
public class Shot
{
    public ShotType Type { get; }
    public Int32 Damage { get; }
    public Tank TankDirection { get; }
    public Shot(ShotType type, Int32 damage, Tank tankDirection)
    {
        Type = type;
        Damage = damage;
        TankDirection = tankDirection;
    }
    public void Apply()
    {
        if (!TankDirection.IsAlive) return;

        if (Type == ShotType.Heal)
            TankDirection.TakeHeal(Damage);
        else
            TankDirection.TakeDamage(Damage);
    }
    public void ConsoleWriteDamage()
    {
        Console.ForegroundColor = ConsoleColor.White;

        String isTankAlive = TankDirection.IsAlive ? $". Оставшееся здоровье: {TankDirection.Health}" : " - Мертв";
        if (Type != ShotType.Heal)
            Console.WriteLine($"\nТанк {TankDirection.Id} получил урон в размере {Damage}{isTankAlive}");
        else
            Console.WriteLine($"\nТанк {TankDirection.Id} получил хилку в размере {Damage}{isTankAlive}");
    }

}
public enum ShotType
{
    Attack = 1,
    Heal = 2
}