namespace Counter
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute(nameof(Views.AddCounter), typeof(Views.AddCounter));
        }
    }
}
