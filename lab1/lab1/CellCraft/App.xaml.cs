namespace CellCraft {
    public partial class App : Application {
        

        public App() {
            InitializeComponent();
            var table = Table.GetTable();
            MainPage = new AppShell();
        }
    }
}
