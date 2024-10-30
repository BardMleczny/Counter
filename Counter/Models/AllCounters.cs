using System.Collections.ObjectModel;
using System.Text.Json;

namespace Counter.Models
{
    class AllCounters
    {
        public ObservableCollection<Counter> Counters { get; set; } = new();
        public AllCounters() => LoadCounters();

        public void LoadCounters()
        {
            Counters.Clear();

            string filePath = Path.Combine(FileSystem.AppDataDirectory, "counters.json");

            if (File.Exists(filePath))
            {
                string data = File.ReadAllText(filePath);
                List<Counter> counters = JsonSerializer.Deserialize<List<Models.Counter>>(data) ?? new List<Models.Counter>();

                foreach (Counter counter in counters)
                {
                    Counters.Add(counter);
                }
            }
        }
    }
}
