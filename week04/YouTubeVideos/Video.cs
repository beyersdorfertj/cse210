class Video {
    private string _title;
    private string _author;
    private int _length;  // in seconds
    private List<Comment> _comments = new List<Comment>();

    public Video(string title, string author, int length) {
        _title = title;
        _author = author;
        _length = length;
    }

    public string GetTitle() {
        return _title;
    }

    public string GetAuthor() {
        return _author;
    }

    public int GetLength() {
        return _length;
    }

    public int GetCommentCount() {
        return _comments.Count;
    }

    public void AddComment(Comment comment) {
        _comments.Add(comment);
    }

    public List<Comment> GetComments() {
        return _comments;
    }
}