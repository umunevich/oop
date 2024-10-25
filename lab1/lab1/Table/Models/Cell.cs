using System;
using System.Collections.Generic;
using System.Text;

namespace Table.Models {
    internal class Cell {
        private int number;
        private string? formula;
        private bool formulaResult;

        public int Number {
            get {
                return number;
            }
            private set {
                number = value;
            }
        }

        public string Formula {
            get {
#if DEBUG
                if (formula == null) {
                    throw new ArgumentException("Formula is null. ");
                }
#endif
                return formula;
            }
            private set {
                formula = value;
            }
        }

        public bool FormulaResult {
            get {
                return formulaResult;
            }
            private set {
                formulaResult = value;
            }
        }
        public Cell(int value = 0, string formula = "", bool formulaResult = false) { }
    }
}
