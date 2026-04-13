using System.Text.Json;
using Musify.Models;

namespace Musify.DataAccess;

public static class PersistenceService
{
    // Finds the hidden folder on the phone where the app is allowed to save data
    private static string _filePath = Path.Combine(FileSystem.AppDataDirectory, "library.json");

    /// <summary>
    /// Serializes the global LibraryData object into a JSON string and saves it 
    /// to the device's local application data directory.
    /// </summary>
    /// <param name="library">The LibraryData instance to be persisted.</param>
    public static void SaveLibrary(LibraryData library)
    {
        try
        {
            var json = JsonSerializer.Serialize(library);
            File.WriteAllText(_filePath, json);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Save Error: {ex.Message}");
        }
    }

    /// <summary>
    /// Reads the library JSON file from local storage and deserializes it 
    /// back into a LibraryData object.
    /// </summary>
    /// <returns>The loaded LibraryData instance, or null if no save file exists.</returns>
    public static LibraryData LoadLibrary()
    {
        try
        {
            if (!File.Exists(_filePath)) return null;

            var json = File.ReadAllText(_filePath);
            return JsonSerializer.Deserialize<LibraryData>(json);
        }
        catch
        {
            return null;
        }
    }
}