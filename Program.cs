ulong totalSize = 0;
Console.ForegroundColor = ConsoleColor.Cyan;
Console.Write("Made by: ");
Console.ForegroundColor = ConsoleColor.White;
Console.Write("LuisAlfredo92");
Console.ForegroundColor = ConsoleColor.Cyan;
Console.WriteLine(": https://github.com/LuisAlfredo92/AMD-Cleaner");
Console.WriteLine("Starting...");
foreach (var folder in Directory.GetDirectories(@"C:\AMD"))
{
    try
    {
        ulong size = (ulong)new DirectoryInfo(folder).EnumerateFiles("*", SearchOption.AllDirectories).Sum(fi => fi.Length);
        totalSize += size;
        Directory.Delete(folder, true);
        Console.ForegroundColor = ConsoleColor.Green;
        Console.Write("Deleted: ");
        Console.ForegroundColor = ConsoleColor.White;
        Console.Write(folder);
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine($" ({size} B)");
    }
    catch (Exception ex)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($"There was an error while trying to delete {folder}: {ex.Message}");
    }
}
Console.ForegroundColor = ConsoleColor.Green;
Console.WriteLine("Done!");
Console.ForegroundColor = ConsoleColor.White;
Console.WriteLine($"Cleaned space: {totalSize} B");
Console.ForegroundColor = ConsoleColor.Cyan;
Console.WriteLine("Finished, press any key to continue");
Console.ReadLine();