using System;
using System.Text.Json;

class Program {
    static void Main(string[] args) {
        List<Video> videoList = new List<Video>();

        string json = @"{'videos': [{
                'title': 'How to Cook Spaghetti Properly', 'author': 'KochweltTV', 'lengthSeconds': 540, 'comments': [
                    { 'name': 'AnnaM', 'text': 'That was very well explained, thanks!' },
                    { 'name': 'Tim92', 'text': 'Finally I know why my pasta was always soggy 😅' },
                    { 'name': 'NoodleFan', 'text': 'I think 8 minutes is the perfect time.' },
                    { 'name': 'LucaChef', 'text': 'More like this please – maybe with sauce next time?' }
                ]
            },
            {
                'title': 'Top 5 JavaScript Tips for Beginners',
                'author': 'DevGuru',
                'lengthSeconds': 600,
                'comments': [
                    { 'name': 'CodeMaster', 'text': 'Great tips, especially the one about closures!' },
                    { 'name': 'WebDevJane', 'text': 'I wish I had known these when I started!' },
                    { 'name': 'JSNinja', 'text': 'Very helpful, thanks!' },
                    { 'name': 'TechieTom', 'text': 'Can you do a video on ES6 features next?' }
                ]
            },
            {
                'title': 'Python Basics – A Quick Overview',
                'author': 'CodeAcademy',
                'lengthSeconds': 720,
                'comments': [
                    { 'name': 'PyLover', 'text': 'This is a great start for beginners!' },
                    { 'name': 'DataDude', 'text': 'I love the examples you used!' },
                    { 'name': 'ScriptMaster', 'text': 'Can you do a video on Python libraries next?' },
                    { 'name': 'CodeNinja', 'text': 'Very informative, thanks!' }
                ]
            },
            {
                'title': 'C# for Beginners – An Introduction',
                'author': 'CodeCampus',
                'lengthSeconds': 890,
                'comments': [
                    { 'name': 'CodeNewbie', 'text': 'Great intro, this really helped me!' },
                    { 'name': 'MartaTech', 'text': 'The class example was really helpful!' },
                    { 'name': 'devMax', 'text': 'A bit fast, but great content!' },
                    { 'name': 'Sven_H', 'text': 'When is the next part coming?' }
                ]
            },
            {
                'title': 'The Art of French Cooking',
                'author': 'CulinaryArts',
                'lengthSeconds': 780,
                'comments': [
                    { 'name': 'ChefMarie', 'text': 'This recipe is a classic! 🍽️' },
                    { 'name': 'FoodieFan', 'text': 'I love the tips on seasoning!' },
                    { 'name': 'GourmetGuy', 'text': 'Can not wait to try this at home!' },
                    { 'name': 'BakerBella', 'text': 'More cooking videos, please!' }
                ]
            },
            {
                'title': '10 Cat Facts You Did not Know',
                'author': 'AnimalFacts',
                'lengthSeconds': 420,
                'comments': [
                    { 'name': 'CatLover123', 'text': 'Fact 7 totally surprised me 😺' },
                    { 'name': 'Lilly88', 'text': 'I love animal videos like this!' },
                    { 'name': 'OlliPets', 'text': 'Great narration and lovely visuals!' },
                    { 'name': 'MimiMew', 'text': 'Please make more cat content!' }
                ]
            }
        ]}";

        // Replace single quotes with double quotes for valid JSON
        json = json.Replace("'", "\"");
        using JsonDocument doc = JsonDocument.Parse(json);
        JsonElement root = doc.RootElement;
        JsonElement videos = root.GetProperty("videos");
        foreach (JsonElement video in videos.EnumerateArray()) {
            Video v = new Video(
                video.GetProperty("title").GetString(),
                video.GetProperty("author").GetString(),
                video.GetProperty("lengthSeconds").GetInt32()
            );

            foreach (JsonElement comment in video.GetProperty("comments").EnumerateArray()) {
                Comment c = new Comment(
                    comment.GetProperty("name").GetString(),
                    comment.GetProperty("text").GetString()
                );
                v.AddComment(c);
            }
            videoList.Add(v);
        }

        Console.WriteLine("Hello World! This is the YouTubeVideos Project.");
        foreach (Video v in videoList) {
            Console.WriteLine($"\nTitle: {v.GetTitle()}");
            Console.WriteLine($"Author: {v.GetAuthor()}");
            Console.WriteLine($"Length: {v.GetLength()} seconds");
            Console.WriteLine($"Comments ({v.GetCommentCount()}):");
            foreach (Comment c in v.GetComments()) {
                Console.WriteLine($" - {c.GetName()}: {c.GetText()}");
            }
        }
    }
}