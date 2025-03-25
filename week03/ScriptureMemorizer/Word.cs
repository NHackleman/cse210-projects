public class Word
{
    private string text;
    private bool isHidden;

    public Word(string text)
    {
        this.text = text;
        this.isHidden = false;
    }

    public void Hide()
    {
        isHidden = true;
    }

    public override string ToString()
    {
        return isHidden ? new string('_', text.Length) : text;
    }
}