namespace Laboration_3;

// Represents the guestbook and manages its entries
public class Guestbook
{
    public List<GuestbookEntry> Entries { get; set; }

    // Initialize the guestbook with previously loaded entries
    public Guestbook(List<GuestbookEntry> entries)
    {
        Entries = entries;
    }

    public void AddEntry(GuestbookEntry entry)
    {
        Entries.Add(entry);
    }

    public void RemoveEntry(int index)
    {
        Entries.RemoveAt(index);
    }
}
