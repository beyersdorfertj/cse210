
class LdsScriptures {
    private static List<Scripture> _scriptures = null;

    private LdsScriptures() {}

    public static Scripture GetRandomScripture(int numberVerses) {	
        if (_scriptures == null) {
            LoadScriptures();
        }
        Scripture scripture = null;
        int scriptureId = new Random().Next(_scriptures.Count);
        while (numberVerses-- > 0) {
            if (scripture == null) {
                scripture = _scriptures[scriptureId++];
            } else {
                scripture.Append(_scriptures[scriptureId++]);
            }
        }
        return scripture;
    }

    private static void LoadScriptures() {
        _scriptures = new List<Scripture>();
        string filePath = "lds_scriptures.csv";
        if (!File.Exists(filePath)) {
            throw new FileNotFoundException("File lds_scriptures.csv not found.");
        }

        // read the CSV file and split fields using '|' as the delimiter
        StreamReader reader = new StreamReader(filePath);
        reader.ReadLine();  // Skip the header line
        while (!reader.EndOfStream) {
            string line = reader.ReadLine();
            if (string.IsNullOrWhiteSpace(line)) continue; // Skip empty lines
            string[] parts = line.Split('|');
            if (parts.Length < 4) {
                continue; // Skip lines with insufficient data
            }
            Reference reference = new Reference(parts[0].Trim(), int.Parse(parts[1].Trim()), int.Parse(parts[2].Trim()));
            _scriptures.Add(new Scripture(reference, parts[3].Trim()));
        }
        reader.Close();
    }
}
