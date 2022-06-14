namespace TankiOffline.Tanks;
public class TankHealer : Tank
{
    public Int32 HealingDamage { get { return Utils.random.Next(Target!.MaxHealth); } }

    public TankHealer(Int32 id) : base(id, TankType.TankHealer, 40, new Tactics.HealTactic()) { }
}
