class Word {
    private string _text;
    private bool _isHidden;
    private string _preText = "";
    private string _postText = "";

    private static char[] _punctuationMarks = { '.', ',', '!', '?', ';', ':' };

    public Word(string text) {
        _text = text;
        _isHidden = false;
        // Check for punctuation at the start and end of the word
        if (_text.Length > 0 && _punctuationMarks.Contains(_text[0])) {
            _preText = _text[0].ToString();
            _text = _text.Substring(1);
        }
        if (_text.Length > 0 && _punctuationMarks.Contains(_text[_text.Length - 1])) {
            _postText = _text[_text.Length - 1].ToString();
            _text = _text.Substring(0, _text.Length - 1);
        }
        if (string.IsNullOrWhiteSpace(_text)) {
            _text = " "; // Ensure that empty words are represented as a space
        }
        _text = _text.Trim();
    }

    public void Hide() {
        _isHidden = true;
    }

    public void Show() {
        _isHidden = false;
    }

    public bool IsHidden() {
        return _isHidden;
    }

    public string GetDisplayText(bool hideEverything = false) {
      return HideOrNot(_preText, hideEverything) + HideOrNot(_text, _isHidden || hideEverything) + HideOrNot(_postText, hideEverything);
    }

    private string HideOrNot(string text, bool hide) {
        if (!hide) {
            return text;
        }
        return new string('_', text.Length);
    }
}