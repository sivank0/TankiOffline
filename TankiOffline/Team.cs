using TankiOffline.Tanks;

namespace TankiOffline;
public class Team
{
    public Int32 Id { get; private set; }

    public Tank[] Tanks = new Tank[5];
    public Armory Armory { get; }
    public Boolean IsAlive => Tanks.Where(tank => tank.IsAlive).Count() > 0;
    public ConsoleColor Color { get; }

    public Team(Int32 id, ConsoleColor color)
    {
        Id = id;
        Tanks = GetTanks();
        Armory = new Armory(Utils.random.Next(5, 15), Utils.random.Next(5, 15));
        Armory.EquipTeam(this);
        Color = color;
    }
    public Tank[] GetTanks()
    {
        Tank[] tanks = new Tank[Tanks.Length];
        Boolean isHaveHealer = false;
        for (Int32 i = 0; i < Tanks.Length; i++)
        {
            switch (Utils.random.Next(0, 4))
            {
                case 0:
                    tanks[i] = new LightTank(i + 1);
                    break;
                case 1:
                    tanks[i] = new MediumTank(i + 1);
                    break;
                case 2:
                    tanks[i] = new HeavyTank(i + 1);
                    break;
                case 3:
                    if (isHaveHealer) i--;
                    else
                    {
                        tanks[i] = new TankHealer(i + 1);
                        isHaveHealer = true;
                    }
                    break;
            }
        }
        return tanks;
    }
    public Tank[] GetAliveTanks() => Tanks.Where(tank => tank.IsAlive).ToArray();

    public void Target(Team team)
    {
        foreach (Tank tank in Tanks)
            if (tank.IsAlive)
                tank.Aim(this, team);
    }
    public void ClearTargets()
    {
        foreach (Tank tank in Tanks)
            tank.ClearTarget();
    }
    public Shot[] Hits() => Tanks.Select(t => t.Hit()).OfType<Shot>().ToArray();

    public void ConsoleWriteTeam() //Вывод команды на консоль
    {
        Console.ForegroundColor = Color;
        Console.WriteLine($"\nКоманда {Id}");
        foreach (Tank tank in Tanks)
        {
            if (!tank.IsAlive)
            {
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.WriteLine($"\n\nУничтожен");
            }
            else Console.ForegroundColor = Color;

            String equipInfo = tank.Equipments.Length > 0 ? String.Join(", ", tank.Equipments.Select(e => e.Type.GetDisplayName())) : "Пусто";

            Console.WriteLine(
                Utils.GetInfo(
                    $"\n\nТанк {tank.Id} - {tank.Type.GetDisplayName()}",
                    $"Здоровье: {tank.Health}",
                    $"Атака:  {tank.Gun?.Attack.ToString() ?? "Нет пушки"}",
                    $"Экипировка: {equipInfo}"
                    )
                );
        }
    }
}
