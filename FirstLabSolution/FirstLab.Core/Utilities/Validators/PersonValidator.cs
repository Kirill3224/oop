using System.Text.RegularExpressions;
using FirstLab.Core.Interfaces;

namespace FirstLab.Core.Utilities.Validators
{
    public static class PersonValidator
    {
        public static bool ValidateObjType(string objType)
        {
            string[] validTypes = { "Student", "TaxiDriver", "Acrobat" };
            return validTypes.Contains(objType);
        }

        public static bool ValidateObjName(string objName)
        {
            if (string.IsNullOrEmpty(objName))
            {
                return false;
            }

            var regex = new Regex(@"^[A-Za-zА-Яа-я\s\-]+$");
            return regex.IsMatch(objName);
        }

        public static bool ValidateName(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                return false;
            }

            var regex = new Regex(@"^[A-Za-zА-Яа-я\s\-]+$");
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

            var regex = new Regex(@"^[A-Za-zА-Яа-я\s\-]+$");
            return regex.IsMatch(skill);
        }

        public static bool ValidatePerson(IPerson person)
        {
            return ValidateObjType(person.ObjectType) && ValidateObjName(person.ObjectName) && ValidateName(person.FirstName) && ValidateName(person.LastName) && ValidateAge(person.Age) && ValidateExtraSkill(person.ExtraSkill);
        }
    }
}