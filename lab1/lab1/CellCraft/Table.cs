using Microsoft.Maui.Controls.PlatformConfiguration.iOSSpecific;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CellCraft {
    internal sealed class Table {
        private List<List<Cell>> cells { get; }
        private const int CountRow = 2;
        private const int CountColumn = 2;

        private Table(int row, int column ) {
            cells = new List<List<Cell>>(row) { };
            for (int i = 0; i < row; i++) {
                Debug.WriteLine(i);
                var rows = new List<Cell>(column);
                for (int j = 0; j < column; j++) {
                    rows.Add(new Cell());
                }
                cells.Add(rows);
            }
        }

        private static Table? table;

        public static Table GetTable() {
            if (table == null) {
                table = new Table(CountRow, CountColumn);
            }
            return table;
        }

        public Cell GetCell(int row, int column) {
#if DEBUG
            if (row < 0 || row >= ColumnLength() || column < 0 || column >= RowLength()) {
                throw new ArgumentOutOfRangeException($"Invalid cell index [{row}][{column}]");
            }
#endif
            return cells[row][column];
        }

        public void AddNewRow(int size) {
#if DEBUG
            if (size != RowLength()) { 
                throw new ArgumentOutOfRangeException($"Invalid size of new row. Try {size} but actual {RowLength()}");
            }
#endif
            var newRow = new List<Cell>(size);
            for (int col = 0; col < size; col++) {
                newRow.Add(new Cell());
            }
            cells.Add(newRow);
        }

        public void AddNewColumn(int size) {
#if DEBUG
            if (size != ColumnLength()) {
                throw new ArgumentOutOfRangeException($"Invalid size of new row. Try {size} but actual {ColumnLength()}");
            }
#endif
            for (int row = 0; row < size; row++) {
                cells[row].Add(new Cell());
            }
        }
        public int ColumnLength() {
            return cells.Count(); 
        }

        public int RowLength() {
            return cells[0].Count();
        }
    }

    internal class Cell {
        public double value { get; private set; }
        private string? formula { get; set; }

        public Cell(double value = 0, string formula = "") { }
        public void SetValue(string content) {
            if (double.TryParse(content, out double result)) {
                value = result;
                formula = null;
            }
            else {
                formula = content;
            }
        }

        public string? GetFormula() { 
            return formula; 
        }
    }

}
