using Microsoft.Maui.Storage;

namespace StudentSuccess {
    public partial class MainPage : ContentPage {

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
                return;
            }

            FileName.Text = result.FileName;
            var path = result.FullPath;
            XMLEditor.Text = path;
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
