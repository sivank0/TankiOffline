using TankiOffline.Equipments;

public interface Equipment
{
    public EquipmentType Type { get; }
}

public abstract class Armor : Equipment
{
    public Int32 Defend { get; }
    public EquipmentType Type { get; }

    public Armor(Int32 defend, EquipmentType type)
    {
        Defend = defend;
        Type = type;
    }
    public Armor? FilterArmor(Armor[] armors, Int32 damage) //Фильтрация армора
    {
        Armor maxDefendValue = armors[0];

        foreach (Armor armor in armors)
            if (maxDefendValue.Defend < armor.Defend && armor.Defend <= damage)
                maxDefendValue = armor;

        return maxDefendValue;
    }
}
public abstract class Gun : Equipment
{
    public Int32 Attack { get; }
    public EquipmentType Type { get; }
    public Gun(Int32 attack, EquipmentType type)
    {
        Attack = attack;
        Type = type;
    }
}