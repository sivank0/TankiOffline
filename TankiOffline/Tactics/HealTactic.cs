using TankiOffline.Tanks;

namespace TankiOffline.Tactics;
public class HealTactic : Tactic
{
    public Tank? GetTarget(Team teamates, Team enemis)
    {
        Tank[] tanks = teamates.GetAliveTanks();

        Int32 randomTankIndex = Utils.random.Next(0, tanks.Length);

        if (tanks[randomTankIndex] is not null)
            return tanks[randomTankIndex];
        else return null;
    }
}
