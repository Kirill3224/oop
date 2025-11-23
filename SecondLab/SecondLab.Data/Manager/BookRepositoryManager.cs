using SecondLab.Data.Repositories;
using SecondLab.Data.Initializations;

namespace SecondLab.Console.Manager;

public class BookRepositoryManager
{
    private readonly IBookRepository _listRepository;
    private readonly IBookRepository _arrayRepository;
    private IBookRepository _currentRepository;

    public BookRepositoryManager()
    {
        _listRepository = new BookListRepository();
        _arrayRepository = new BookArrayRepository(4);
        _currentRepository = _listRepository;

        InitializeListData.InitializeList(_listRepository);
        InitializeArrayData.InitializeArray(_arrayRepository);
    }

    public void SwitchToArrayRepository() => _currentRepository = _arrayRepository;
    public void SwitchToListRepository() => _currentRepository = _listRepository;
    public IBookRepository GetCurrentRepository() => _currentRepository;
    public string GetCurrentRepositoryType() => _currentRepository is BookArrayRepository ? "МАСИВ" : "СПИСОК";
}