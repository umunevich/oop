using Transform = StudentSuccess.Models.Transform;
using StudentSuccess.Models.AnalizeStrategy;
using Logger = StudentSuccess.Models.Logger;

namespace StudentSuccess
{
    public partial class MainPage : ContentPage {
        Dictionary<string, string> filePaths = new Dictionary<string, string>(); // short path, full path
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

            try {
                filePaths.Add(result.FileName, result.FullPath);
            }
            catch (Exception) {
                await DisplayAlert("Помилка", "Файл вже доданий до \"Нещодавно вікритих\"", "Ок");
            }

            FileName.Text = result.FileName;
            var content = File.ReadAllText(filePaths[FileName.Text]);
            XMLEditor.Text = content;

            RecentlyFiles.ItemsSource = filePaths.Keys.ToList();
            Logger.instance.Log("Відкриття", "Файл " +  FileName.Text);
        }

        private void RecentlyFiles_Selected(object sender, SelectedItemChangedEventArgs e) {
            if (e.SelectedItem != null) {
                FileName.Text = e.SelectedItem.ToString();
                var content = File.ReadAllText(filePaths[FileName.Text]);
                XMLEditor.Text = content;
                Logger.instance.Log("Відкриття", "Файл " + FileName.Text);
            }   
        }

        private void SaveButton_Clicked(object sender, EventArgs e) {
            var content = XMLEditor.Text;
            File.WriteAllText(filePaths[FileName.Text], content);
            Logger.instance.Log("Збереження", "Файл " + FileName.Text);
        }

        private async void TransformToHtmlButton_Clicked(object sender, EventArgs e) {
            string[] arr = FileName.Text.Split('.');
            var output_file = arr[0] + ".html";
            try {
                Transform.TransformTo("D:/Learning/University2/OOP/oop repo/lab2/lab2/Transform/toHtml.xsl", filePaths[FileName.Text], "D:/Learning/University2/OOP/oop repo/lab2/lab2/Transform/OutputHtml/" + output_file);
            }
            catch {
                await DisplayAlert("Помилка", "У файлі присутні помилки", "Ок");
            }
            Logger.instance.Log("Трансформація", "Збережено у файл " + output_file);
        }

        private async void SearchButton_Clicked(object sender, EventArgs e) {
            AnalizeContext ac = new AnalizeContext();
            switch(StrategyPicker.SelectedIndex) {
                case 0:
                    ac.SetStrategy(new SaxAnalizeStrategy());
                    break;
                case 1:
                    ac.SetStrategy(new DomAnalizeStrategy());
                    break;
                case 2:
                    ac.SetStrategy(new LinqAnalizeStrategy());
                    break;
            }
            Models.AnalizeStrategy.Attribute attr = new Models.AnalizeStrategy.Attribute();
            switch (AttributePicker.SelectedIndex){
                case 0:
                    attr = Models.AnalizeStrategy.Attribute.Faculty;
                    break;
                case 1:
                    attr = Models.AnalizeStrategy.Attribute.Department;
                    break;
                case 2:
                    attr = Models.AnalizeStrategy.Attribute.Discipline;
                    break;
            }
            Logger.instance.Log("Пошук", "У файлі " + FileName.Text);
            string result;
            try {
                result = ac.Search(filePaths[FileName.Text], attr, EntryValue.Text);
            }
            catch (Exception) {
                result = "У файлі присутні помилки";
            }
            await DisplayAlert("Результат", result, "Ок");
        }

        private void ClearButton_Clicked(object sender, EventArgs e) {
            StrategyPicker.SelectedItem = null;
            AttributePicker.SelectedItem = null;
            EntryValue.Text = null;
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
