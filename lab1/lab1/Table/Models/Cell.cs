using System;
using System.Collections.Generic;
using System.Text;

namespace Table.Models {
    using Calculator = Calculator.Calculator;
    internal class Cell {
        private int number;
        private string formula;
        private bool formulaResult;
        private bool isError;
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
                if (formula == "") {
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
        public Cell(int value = 0, string formula = "  ", bool formulaResult = false, bool isError = false) {
        }

        public Cell Write(string content) {
            if (int.TryParse(content, out int result)) {
                Number = result;
                Formula = " ";
                isError = false;
            }
            else {
                Formula = content;
                isError = false;
            }
            return this;
        }

        public Cell Calculate() {
            if (Formula.Trim().Length != 0) {
                try {
                    if (Calculator.Evaluate(Formula) == 1.0) {
                        FormulaResult = true;
                        isError = false;
                    }
                }
                catch (NullReferenceException e) {
                    isError = true;
                }
            }
            return this;
        }

        public string Show() {
            if (Formula.Trim().Length != 0) {
                return Formula;
            }
            else if (isError){
                return "ERROR";
            }
            else {
                return Number.ToString();
            }
        }

    }
}
