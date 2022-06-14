using TankiOffline.Tactics;

namespace TankiOffline.Tanks;
public abstract class Tank
{
    public Int32 Id { get; private set; }
    public Tank? Target { get; private set; }
    public Int32 Health { get; private set; }
    public Int32 MaxHealth { get; private set; }
    public TankType Type { get; }

    public Boolean IsAlive => Health > 0;

    public Tactic Tactic { get; private set; }

    public Equipment[] Equipments { get; private set; }
    public Gun? Gun => (Gun?)Equipments.FirstOrDefault(e => e is Gun);
    public Armor[] Armor => Equipments.OfType<Armor>().ToArray();

    public Tank(Int32 id, TankType type, Int32 health, Tactic tactic)
    {
        Id = id;
        Type = type;
        Equipments = new Equipment[0] { };
        Health = health;
        MaxHealth = health;
        Tactic = tactic;
    }
    public void SetEquipment(Equipment[] equipments) => Equipments = equipments; //Поставить экипировку

    public void TakeDamage(Int32 damage) // получение дамага
    {
        Armor? defend = null;
        if (Armor.Length != 0)
            defend = Armor[0].FilterArmor(Armor, damage);

        if (defend is null)
        {
            Health = Math.Clamp(Health - damage, 0, Health);
            return;
        }

        Int32 calculateDamage = damage;

        calculateDamage -= defend.Defend;

        if (calculateDamage <= 0)
            Equipments = Equipments.Where(e => e != defend).ToArray();

        Health = Math.Clamp(Health + (defend.Defend - damage), 0, MaxHealth);
    }

    public void TakeHeal(Int32 heal) => Health = Math.Clamp(Health + heal, 0, MaxHealth); //получение хилки

    public Shot? Hit()
    {
        if (Target is null) return null;

        if (this is TankHealer tankHealer)
            return new Shot(ShotType.Heal, tankHealer.HealingDamage, Target);

        if (Gun is null) return null;

        return new Shot(ShotType.Attack, Gun.Attack, Target);
    }

    public void ClearTarget() => Target = null;

    public void Aim(Team teamates, Team enemis) => Target = Tactic.GetTarget(teamates, enemis); //Наведение на танк
}
