public class Reference
{
    public string Book { get; private set; }
    public int StartChapter { get; private set; }
    public int StartVerse { get; private set; }
    public int? EndChapter { get; private set; } // Nullable for single verses
    public int? EndVerse { get; private set; }

    // Constructor for single verse
    public Reference(string book, int chapter, int verse)
    {
        Book = book;
        StartChapter = chapter;
        StartVerse = verse;
    }

    // Constructor for verse range
    public Reference(string book, int startChapter, int startVerse, int endChapter, int endVerse)
    {
        Book = book;
        StartChapter = startChapter;
        StartVerse = startVerse;
        EndChapter = endChapter;
        EndVerse = endVerse;
    }

    public override string ToString()
    {
        if (EndChapter == null || EndVerse == null)
            return $"{Book} {StartChapter}:{StartVerse}";
        return $"{Book} {StartChapter}:{StartVerse}-{EndChapter}:{EndVerse}";
    }
}