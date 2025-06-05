class MathAssignment : Assignment {
    private string _textbookSection;
    private string _problems;

    public MathAssignment(string studentName, string topic, string textbookSection, string problems) : base(studentName, topic) {
        this._textbookSection = textbookSection;
        this._problems = problems;
    }

    public string GetHomeworkList() {
        return $"Textbook Section {this._textbookSection} Problems {this._problems}";
    }
}
