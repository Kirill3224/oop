using System.Text.RegularExpressions;
using SecondPartSolution.PersonEntites.Interfaces;

namespace SecondPartSolution.StudentBusinessLogic.Validators;

public static class PersonValidator
{
    public static bool VlidateObjType(string ObjectType)
    {
        string[] validTypes = { "Student", "Acrobat", "TaxiDriver" };
        return validTypes.Contains(ObjectType);
    }

    public static bool ValidateObjName(string objName)
    {
        if (string.IsNullOrEmpty(objName))
        {
            return false;
        }

        var regex = new Regex(@"^[A-Za-zА-Яа-яҐґЄєІіЇї\s\-]+$");
        return regex.IsMatch(objName);
    }

    public static bool ValidateName(string name)
    {
        if (string.IsNullOrEmpty(name))
        {
            return false;
        }

        var regex = new Regex(@"^[A-Za-zА-Яа-яҐґЄєІіЇї\s\-]+$");
        return regex.IsMatch(name);
    }

    public static bool ValidateAge(int age)
    {
        return age >= 16 && age <= 100;
    }

    public static bool ValidateExtraSkill(string skill)
    {
        if (string.IsNullOrEmpty(skill))
        {
            return false;
        }

        var regex = new Regex(@"^[A-Za-zА-Яа-яҐґЄєІіЇї\s\-]+$");
        return regex.IsMatch(skill);
    }

    public static bool ValidatePerson(IPerson person)
    {
        return VlidateObjType(person.ObjectType) && ValidateObjName(person.ObjectName) && ValidateName(person.FirstName) && ValidateName(person.LastName) && ValidateAge(person.Age) && ValidateExtraSkill(person.ExtraSkill);
    }
}