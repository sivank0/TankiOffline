using System.ComponentModel.DataAnnotations;

namespace TankiOffline.Equipments;
public enum EquipmentType
{
    [Display(Name = "Пушка 152 калибра")]
    Caliber152 = 1,
    [Display(Name = "Пушка 85 калибра")]
    Caliber85 = 2,
    [Display(Name = "Пушка 70 калибра")]
    Caliber70 = 3,
    [Display(Name = "Тяжелая броня")]
    HeavyShild = 4,
    [Display(Name = "Средняя броня")]
    MediumShild = 5,
    [Display(Name = "Легкая броня")]
    LightShild = 6
}
