using Laboration_3;

// Create storage and load saved guestbook entries
GuestbookStorage storage = new GuestbookStorage();
Guestbook guestbook = new Guestbook(storage.Load());

while (true)
{
    // Clear and redraw the console after each menu choice
    Console.Clear();

    Console.WriteLine("V Ä L K O M M E N\nt i l l   f r e d r i k a s\nG Ä S T B O K");
    Console.WriteLine();

    DisplayEntries(guestbook);

    string choice = DisplayMenu();

    Console.WriteLine();

    // Handle the user's menu choice
    if (choice == "1")
    {
        AddEntry(guestbook);
        storage.Save(guestbook.Entries);
    }
    else if (choice == "2")
    {
        if (RemoveEntry(guestbook))
        {
            storage.Save(guestbook.Entries);
        }
    }
    else if (choice.ToLower() == "x")
    {
        break;
    }
    else
    {
        Console.WriteLine("Fel: Ogiltigt val.");
        Console.WriteLine("Tryck på valfri tangent för att försöka igen.");
        Console.ReadKey();
    }

    Console.WriteLine();
}


// Display the main menu and return the user's choice
static string DisplayMenu()
{
    Console.WriteLine();
    Console.WriteLine("1. Lägg till inlägg");
    Console.WriteLine("2. Ta bort inlägg\n");
    Console.WriteLine("X. Avsluta");
    Console.WriteLine();

    Console.Write("Välj vad du vill göra (1, 2 eller X): ");

    return Console.ReadLine() ?? "";
}


// Display all guestbook entries with their index
static void DisplayEntries(Guestbook guestbook)
{
    for (int i = 0; i < guestbook.Entries.Count; i++)
    {
        Console.WriteLine($"{i}. {guestbook.Entries[i].Name} skrev:\n {guestbook.Entries[i].Message}");
        Console.WriteLine();
    }
}


// Get user input and add a new entry to the guestbook
static void AddEntry(Guestbook guestbook)
{
    Console.WriteLine("Du har valt att lägga till ett nytt inlägg.");
    Console.WriteLine();

    Console.Write("Ange ditt namn: ");
    string name = Console.ReadLine() ?? "";

    // Keep asking until a valid name is entered
    while (string.IsNullOrWhiteSpace(name))
    {
        Console.WriteLine("Fel: Du måste fylla i ditt namn.");
        Console.Write("Ange ditt namn igen: ");
        name = Console.ReadLine() ?? "";
    }

    Console.Write("Skriv ditt inlägg: ");
    string message = Console.ReadLine() ?? "";

    // Keep asking until a valid message is entered
    while (string.IsNullOrWhiteSpace(message))
    {
        Console.WriteLine("Fel: Du måste skriva något.");
        Console.Write("Skriv ditt inlägg igen: ");
        message = Console.ReadLine() ?? "";
    }

    GuestbookEntry entry = new GuestbookEntry(name, message);
    guestbook.AddEntry(entry);
}


// Remove an entry by index and return whether an entry was removed
static bool RemoveEntry(Guestbook guestbook)
{
    if (guestbook.Entries.Count == 0)
    {
        Console.WriteLine("Det finns inga inlägg att ta bort.");
        Console.WriteLine("Tryck på valfri tangent för att återvända till menyn.");
        Console.ReadKey();

        return false;
    }

    Console.WriteLine("Du har valt att ta bort ett inlägg.");
    Console.WriteLine();

    int index;

    // Keep asking until the user enters a valid index
    while (true)
    {
        Console.Write("Ange index för inlägget du vill ta bort (X för att avbryta): ");
        string input = Console.ReadLine() ?? "";

        if (input.ToLower() == "x")
        {
            return false;
        }

        if (int.TryParse(input, out index) &&
            index >= 0 &&
            index < guestbook.Entries.Count)
        {
            break;
        }

        Console.WriteLine("Fel: Du måste ange ett giltigt index.");
    }

    guestbook.RemoveEntry(index);

    return true;
}