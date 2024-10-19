namespace CellCraft {
    public partial class App : Application {
        

        public App() {
            InitializeComponent();
            Table.GetTable();
            MainPage = new AppShell();
        }
    }
}
