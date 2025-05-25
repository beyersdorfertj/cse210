// class to read/write serializeable objects to a file
using System.Text.Json;
using System.Text.Json.Serialization;

class Serialize {
    public static void Write<T>(T dataObject, string filePath) {
        File.WriteAllText(filePath, JsonSerializer.Serialize(dataObject)); 
    }

    public static T Read<T>(string filePath) {
        return JsonSerializer.Deserialize<T>(File.ReadAllText(filePath));
    }
}