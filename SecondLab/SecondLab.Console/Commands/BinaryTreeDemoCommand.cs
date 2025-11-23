using SecondLab.Core.Item;
using SecondLab.Data.Sturctures;
using SecondLab.Data.Initializations;

namespace SecondLab.Console.Commands;

public class BinaryTreeDemoCommand : ICommand
{
    public CommandResult Execute()
    {
        try
        {
            var result = new System.Text.StringBuilder();
            result.AppendLine(new string('-', 30));
            result.AppendLine("-- БІНАРНЕ ДЕРЕВО - ЗВОРОТНИЙ ПОРЯДОК (POSTORDER) --");
            result.AppendLine("Порядок обходу: ЛІВИЙ -> ПРАВИЙ -> КОРІНЬ");
            result.AppendLine(new string('-', 30));

            result.AppendLine("\n 1. Дерево з порівнянням за назвою (IComparable<Book>):");
            var treeByName = new BinaryTree<Book>();
            InitializeTreeData.InitializeTree(treeByName);

            result.AppendLine("Книги в зворотньому порядку:");
            int counter = 1;
            foreach (var book in treeByName)
            {
                result.AppendLine($"   {counter++}. {book}");
            }
            result.AppendLine(new string(' ', 30));
            result.AppendLine(new string('-', 30));

            result.AppendLine("\n 2. Дерево з порівнянням за ціною:");
            var treeByPrice = new BinaryTree<Book>(new BinaryPriceComparer());
            InitializeTreeData.InitializeTree(treeByPrice);

            result.AppendLine("   Структура дерева (корінь - 'Кобзар' (220)):");
            result.AppendLine("        220 (Кобзар)");
            result.AppendLine("       /      \\");
            result.AppendLine("     100     330 (Так казав)");
            result.AppendLine("   (Темні)        \\");
            result.AppendLine("                 600 (Практика)");
            result.AppendLine("");
            result.AppendLine("   Зворотний порядок обходу (postorder):");
            int i = 1;
            foreach (var book in treeByPrice)
                result.AppendLine($"   {i++}. {book.Name}: {book.CostOfCopy} грн");

            result.AppendLine(new string(' ', 30));
            result.AppendLine(new string('-', 30));

            result.AppendLine("\n Пояснення зворотнього порядку (postorder):");
            result.AppendLine("   - Спочатку відвідуємо ЛІВЕ піддерево");
            result.AppendLine("   - Потім відвідуємо ПРАВЕ піддерево");
            result.AppendLine("   - В кінці відвідуємо КОРІНЬ \n");

            return new CommandResult
            {
                Success = true,
                Message = result.ToString()
            };
        }
        catch (Exception ex)
        {
            return new CommandResult
            {
                Success = false,
                Message = $"Сталася помилка: {ex.Message}"
            };
        }
    }

    public string Description => "Демонстрація бінарного дерева (зворотний порядок)";
}