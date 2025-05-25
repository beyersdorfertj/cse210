public class Entry {
    // need public properties, set/get and parameterless constuctor for serialisation
    public string _date { get; set; }
    public string _prompt { get; set; }
    public string _response { get; set; }

    public Entry() {}

    public Entry(string date, string prompt, string response) {
        _date = date;
        _prompt = prompt;
        _response = response;
    }

    public void Display() {
        Console.WriteLine($"Date: {_date} - Prompt: {_prompt}");
        Console.WriteLine($"Response: {_response}");
    }
}