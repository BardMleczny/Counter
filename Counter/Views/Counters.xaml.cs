using System.Text.Json;

namespace Counter.Views;

public partial class Counters : ContentPage
{
	public Counters()
	{
		InitializeComponent();
        BindingContext = new Models.AllCounters();
    }
    protected override void OnAppearing()
    {
        base.OnAppearing();
        ((Models.AllCounters)BindingContext).LoadCounters();
    }
    private async void Add_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(AddCounter));
    }
    private async void Plus_Clicked(object sender, EventArgs e)
    {
        if (sender is Button button)
        {
            var counter = button.BindingContext as Models.Counter;

            string filePath = Path.Combine(FileSystem.AppDataDirectory, "counters.json");

            List<Models.Counter> counters = new();

            if (File.Exists(filePath))
            {
                string data = await File.ReadAllTextAsync(filePath);
                counters = JsonSerializer.Deserialize<List<Models.Counter>>(data) ?? new List<Models.Counter>();
            }

            counters[counter.Id].Value++;
            button.Parent.BindingContext = counters[counter.Id];

            var options = new JsonSerializerOptions { WriteIndented = true };
            string jsonData = JsonSerializer.Serialize(counters, options);

            await File.WriteAllTextAsync(filePath, jsonData);
        }
    }
    private async void Minus_Clicked(object sender, EventArgs e)
    {
        if (sender is Button button)
        {
            var counter = button.BindingContext as Models.Counter;

            string filePath = Path.Combine(FileSystem.AppDataDirectory, "counters.json");

            List<Models.Counter> counters = new();

            if (File.Exists(filePath))
            {
                string data = await File.ReadAllTextAsync(filePath);
                counters = JsonSerializer.Deserialize<List<Models.Counter>>(data) ?? new List<Models.Counter>();
            }

            counters[counter.Id].Value--;
            button.Parent.BindingContext = counters[counter.Id];

            var options = new JsonSerializerOptions { WriteIndented = true };
            string jsonData = JsonSerializer.Serialize(counters, options);

            await File.WriteAllTextAsync(filePath, jsonData);
        }
    }
    private async void Reset_Clicked(object sender, EventArgs e)
    {
        if (sender is Button button)
        {
            var counter = button.BindingContext as Models.Counter;

            string filePath = Path.Combine(FileSystem.AppDataDirectory, "counters.json");

            List<Models.Counter> counters = new();

            if (File.Exists(filePath))
            {
                string data = await File.ReadAllTextAsync(filePath);
                counters = JsonSerializer.Deserialize<List<Models.Counter>>(data) ?? new List<Models.Counter>();
            }

            counters[counter.Id].Value = counters[counter.Id].BaseValue;
            button.Parent.BindingContext = counters[counter.Id];

            var options = new JsonSerializerOptions { WriteIndented = true };
            string jsonData = JsonSerializer.Serialize(counters, options);

            await File.WriteAllTextAsync(filePath, jsonData);
        }
    }
    private async void Delete_Clicked(object sender, EventArgs e)
    {
        if (sender is Button button)
        {
            var counter = button.BindingContext as Models.Counter;

            string filePath = Path.Combine(FileSystem.AppDataDirectory, "counters.json");

            List<Models.Counter> counters = new();

            if (File.Exists(filePath))
            {
                string data = await File.ReadAllTextAsync(filePath);
                counters = JsonSerializer.Deserialize<List<Models.Counter>>(data) ?? new List<Models.Counter>();
            }

            counters.RemoveAt(counter.Id);
            for(int i = counter.Id; i < counters.Count; i++)
            {
                counters[i].Id--;
            }

            var options = new JsonSerializerOptions { WriteIndented = true };
            string jsonData = JsonSerializer.Serialize(counters, options);

            await File.WriteAllTextAsync(filePath, jsonData);

            OnAppearing();
        }
    }
}