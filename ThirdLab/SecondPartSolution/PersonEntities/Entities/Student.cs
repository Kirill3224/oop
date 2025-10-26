using SecondPartSolution.PersonEntites.Interfaces;

namespace SecondPartSolution.PersonEntities.Entities;

[Serializable]

public class Student : IPerson, IStudy
{
    public string ObjectType { get; set; }
    public string ObjectName { get; set; }
    public int Age { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int Course { get; set; }
    public string StudentId { get; set; }
    public string City { get; set; }
    public string PassportId { get; set; }
    public string ExtraSkill { get; set; }

    public void Study()
    {
        if (Course < 6)
        {
            Course++;
        }
    }
}
