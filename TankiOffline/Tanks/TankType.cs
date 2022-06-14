using System.ComponentModel.DataAnnotations;

namespace TankiOffline.Tanks;
public enum TankType
{
    [Display(Name = "Тяжелый танк")]
    HeavyTank = 1,
    [Display(Name = "Средний танк")]
    MediumTank = 2,
    [Display(Name = "Легкий танк")]
    LightTank = 3,
    [Display(Name = "Лечащий танк")]
    TankHealer = 4
}
