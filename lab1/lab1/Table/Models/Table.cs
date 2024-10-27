using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Table.Models {
     class Table {
        private List<List<Cell>> cells { get; }

        private static int countRow = 8;
        private static int countColumn = 6;

        public int CountRow {
            get {
                return countRow;
            }
            set {
#if DEBUG
                if (value < 0) {
                    throw new ArgumentOutOfRangeException($"CountRow less then 0. Actual : {value}");
                }
#endif
                countRow = value;
            }
        }

        public int CountColumn {
            get {
                return countColumn;
            }
            set {
#if DEBUG
                if (value < 0) {
                    throw new ArgumentOutOfRangeException($"CountColumn less then 0. Actual : {value}");
                }
#endif
                countColumn = value;
            }
        }

        private Table(int count_row, int count_column) {
            cells = new List<List<Cell>>(count_row) { };

            for (int i = 0; i < count_row; i++) {
                var rows = new List<Cell>(count_column);

                for (int j = 0; j < count_column; j++) {
                    rows.Add(new Cell(GetColumnName(j) + (i + 1).ToString()));
                    Debug.WriteLine(GetColumnName(j) + (i + 1).ToString());
                }
                cells.Add(rows);
            }
        }

        private static string GetColumnName(int colIndex) {
            int dividend = colIndex + 1;
            string columnName = string.Empty;

            while (dividend > 0) {
                int modulo = (dividend - 1) % 26;
                columnName = Convert.ToChar(65 + modulo) + columnName;
                dividend = (dividend - modulo) / 26;
            }

            return columnName;
        }

        private static Table? table;

        public static Table Get() {
            if (table == null) {
                table = new Table(countRow, countColumn);
            }
            return table;
        }

        public Cell GetCell(int row, int column) {
#if DEBUG
            if (row < 0 || row >= CountRow || column < 0 || column >= CountColumn) {
                throw new ArgumentOutOfRangeException($"Invalid cell index [{row}][{column}]");
            }
#endif
            return cells[row][column];
        }

        public Cell GetCell(string id) {
            int column = 0;
            int i = 0;

            while (i < id.Length && char.IsLetter(id[i])) {
                column = column * 26 + (id[i] - 'A' + 1);
                i++;
            }
            string rowStr = id.Substring(i);
            int row = 0;
            int.TryParse(rowStr, out row);
            Debug.WriteLine($"{row - 1} {column - 1}");
            return cells[row - 1][column - 1];
        }

        public void AddNewRow(int size) {
#if DEBUG
            if (size != CountColumn) { 
                throw new ArgumentOutOfRangeException($"Invalid size of new row. Try {size} but actual {CountColumn}");
            }
#endif
            var newRow = new List<Cell>(size);
            CountRow++;
            for (int col = 0; col < size; col++) {
                newRow.Add(new Cell(GetColumnName(col) + CountRow.ToString()));
            }
            cells.Add(newRow);
        }

        public void AddNewColumn(int size) {
#if DEBUG
            if (size != CountRow) {
                throw new ArgumentOutOfRangeException($"Invalid size of new row. Try {size} but actual {CountRow}");
            }
#endif
            for (int row = 0; row < size; row++) {
                cells[row].Add(new Cell(GetColumnName(CountColumn) + (row + 1).ToString()));
            }
            CountColumn++;
        }
        
    }
}
