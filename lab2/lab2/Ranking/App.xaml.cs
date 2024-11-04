namespace Ranking {
    public partial class App : Application {
        public App() {
            InitializeComponent();
            Logger.instance.Log("App init");
            MainPage = new AppShell();
        }
    }
}
