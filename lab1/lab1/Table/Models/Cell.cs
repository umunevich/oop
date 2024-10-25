using System;
using System.Collections.Generic;
using System.Text;

namespace Table.Models {
    internal class Cell {
        private int number;

        public int Number {
            get {
                return number;
            }
            private set {
                number = value;
            }
        }

        private string formula;

        public string Formula {
            get {
                return formula;
            }
            private set {
                formula = value;
            }
        }

        public Cell(int value = 0, string formula = "") { }
    }
}
