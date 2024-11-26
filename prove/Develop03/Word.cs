public class Word
{
    public string Text { get; private set; }
    public bool IsHidden { get; private set; }

    public Word(string text)
    {
        Text = text;
        IsHidden = false;
    }

    // Hide the word by replacing it with underscores
    public void Hide()
    {
        IsHidden = true;
    }

    // Display either the word or underscores
    public string GetDisplayText()
    {
        return IsHidden ? new string('_', Text.Length) : Text;
    }
}