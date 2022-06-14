using TankiOffline.Tanks;

namespace TankiOffline;
public class Armory
{
    public Equipment[] Equipments { get; private set; }
    public Gun[] Guns => Equipments.OfType<Gun>().ToArray();
    public Armor[] Armors => Equipments.OfType<Armor>().ToArray();

    public Equipment[] GetAttackEquipments(Int32 count)
    {
        List<Equipment> equipments = new List<Equipment>();

        for (Int32 i = 0; i < count; i++)
        {
            Int32 value = Utils.random.Next(1, 4);

            switch (value)
            {
                case 1:
                    equipments.Add(new Caliber152());
                    break;
                case 2:
                    equipments.Add(new Caliber85());
                    break;
                case 3:
                    equipments.Add(new Caliber70());
                    break;
            }
        }

        return equipments.ToArray();
    }
    public Equipment[] GetProtectiveEquipments(Int32 count)
    {
        List<Equipment> equipments = new List<Equipment>();

        for (Int32 i = 0; i < count; i++)
        {
            Int32 value = Utils.random.Next(1, 4);

            switch (value)
            {
                case 1:
                    equipments.Add(new HeavyShild());
                    break;
                case 2:
                    equipments.Add(new MediumShild());
                    break;
                case 3:
                    equipments.Add(new LightShild());
                    break;
            }
        }

        return equipments.ToArray();
    }

    public Armory(Int32 attackCount, Int32 protectiveCount)
    {
        List<Equipment> equipments = new List<Equipment>();

        equipments.AddRange(GetAttackEquipments(attackCount));
        equipments.AddRange(GetProtectiveEquipments(protectiveCount));

        Equipments = equipments.ToArray();
    }

    public void EquipTeam(Team team)
    {
        foreach (Tank tank in team.Tanks)
        {
            List<Equipment> tankEquipments = new List<Equipment>();

            if (tank is not TankHealer)
            {
                if (Guns.Length != 0)
                {
                    Int32 randomGunIndex = Utils.random.Next(0, Guns.Length);
                    tankEquipments.Add(Guns[randomGunIndex]);
                }
            }
            foreach (Armor armor in Armors.Take(Armors.Length / 5 > 0 ? Armors.Length / 5 : 1))
            {
                Int32 randomArmorIndex = Utils.random.Next(0, Armors.Length);
                tankEquipments.Add(Armors[randomArmorIndex]);
                Equipments = Equipments.Where(e => e != Armors[randomArmorIndex]).ToArray();
            }

            if (tankEquipments.Count == 0) return;

            tank.SetEquipment(tankEquipments.ToArray());


            Equipments = Equipments.Where(e => !tankEquipments.Contains(e)).ToArray();
        }
    }
}
