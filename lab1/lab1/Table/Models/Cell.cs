using System;
using System.Collections.Generic;
using System.Diagnostics;
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
                Debug.WriteLine("Write number");
                number = result;
                formula = " ";
                isError = false;
            }
            else if (content.Trim().Length != 0){
                formula = content;
                isError = false;
            }
            return this;
        }

        public Cell Calculate() {
            if (!string.IsNullOrWhiteSpace(formula)) {
                try {
                    if (Calculator.Evaluate(Formula) == 1.0) {
                        formulaResult = true;
                        isError = false;
                    }
                }
                catch (NullReferenceException e) {
                    isError = true;
                }
            }
            return this;
        }

        public string ShowFocused() {
            if (!string.IsNullOrWhiteSpace(formula)) {
                return formula;
            }
            else {
                return number.ToString();
            }
        }

        public string ShowUnfocused() {
            if (!string.IsNullOrWhiteSpace(formula)) {
                return formulaResult.ToString();
            }
            else if (isError) {
                return "ERROR";
            }
            else {
                return number.ToString();
            }
        }

    }
}
