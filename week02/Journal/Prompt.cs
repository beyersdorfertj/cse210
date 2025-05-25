class Prompt {
    private static List<string> _prompts = null;
    private static string _filePath = "prompts.json";

    private static List<string> GetList() {
        if (_prompts == null) {
            if (File.Exists(_filePath)) {
                _prompts = Serialize.Read<List<string>>(_filePath);
                if (_prompts.Count == 0) {
                    Init();
                }
            } else {
                Init();
            };
        }
        return _prompts;
    }

    private static void Init() {
        _prompts = new List<string> {
            "Who was the most interesting person I interacted with today?",
            "What was the best part of my day?",
            "How did I see the hand of the Lord in my life today?",
            "What was the strongest emotion I felt today?",
            "If I had one thing I could do over today, what would it be?"
        };
    }

    public static string GetRandom() {
        // select a random prompt from the list
        GetList();
        Random random = new Random();
        return Prompt._prompts[random.Next(Prompt._prompts.Count)];
    }

    public static void Add(string prompt) {
        if (string.IsNullOrWhiteSpace(prompt)) {
            Console.WriteLine("Prompt cannot be empty.");
            return;
        }
        GetList().Add(prompt);
        Serialize.Write(_prompts, _filePath);
    }

    public static void Remove(int promptId) {
        if (GetList().Count > promptId && promptId >= 0) {
            _prompts.RemoveAt(promptId);
            Serialize.Write(_prompts, _filePath);
        }
        if (_prompts.Count == 0) {
            Console.WriteLine("No prompts left. Reinitializing default prompts.");
            Init();
        }
    }

    public static void Display() {
        Console.WriteLine("\nAvailable Prompts:");
        GetList();
        for (int i = 0; i < _prompts.Count; i++) {
            Console.WriteLine($"{i+1}: {_prompts[i]}");
        }
    }

    public static int CountEntries() {
        GetList();
        return _prompts.Count;
    }
}