// don't hide punctuation marks as long as not all words are hidden
// use a list of scriptures from csv file
// resart the scripture after all words are hidden as long as the user does not type "quit"

class Program {
    static void Main(string[] args) {
        string input = "";
        do {
            Scripture scr = LdsScriptures.GetRandomScripture(new Random().Next(1, 4));
            bool isHiddenBefore = false;
            while (input.ToLower() != "quit" && !isHiddenBefore) {
                Console.Clear();
                Console.WriteLine(scr.GetDisplay());
                Console.Write("\nPress Enter to continue or type 'quit' to finish: ");
                input = Console.ReadLine();

                isHiddenBefore = scr.IsCompletelyHidden();
                if (input.ToLower() != "quit") {
                    scr.HideRandomWords(new Random().Next(1, 4)); // Hide 1 to 3 random words
                }
            }
        } while (input.ToLower() != "quit");
    }
}