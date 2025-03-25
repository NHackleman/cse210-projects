public class Reference
{
    private string book;
    private string chapter;
    private string verseStart;
    private string verseEnd;

    public Reference(string book, string chapter, string verse)
    {
        this.book = book;
        this.chapter = chapter;
        this.verseStart = verse;
        this.verseEnd = verse;
    }

    public Reference(string book, string chapter, string verseStart, string verseEnd)
    {
        this.book = book;
        this.chapter = chapter;
        this.verseStart = verseStart;
        this.verseEnd = verseEnd;
    }

    public override string ToString()
    {
        return verseStart == verseEnd ? $"{book} {chapter}:{verseStart}" : $"{book} {chapter}:{verseStart}-{verseEnd}";
    }
}