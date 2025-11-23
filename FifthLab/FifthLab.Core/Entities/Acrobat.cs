using FifthLab.Core.Interfaces;

namespace FifthLab.Core.Entities;

public class Acrobat : IPerson, IDance
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string ExtraSkill { get; set; } = string.Empty;

    public void Dance()
    {
        ExtraSkill = "Танцює";
    }
}