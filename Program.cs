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
        Console.WriteLine($" ({FormatBytes(size)})");
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
Console.WriteLine($"Cleaned space: {FormatBytes(totalSize)}");
Console.ForegroundColor = ConsoleColor.Cyan;
Console.WriteLine("Finished!, press any key to continue");
Console.ReadLine();

/* Thanks to https://stackoverflow.com/a/2082893/11756870
 * I made some little changes to get an ulong instead of long
 * and to simplify the code */
static string FormatBytes(ulong bytes)
{
    string[] Suffix = { "B", "KB", "MB", "GB", "TB" };
    int i;
    double dblSByte = bytes;
    for (i = 0; i < Suffix.Length && bytes >= 1024; i++, bytes /= 1024)
    {
        dblSByte = bytes / 1024.0;
    }

    return string.Format("{0:0.##} {1}", dblSByte, Suffix[i]);
}