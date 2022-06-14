namespace TankiOffline.Tanks;
public class HeavyTank : Tank
{
    public HeavyTank(Int32 id) : base(id, TankType.HeavyTank, 150, new Tactics.MaxHealthTargeting()) { }
}
