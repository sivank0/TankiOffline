using TankiOffline.Tanks;

namespace TankiOffline.Tactics;
public interface Tactic
{
    public Tank? GetTarget(Team teamates, Team enemis);
}
