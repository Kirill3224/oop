using FifthLab.Core.Interfaces;

namespace FifthLab.Core.Entities;

public class TaxiDriver : IPerson, IDrive
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string ExtraSkill { get; set; } = string.Empty;

    public void Drive()
    {
        ExtraSkill = "Веде машину";
    }
}