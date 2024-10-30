using System.Text.Json;

namespace Counter.Views;

public partial class AddCounter : ContentPage
{
	public AddCounter()
	{
		InitializeComponent();
    }

    private void OnValueChanged(object sender, TextChangedEventArgs e)
    {
        if (sender is Entry entry)
            entry.Text = string.Concat(entry.Text.Where(char.IsDigit));
    }

    public async void SaveButton(object sender, EventArgs e)
    {
        if(CounterName.Text != null && CounterValue.Text != null && CounterColor.SelectedItem != null) {
            if (CounterName.Text.Length > 0 && CounterValue.Text.Length > 0)
            {
                string filePath = Path.Combine(FileSystem.AppDataDirectory, "counters.json");

                List<Models.Counter> counters = new();

                if (File.Exists(filePath))
                {
                    string data = await File.ReadAllTextAsync(filePath);
                    counters = JsonSerializer.Deserialize<List<Models.Counter>>(data) ?? new List<Models.Counter>();
                }
                if (!colorValues.TryGetValue(CounterColor.SelectedItem.ToString() ?? "White", out string color))
                    color = "#FFFFFF";

                int id = counters.Count;
                    Models.Counter counter = new(CounterName.Text, Int32.Parse(CounterValue.Text), Int32.Parse(CounterValue.Text), color, id);

                counters.Add(counter);

                var options = new JsonSerializerOptions { WriteIndented = true };
                string jsonData = JsonSerializer.Serialize(counters, options);            

                await File.WriteAllTextAsync(filePath, jsonData);

                await Shell.Current.GoToAsync("..");
            }
        }
    }

    private readonly Dictionary<string, string> colorValues = new()
        {
            { "White", "#FFFFFF" },
            { "Red", "#FF0000" },
            { "Yellow", "#FFFF00" },
            { "Green", "#00FF00" },
            { "Cyan", "#00FFFF" },
            { "Blue", "#0000FF" },
            { "Magenta", "#FF00FF" },
    };
}