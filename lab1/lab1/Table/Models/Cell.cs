using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.Text;

namespace Table.Models {
    using Calculator = Calculator.Calculator;
    internal class Cell {

        private int? number;
        private string formula;
        private bool formulaResult;
        private bool isError;
        public string id;

        public int? Number {
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
        public Cell(string id, string formula = "  ", bool formulaResult = false, bool isError = false) {
            this.id = id;
        }

        public Cell Write(string content, Dictionary<string, int> ids) {
            if (int.TryParse(content, out int result)) {
                Debug.WriteLine("Write number");
                Number = result;
                formula = " ";
                isError = false;

                if (!ids.TryAdd(id, result)) {
                    if (ids.ContainsKey(id)) {
                        ids[id] = result;
                    }
                }
            }
            else if (!string.IsNullOrWhiteSpace(content)){
                number = null;
                formula = content;
                isError = false;
            }
            return this;
        }

        public Cell Calculate(Dictionary<string, int> ids) {
            if (!string.IsNullOrWhiteSpace(formula)) {
                try {
                    if (Calculator.Evaluate(Formula, ids) == 1.0) {
                        formulaResult = true;
                        isError = false;
                    }
                }
                catch (NullReferenceException) {
                    isError = true;
                }
            }
            return this;
        }

        public string ShowFocused() {
            if (!string.IsNullOrWhiteSpace(formula)) {
                return formula;
            }
            else if (number != null) {
                return number.ToString();
            }
            else {
                return "";
            }
            
        }

        public string ShowUnfocused() {
            if (isError) {
                return "ERROR";
            }
            else if (!string.IsNullOrWhiteSpace(formula)) {
                return formulaResult.ToString();
            }
            else if (number != null) {
                return number.ToString();
            }
            else {
                return "";
            }
        }

    }
}
