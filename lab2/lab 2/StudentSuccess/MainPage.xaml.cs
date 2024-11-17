namespace StudentSuccess {
    public partial class MainPage : ContentPage {
        List<string> filePaths = new List<string>();

        int currentFile = 0;
        public MainPage() {
            InitializeComponent();
        }

        private async void ChooseFileButton_Clicked(object sender, EventArgs e) {
            var XmlFileType = new FilePickerFileType(new Dictionary<DevicePlatform, IEnumerable<string>> {
                { DevicePlatform.WinUI, new[] { ".xml"} }
            });

            var result = await FilePicker.PickAsync(new PickOptions {
                PickerTitle = "Pick XML file",
                FileTypes = XmlFileType
            });

            if (result == null) {
                await DisplayAlert("Помилка", "Файл не вибрано", "Ок");
                return;
            }

            FileName.Text = result.FileName;
            filePaths.Add(result.FullPath);
            var fullPath = result.FullPath;
            currentFile = filePaths.Count() - 1;

            var content = File.ReadAllText(filePaths[currentFile]);
            XMLEditor.Text = content;

            //RecentlyFiles.ItemsSource = filePaths;
        }

        public async void SearchButton_Clicked(object sender, EventArgs e) {
            var searchPage = new SearchPage();
            await Navigation.PushAsync(searchPage);
        }

        private async void HelpButton_Clicked(object sender, EventArgs e) {
            await DisplayAlert("Довідка", "Лабораторна робота 2. Варіант \"Успішніснь студентів\". Виконала Уточкіна Яна (група К-23)", "Ок");
        }

        private async void ExitButton_Clicked(object sender, EventArgs e) {
            bool answear = await DisplayAlert("Підтвердження", "Ви дійсно хочете вийти?", "Так", "Ні");
            if (answear) {
                System.Environment.Exit(0);
            }
        }
    }

}
