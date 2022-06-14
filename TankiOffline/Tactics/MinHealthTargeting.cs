using TankiOffline.Tanks;

namespace TankiOffline.Tactics;
internal class MinHealthTargeting : Tactic
{
    public Tank? GetTarget(Team teamates, Team enemis)
    {
        Tank[] tanks = enemis.GetAliveTanks();

        Tank? target = tanks.MinBy(tank => tank.Health);

        if (target is not null)
            return target;
        else return null;
    }
}
