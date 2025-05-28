class Scripture {
    private Reference _reference;
    private List<Word> _words;

    public Scripture(Reference reference, string text) {
        _reference = reference;
        _words = new List<Word>();
        foreach (var word in text.Split(' ')) {
            _words.Add(new Word(word));
        }
    }

    public void HideRandomWords(int numberToHide) {
        int count = 0;
        List<Word> unhiddenWords = _words.Where(w => !w.IsHidden()).ToList();
        if (unhiddenWords.Count < numberToHide) {
            numberToHide = unhiddenWords.Count; // Adjust if not enough words to hide
        }
        while (count < numberToHide) {
            int index = new Random().Next(unhiddenWords.Count);
            unhiddenWords[index].Hide();
            count++;
        }
    }

    public string GetDisplay() {
        string displayText = _reference.GetDisplayReference() + " ";
        foreach (var word in _words) {
            displayText += word.GetDisplayText(IsCompletelyHidden()) + " ";
        }
        return displayText;
    }

    public Reference GetReference() {
        return _reference;
    }

    public bool IsCompletelyHidden() {
        return _words.All(w => w.IsHidden());
    }

    public void Append(Scripture other) {
        Console.WriteLine($"Appending scripture: {other.GetReference().GetDisplayReference()} to {_reference.GetDisplayReference()}");
        if (other.GetReference().GetBook() == _reference.GetBook() && other.GetReference().GetChapter() == _reference.GetChapter()) {
            _words.AddRange(other._words);
            _reference.IncEndVerse();
        }
    }
}