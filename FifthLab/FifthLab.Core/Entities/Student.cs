using FifthLab.Core.Interfaces;

namespace FifthLab.Core.Entities;

public class Student : IPerson, IStudy
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string ExtraSkill { get; set; } = string.Empty;
    public int Course { get; set; }
    public string StudentId { get; set; } = string.Empty;
    public string ArrivalCity { get; set; } = string.Empty;
    public string PassportId { get; set; } = string.Empty;

    public void Study()
    {
        ExtraSkill = "Навчається";
    }

}