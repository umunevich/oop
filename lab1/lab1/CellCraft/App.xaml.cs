namespace CellCraft {
    public partial class App : Application {
        public App() {
            InitializeComponent();
            var table = Table.Models.Table.Get();
            MainPage = new AppShell();
        }
    }
}
