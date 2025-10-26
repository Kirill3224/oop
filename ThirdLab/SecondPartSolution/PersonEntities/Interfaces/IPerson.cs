

namespace SecondPartSolution.PersonEntites.Interfaces;

public interface IPerson
{
    public string ObjectType { get; set; }
    public string ObjectName { get; set; }
    string FirstName { get; set; }
    string LastName { get; set; }
    int Age { get; set; }
    string ExtraSkill { get; set; }
}