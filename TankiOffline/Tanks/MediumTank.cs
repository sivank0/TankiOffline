namespace TankiOffline.Tanks;
public class MediumTank : Tank
{
    public MediumTank(Int32 id) : base(id, TankType.MediumTank, 80, new Tactics.MinHealthTargeting()) { }
}
