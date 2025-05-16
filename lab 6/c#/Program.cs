using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

interface TextCleaner
{
    string cleanSpaces(string input);
    string trimText(string input);
}

public class TextLine : TextCleaner
{
    private string Content;

    public TextLine(string content)
    {
        Content = content;
    }

    public string cleanSpaces(string input)
    {
        return Regex.Replace(input, @"\s+", " ");
    }

    public string trimText(string input)
    {
        return input.Trim();
    }

    public void Clean()
    {
        Content = cleanSpaces(Content);
        Content = trimText(Content);
    }

    public override string ToString()
    {
        return Content;
    }
}

class TextContainer
{
    private List<TextLine> lines = new List<TextLine>();

    public void addLine(string content)
    {
        lines.Add(new TextLine(content));
    }

    public void removeLine(int index)
    {
        if (index >= 0 && index < lines.Count)
            lines.RemoveAt(index);
    }

    public void cleanAll()
    {
        foreach (var line in lines)
        {
            line.Clean();
        }
    }

    public void printAll()
    {
        foreach (var line in lines)
        {
            Console.WriteLine(line);
        }
    }
}
