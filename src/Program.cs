class Program
{
    static BST tree = new BST();

    static void Main(string[] args)
    {
        bool running = true;

        while (running)
        {
            Console.WriteLine("\n=== Pest Control Management System ===");
            Console.WriteLine("1. Add Pest Record");
            Console.WriteLine("2. Search Pest Record");
            Console.WriteLine("3. Delete Pest Record");
            Console.WriteLine("4. Display All Records");
            Console.WriteLine("5. Exit");
            Console.Write("\nEnter your choice: ");

            string? choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    AddRecord();
                    break;
                case "2":
                    SearchRecord();
                    break;
                case "3":
                    DeleteRecord();
                    break;
                case "4":
                    tree.DisplayAll();
                    break;
                case "5":
                    running = false;
                    Console.WriteLine("Goodbye!");
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }

    static void AddRecord()
    {
        Console.Write("Enter ID: ");
        int id = int.Parse(Console.ReadLine()!);

        Console.Write("Enter Pest Type (e.g. Rats, Cockroaches): ");
        string pestType = Console.ReadLine()!;

        Console.Write("Enter Location: ");
        string location = Console.ReadLine()!;

        Console.Write("Enter Severity (Low/Medium/High): ");
        string severity = Console.ReadLine()!;

        Console.Write("Enter Status (Pending/In Progress/Resolved): ");
        string status = Console.ReadLine()!;

        Console.Write("Enter Technician Name: ");
        string technician = Console.ReadLine()!;

        Console.Write("Enter Treatment Applied: ");
        string treatment = Console.ReadLine()!;

        PestRecord record = new PestRecord(
            id, pestType, location, severity,
            status, technician, treatment, DateTime.Now
        );

        tree.Insert(record);
        Console.WriteLine("✅ Record added successfully!");
    }

    static void SearchRecord()
    {
        Console.Write("Enter ID to search: ");
        int id = int.Parse(Console.ReadLine()!);

        PestRecord? result = tree.Search(id);

        if (result != null)
            Console.WriteLine("\nRecord Found:\n" + result.ToString());
        else
            Console.WriteLine("❌ Record not found.");
    }

    static void DeleteRecord()
    {
        Console.Write("Enter ID to delete: ");
        int id = int.Parse(Console.ReadLine()!);

        tree.Delete(id);
        Console.WriteLine("✅ Record deleted successfully!");
    }
}
