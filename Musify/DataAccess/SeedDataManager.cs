using System.Text.Json;
using Musify.Models;

namespace Musify.DataAccess
{
    public class SeedDataManager
    {
        private const string FileName = "seed-library.json";

        // Reads the starter data used to populate the app for the demo.
        public LibraryData ReadSeedData()
        {
            using Stream reader = FileSystem.OpenAppPackageFileAsync(FileName).GetAwaiter().GetResult();
            return JsonSerializer.Deserialize<LibraryData>(reader) ?? new LibraryData();
        }
    }
}
