class Journal {
    private static Journal _journal;
    private static string _filePath = "journal.json";
    public List<Entry> _entries;

    // Private constructor to make sure that the class cannot be created twice
    private Journal() {
        _entries = new List<Entry>();
    }
    
    public static Journal GetJournal() {
        if (_journal == null) {
            _journal = new Journal();
            if (File.Exists(_filePath)) {
                _journal._entries = Serialize.Read<List<Entry>>(_filePath);
            } else {
                Console.WriteLine("File not found, creating new journal.");
                _journal._entries = new List<Entry>();
            }
        }
        return _journal;
    }

    public void AddEntry(string prompt, string response) {
        if (string.IsNullOrWhiteSpace(prompt) || string.IsNullOrWhiteSpace(response)) {
            Console.WriteLine("Prompt and response cannot be empty.");
            return;
        }
        Entry entry = new Entry(DateTime.Now.ToString("dd/mm/yyyy"), prompt, response);
        _entries.Add(entry);
        Serialize.Write(_entries, _filePath);
    }

    public void Display() {
        if (_entries.Count == 0) {
            Console.WriteLine("No entries found.");
            return;
        }
        Console.WriteLine("\nJournal Entries:");
        foreach (var entry in _entries) {
            entry.Display();
            Console.WriteLine();
        }
    }

    public int CountEntries() {
        return _entries.Count;
    }
}