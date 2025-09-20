using FirstLab.Core.Interfaces;
using FirstLab.Data.Parsers;
using FirstLab.Data.Services;

namespace FirstLab.Data.FileServices;

public class TextFileService
{
    private readonly string _filePath;
    private readonly IFileService _fileService;
    private readonly IPersonParser _personParser;

    public TextFileService(string filePath, IFileService fileService, IPersonParser personParser)
    {
        _filePath = filePath;
        _fileService = fileService;
        _personParser = personParser;
    }

    public IEnumerable<IPerson> ReadAllPersons()
    {
        if (!_fileService.FileExists(_filePath))
            return Enumerable.Empty<IPerson>();

        var lines = _fileService.ReadAllLines(_filePath);
        return lines.Select(_personParser.ParseLine).Where(p => p != null);
    }

    public void WriteAllPersons(IEnumerable<IPerson> persons)
    {
        var lines = persons.Select(_personParser.ConvertToLine);
        _fileService.WriteAllLines(_filePath, lines.ToArray());
    }

    public bool FileExists()
    {
        return _fileService.FileExists(_filePath);
    }
}