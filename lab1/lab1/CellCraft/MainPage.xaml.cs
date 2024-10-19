using System.Diagnostics;
using System.Runtime.ConstrainedExecution;
using Grid = Microsoft.Maui.Controls.Grid;

namespace CellCraft {
    public partial class MainPage : ContentPage {
        const int countCol = 1;
        const int countRow = 1;

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

            for (int col = 1; col < countCol + 1; col++) {
                
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
            
            for (int row = 1; row < countRow + 1; row++) {
                
                var label = new Label() {
                    Text = (row).ToString(),
                    VerticalOptions = LayoutOptions.Center,
                    HorizontalOptions = LayoutOptions.Center
                };
                grid.Add(label, 0, row);

                for (int col = 1; col < countCol + 1; col++) {
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
    

        

        private void SaveButton_Clicked(object sender, EventArgs e) { }

        private void AddRowButton_Clicked(object sender, EventArgs e) {
            var row = grid.RowDefinitions.Count();
            var label = new Label {
                Text = (row).ToString(),
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center
            };
            grid.Add(label, 0, row);

            for (int col = 1; col < grid.ColumnDefinitions.Count(); col++) {
                var entry = new Entry() {
                    Text = "",
                    VerticalOptions = LayoutOptions.Fill,
                    HorizontalOptions = LayoutOptions.Fill
                };
                grid.Add(entry, col, row);
            }
        }
        public int i = 0;
        private void DeleteRowButton_Clicked(object sender, EventArgs e) {
            if (grid.RowDefinitions.Count() > 1) {
                int lastRowIndex = grid.RowDefinitions.Count() - 1;
                //table.RowDefinitions.RemoveAt(lastRowIndex);
                    grid.Children.RemoveAt(i);
                    Debug.WriteLine(i);
               
                    
               
                
                /*for (int col = 0; col < 1*//*table.ColumnDefinitions.Count()*//*; col++) {
                    Debug.WriteLine((lastRowIndex * (table.ColumnDefinitions.Count())) + col );

                    table.RemoveAt((lastRowIndex * (table.ColumnDefinitions.Count())) + col );
                    Thread.Sleep(1000);
                }*/
            }
        }

        private void AddColumnButton_Clicked(object sender, EventArgs e) { 
            var column = grid.ColumnDefinitions.Count();
            var label = new Label {
                Text = GetColumnName(column),
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center
            };
            grid.Add(label, column, 0);

            for (int row = 1; row < grid.RowDefinitions.Count(); row++) {
                var entry = new Entry() {
                    Text = "",
                    VerticalOptions = LayoutOptions.Fill,
                    HorizontalOptions = LayoutOptions.Fill
                };
                grid.Add(entry, column, row);
            }
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
