using System.IO;

namespace FirstLab.Data.Services;

public class FileService : IFileService
{
    public string[] ReadAllLines(string filePath)
    {
        return File.ReadAllLines(filePath);
    }

    public void WriteAllLines(string filePath, string[] lines)
    {
        File.WriteAllLines(filePath, lines);
    }

    public bool FileExists(string filePath)
    {
        return File.Exists(filePath);
    }
}