using System.Diagnostics;
using Grid = Microsoft.Maui.Controls.Grid;

namespace CellCraft {
    using Table = Table.Models.Table;

    public partial class MainPage : ContentPage {
        private Dictionary<string, int> identificators = new Dictionary<string, int>();

        public MainPage() {
            InitializeComponent();
            CreateGrid();
        }

        private void CreateGrid() {
            AddColumnsAndColumnLabels();
            AddRowsAndCellEntries();
        }

        private void AddColumnsAndColumnLabels() {
            var label = new Label() {
                Text = "",
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.Center
            };
            grid.Add(label, 0, 0);

            for (int col = 1; col < Table.Get().CountColumn + 1; col++) {
                label = new Label() {
                    Text = Table.GetColumnName(col - 1),
                    VerticalOptions = LayoutOptions.Center,
                    HorizontalOptions = LayoutOptions.Center
                };
                grid.Add(label, col, 0);
            }
        }

        private void AddRowsAndCellEntries() {
            
            for (int row = 1; row < Table.Get().CountRow + 1; row++) {
                
                var label = new Label() {
                    Text = (row).ToString(),
                    VerticalOptions = LayoutOptions.Center,
                    HorizontalOptions = LayoutOptions.Center
                };
                grid.Add(label, 0, row);

                for (int col = 1; col < Table.Get().CountColumn + 1; col++) {
                    var entry = new Entry {
                        Text = "",
                        VerticalOptions = LayoutOptions.Fill,
                        HorizontalOptions = LayoutOptions.Fill
                    };

                    entry.Unfocused += Entry_Unfocused;
                    entry.Focused += Entry_Focused;
                    grid.Add(entry, col, row);
                }
            }
        }
            
        private void Entry_Focused(object sender, FocusEventArgs e) {
            var entry = (Entry)sender;
            var row = Grid.GetRow(entry) - 1;
            var column = Grid.GetColumn(entry) - 1;

            entry.Text = Table.Get().GetCell(row, column).ShowFocused();
        }
        private void Entry_Unfocused(object sender, FocusEventArgs e) {
            var entry = (Entry)sender;
            var row = Grid.GetRow(entry) - 1;
            var column = Grid.GetColumn(entry) - 1;
            var content = entry.Text;

            var cell = Table.Get().GetCell(row, column).Write(content, identificators);

            try {
                entry.Text = cell.Calculate(identificators).ShowUnfocused();
            }
            catch (DivideByZeroException) {
                entry.Text = "ERROR : Divide by zero. ";
            }
            catch (ArgumentException) {
                entry.Text = "ERROR : Wrong operand. ";
            }
            catch (System.NullReferenceException) {
                entry.Text = "ERROR : Wrong format of expression. ";
            }
        }
            
        private void SaveButton_Clicked(object sender, EventArgs e) {
            for (int i = 0; i < Table.Get().CountRow; i++) {
                for (int j = 0; j < Table.Get().CountColumn; j++) {
                    Debug.Write(Table.Get().GetCell(i, j).Number, " ");
                }
                Debug.WriteLine(" ");
            }
        }

        private void AddRowButton_Clicked(object sender, EventArgs e) {
            // Add number of row
            var row = grid.RowDefinitions.Count();
            var label = new Label {
                Text = (row).ToString(),
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center
            };
            grid.Add(label, 0, row);
            
            // Add entries
            for (int col = 1; col < grid.ColumnDefinitions.Count(); col++) {
                var entry = new Entry() {
                    Text = "",
                    VerticalOptions = LayoutOptions.Fill,
                    HorizontalOptions = LayoutOptions.Fill
                };

                entry.Unfocused += Entry_Unfocused;
                entry.Focused += Entry_Focused;
                grid.Add(entry, col, row);
            }

            // Add row in table instance
            Table.Get().AddNewRow(grid.ColumnDefinitions.Count() - 1);
        }

        private void AddColumnButton_Clicked(object sender, EventArgs e) { 
            // Add name of column
            var column = grid.ColumnDefinitions.Count();
            var label = new Label {
                Text = Table.GetColumnName(column - 1),
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center
            };
            grid.Add(label, column, 0);

            // Add entries
            for (int row = 1; row < grid.RowDefinitions.Count(); row++) {
                var entry = new Entry() {
                    Text = "",
                    VerticalOptions = LayoutOptions.Fill,
                    HorizontalOptions = LayoutOptions.Fill
                };

                entry.Unfocused += Entry_Unfocused;
                entry.Focused += Entry_Focused;
                grid.Add(entry, column, row);
            }

            // Add column in table instance
            Table.Get().AddNewColumn(grid.RowDefinitions.Count() - 1);
        }

        private async void HelpButton_Clicked(object sender, EventArgs e) {
            await DisplayAlert("Довідка", "Лабораторна робота 1. Варіант 42. Виконала Уточкіна Яна (група К-23)", "Ок");
        }

        private async void ExitButton_Clicked(object sender, EventArgs e) {
            bool answear = await DisplayAlert("Підтвердження", "Ви дійсно хочете вийти?", "Так", "Ні");
            if (answear) {
                System.Environment.Exit(0);
            }
        }
    }
}