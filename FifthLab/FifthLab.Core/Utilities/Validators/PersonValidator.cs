using System.Text.RegularExpressions;
using FifthLab.Core.Interfaces;

namespace FifthLab.Core.Utilities.Validators;

public static class PersonValidator
{
    public static bool ValidateName(string name)
    {
        if (string.IsNullOrEmpty(name))
        {
            return false;
        }

        var regex = new Regex(@"^[A-Za-zА-Яа-я\s\-]+$");
        return regex.IsMatch(name);
    }

    public static bool ValidateExtraSkill(string skill)
    {
        if (string.IsNullOrEmpty(skill))
        {
            return false;
        }

        var regex = new Regex(@"^[A-Za-zА-Яа-я\s\-]+$");
        return regex.IsMatch(skill);
    }

    public static bool ValidatePerson(IPerson person)
    {
        return ValidateName(person.FirstName) && ValidateName(person.LastName) && ValidateExtraSkill(person.ExtraSkill);
    }
}
