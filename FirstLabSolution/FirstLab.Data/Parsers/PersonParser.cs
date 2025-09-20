using FirstLab.Core.Interfaces;
using FirstLab.Core.Entities;
using System.Text.RegularExpressions;

namespace FirstLab.Data.Parsers;

public class PersonParser : IPersonParser
{
    public IPerson ParseLine(string line)
    {
        try
        {
            if (string.IsNullOrWhiteSpace(line)) return null;

            line = line.Trim().TrimEnd(';');

            if (!line.Contains('{') || !line.Contains('}')) return null;

            int braceIndex = line.IndexOf('{');
            string header = line.Substring(0, braceIndex).Trim();
            string[] headerParts = header.Split(' ');

            if (headerParts.Length < 2) return null;

            string objectType = headerParts[0];
            string objectName = headerParts[1];

            int jsonStart = line.IndexOf('{') + 1;
            int jsonEnd = line.LastIndexOf('}');
            string jsonContent = line.Substring(jsonStart, jsonEnd - jsonStart).Trim();

            switch (objectType)
            {
                case "Student":
                    return ParseStudent(objectName, jsonContent); break;
                case "TaxiDriver":
                    return ParseTaxiDriver(objectName, jsonContent); break;
                case "Acrobat":
                    return ParseAcrobat(objectName, jsonContent); break;
                default:
                    return null;
            }
        }
        catch
        {
            return null;
        }
    }

    private Student ParseStudent(string objectName, string jsonContent)
    {
        var student = new Student
        {
            ObjectType = "Student",
            ObjectName = objectName,
            FirstName = GetJsonValue(jsonContent, "FirstName"),
            LastName = GetJsonValue(jsonContent, "LastName"),
            Age = GetJsonIntValue(jsonContent, "Age"),
            Course = GetJsonIntValue(jsonContent, "Course"),
            StudentId = GetJsonValue(jsonContent, "StudentId"),
            City = GetJsonValue(jsonContent, "City"),
            PassportId = GetJsonValue(jsonContent, "PassportId")
        };

        return student;
    }

    private TaxiDriver ParseTaxiDriver(string objectName, string jsonContent)
    {
        return new TaxiDriver
        {
            ObjectType = "TaxiDriver",
            ObjectName = objectName,
            FirstName = GetJsonValue(jsonContent, "FirstName"),
            LastName = GetJsonValue(jsonContent, "LastName"),
            Age = GetJsonIntValue(jsonContent, "Age")
        };
    }

    private Acrobat ParseAcrobat(string objectName, string jsonContent)
    {
        return new Acrobat
        {
            ObjectType = "Acrobat",
            ObjectName = objectName,
            FirstName = GetJsonValue(jsonContent, "FirstName"),
            LastName = GetJsonValue(jsonContent, "LastName"),
            Age = GetJsonIntValue(jsonContent, "Age")
        };
    }

    private string GetJsonValue(string jsonContent, string key)
    {
        try
        {
            var pattern = $"\"{key}\":\\s*\"([^\"]+)\"";
            var match = Regex.Match(jsonContent, pattern);
            return match.Success ? match.Groups[1].Value : "";
        }
        catch
        {
            return "";
        }
    }

    private int GetJsonIntValue(string jsonContent, string key)
    {
        try
        {
            string value = GetJsonValue(jsonContent, key);
            return int.TryParse(value, out int result) ? result : 0;
        }
        catch
        {
            return 0;
        }
    }

    public string ConvertToLine(IPerson person)
    {
        if (person is Student student)
        {
            return $"Student {student.ObjectName} {{ " +
                   $"\"FirstName\": \"{student.FirstName}\", " +
                   $"\"LastName\": \"{student.LastName}\", " +
                   $"\"Age\": \"{student.Age}\", " +
                   $"\"Course\": \"{student.Course}\", " +
                   $"\"StudentId\": \"{student.StudentId}\", " +
                   $"\"City\": \"{student.City}\", " +
                   $"\"PassportId\": \"{student.PassportId}\" }};";
        }

        if (person is TaxiDriver driver)
        {
            return $"TaxiDriver {driver.ObjectName} {{ " +
                   $"\"FirstName\": \"{driver.FirstName}\", " +
                   $"\"LastName\": \"{driver.LastName}\", " +
                   $"\"Age\": \"{driver.Age}\" }};";
        }

        if (person is Acrobat acrobat)
        {
            return $"Acrobat {acrobat.ObjectName} {{ " +
                   $"\"FirstName\": \"{acrobat.FirstName}\", " +
                   $"\"LastName\": \"{acrobat.LastName}\", " +
                   $"\"Age\": \"{acrobat.Age}\" }};";
        }

        return "";
    }
}