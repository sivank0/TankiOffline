namespace TankiOffline.Tanks;
public class LightTank : Tank
{
    public LightTank(Int32 id) : base(id, TankType.LightTank, 40, new Tactics.RandomTargeting()) { }
}
