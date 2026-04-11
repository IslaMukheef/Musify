using System.Text.Json;
using Musify.Models;

namespace Musify.DataAccess
{
    public class SeedDataManager
    {
        private const string FileName = "seed-library.json";

        // Reads the starter data used to populate the app for the demo.
        public async Task<LibraryData> ReadSeedDataAsync()
        {
            try
            {
                using Stream reader = await FileSystem.OpenAppPackageFileAsync(FileName);
                LibraryData data = JsonSerializer.Deserialize<LibraryData>(reader);

                if (data == null)
                    return new LibraryData();

                return data;
            }
            catch (JsonException)
            {
                return new LibraryData();
            }
        }
    }
}
