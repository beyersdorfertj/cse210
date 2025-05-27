class Reference {
    private string _book;
    private int _chapter;
    private int _verse;
    private int _endVerse;

    public Reference(string book, int chapter, int startVerse, int endVerse) {
        _book = book;
        _chapter = chapter;
        _verse = startVerse;
        _endVerse = endVerse;
    }

    public Reference(string book, int chapter, int verse) : this(book, chapter, verse, 0) {}

    public string GetBook() {
        return _book;
    }

    public int GetChapter() {
        return _chapter;
    }

    public int GetVerse() {
        return _verse;
    }

    public void IncEndVerse() {
        if (_endVerse == 0) {
            _endVerse = _verse; // Initialize endVerse to verse if not set
        }
        _endVerse++;
    }

    public string GetDisplayReference() {
        return $"{_book} {_chapter}:{_verse}" + (_endVerse > 0 ? $"-{_endVerse}" : "");
    }
}