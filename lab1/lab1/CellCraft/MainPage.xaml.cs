using System.Data;
using System.Diagnostics;
using System.Runtime.ConstrainedExecution;
using Grid = Microsoft.Maui.Controls.Grid;

namespace CellCraft {
    public partial class MainPage : ContentPage {

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

            for (int col = 1; col < Table.GetTable().RowLength() + 1; col++) {
                
                if (col > 0) {
                    label = new Label() {
                        Text = GetColumnName(col),
                        VerticalOptions = LayoutOptions.Center,
                        HorizontalOptions = LayoutOptions.Center
                    };
                    grid.Add(label, col, 0);
                    }
                }
            }

        private void AddRowsAndCellEntries() {
            
            for (int row = 1; row < Table.GetTable().ColumnLength() + 1; row++) {
                
                var label = new Label() {
                    Text = (row).ToString(),
                    VerticalOptions = LayoutOptions.Center,
                    HorizontalOptions = LayoutOptions.Center
                };
                grid.Add(label, 0, row);

                for (int col = 1; col < Table.GetTable().RowLength() + 1; col++) {
                    var entry = new Entry {
                        Text = "",
                        VerticalOptions = LayoutOptions.Fill,
                        HorizontalOptions = LayoutOptions.Fill
                    };
                    entry.Unfocused += Entry_Unfocused;
                    grid.Add(entry, col, row);
                }
            }
        }
            
        private void Entry_Unfocused(object sender, FocusEventArgs e) {
            var entry = (Entry)sender;
            var row = Grid.GetRow(entry) - 1;
            var column = Grid.GetColumn(entry) - 1;
            var content = entry.Text;

            Table.GetTable().GetCell(row, column).SetValue(content);
        }
            

       

        private string GetColumnName(int colIndex) {
            int dividend = colIndex;
            string columnName = string.Empty;

            while (dividend > 0) {
                int modulo = (dividend - 1) % 26;
                columnName = Convert.ToChar(65 + modulo) + columnName;
                dividend = (dividend - modulo) / 26;
            }

            return columnName;
        }
    

        

        private void SaveButton_Clicked(object sender, EventArgs e) {
            for (int i = 0; i < Table.GetTable().ColumnLength(); i++) {
                for (int j = 0; j < Table.GetTable().RowLength(); j++) {
                    Debug.Write(Table.GetTable().GetCell(i, j).value, " ");
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
                grid.Add(entry, col, row);
            }

            // Add row in table instance
            Table.GetTable().AddNewRow(grid.ColumnDefinitions.Count() - 1);
        }

        private void DeleteRowButton_Clicked(object sender, EventArgs e) {
            
        }

        private void AddColumnButton_Clicked(object sender, EventArgs e) { 
            // Add name of column
            var column = grid.ColumnDefinitions.Count();
            var label = new Label {
                Text = GetColumnName(column),
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
                grid.Add(entry, column, row);
            }

            // Add column in table instance
            Table.GetTable().AddNewColumn(grid.RowDefinitions.Count() - 1);
        }

        private void DeleteColumnButton_Clicked(object sender, EventArgs e) { }
        private void CalculateButton_Clicked(object sender, EventArgs e) { }

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
