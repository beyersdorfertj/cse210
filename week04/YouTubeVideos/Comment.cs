class Comment {
    public string _name { get; set; }
    public string _text { get; set; }

    public Comment(string name, string text) {
        _name = name;
        _text = text;
    }

    public override string ToString() {
        return $"{_name}: {_text}";
    }

    public string GetName() {
        return _name;
    }

    public string GetText() {
        return _text;
    }
}