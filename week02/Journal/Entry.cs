public class Entry
{
    private string _date;
    private string _promptText;
    private string _entryText;
    private int _emotionRating; // <-- new field to capture emotion rating

    public Entry(string date, string promptText, string entryText, int emotionRating)
    {
        _date = date;
        _promptText = promptText;
        _entryText = entryText;
        _emotionRating = emotionRating;
    }

    public void Display()
    {
        Console.WriteLine($"Date: {_date}");
        Console.WriteLine($"Prompt: {_promptText}");
        Console.WriteLine($"Entry: {_entryText}");
        Console.WriteLine($"Emotion Rating (1–10): {_emotionRating}\n"); // <-- new line for emotion rating
    }

    public string ToFileString()
    {
        return $"{_date}|{_promptText}|{_entryText}|{_emotionRating}"; // <-- updated to include emotion rating
    }

    public static Entry FromFileString(string line)
    {
        string[] parts = line.Split('|');
        if (parts.Length == 4)
        {
            return new Entry(parts[0], parts[1], parts[2], int.Parse(parts[3]));
        }
        return null;
    }
}
