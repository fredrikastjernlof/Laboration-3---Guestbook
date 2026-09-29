using System.Text.Json;

namespace Laboration_3;

// Handles saving and loading guestbook entries using JSON
public class GuestbookStorage
{
    private string filePath = "guestbook.json";

    // Serialize and save the guestbook entries to file
    public void Save(List<GuestbookEntry> entries)
    {
        string json = JsonSerializer.Serialize(entries);
        File.WriteAllText(filePath, json);
    }

    // Load and deserialize saved entries or return an empty list if no file exists
    public List<GuestbookEntry> Load()
    {
        if (File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath);

            return JsonSerializer.Deserialize<List<GuestbookEntry>>(json)
                   ?? new List<GuestbookEntry>();
        }

        return new List<GuestbookEntry>();
    }
}