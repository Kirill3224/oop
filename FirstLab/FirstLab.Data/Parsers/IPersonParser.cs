using FirstLab.Core.Interfaces;

namespace FirstLab.Data.Parsers;

public interface IPersonParser
{
    IPerson ParseLine(string line);
    string ConvertToLine(IPerson person);
}
