using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CellCraft {
    internal sealed class Table {
        public List<List<Cell>> cells { get; }
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
        public int RowLength() {
            return cells.Count(); 
        }

        public int ColumnLength() {
            return cells[0].Count();
        }
    }

    internal class Cell {
        public double value { get; }
        public string? formula {get;}

        public Cell(double value = 0, string formula = "") { }

    }

}
