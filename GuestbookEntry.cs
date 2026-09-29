namespace Laboration_3;

// Represents a single guestbook entry
public class GuestbookEntry
{
    public string Name { get; set; }
    public string Message { get; set; }

    // Initialize an entry with a name and message
    public GuestbookEntry(string name, string message)
    {
        Name = name;
        Message = message;
    }
}