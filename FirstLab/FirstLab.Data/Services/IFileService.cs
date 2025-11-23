namespace FirstLab.Data.Services
{
    public interface IFileService
    {
        string[] ReadAllLines(string filePath);
        void WriteAllLines(string filePath, string[] lines);
        bool FileExists(string filePath);
    }
}