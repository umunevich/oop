using System.Diagnostics;

namespace Table.Models {
    using Calculator = Calculator.Calculator;

    internal class Cell {

        public string id;
        private int? number;
        private string? formula;
        private bool? formulaResult;
        private bool isError;

        public int? Number {
            get {
                return number;
            }
            private set {
                number = value;
            }
        }

        public Cell(string id, bool isError = false) {
            this.id = id;
        }

        public Cell Write(string content, Dictionary<string, int> ids) {
            if (int.TryParse(content, out int result)) {
                Debug.WriteLine("Write number");
                Number = result;
                formula = null;
                formulaResult = null;
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
                formulaResult = null;
                isError = false;

                if (ids.ContainsKey(id)) {
                    ids.Remove(id);
                }
            }
            else {
                number = null;
                formula = null;
                formulaResult = null;
                isError = false;
                if (ids.ContainsKey(id)) {
                    ids.Remove(id);
                }
            }
            return this;
        }

        public Cell Calculate(Dictionary<string, int> ids) {
            if (!string.IsNullOrWhiteSpace(formula)) {
                try {
                    if (Calculator.Evaluate(formula, ids) == 1.0) { // catch exceptions
                        formulaResult = true;
                        isError = false;
                    }
                    else {
                        formulaResult = false;
                        isError = false;
                    }
                }
                catch (NullReferenceException) {
                    isError = true;
                    formulaResult = null;
                }
                finally {
                    number = null;
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
                number = null;
                formulaResult = null;
                return "ERROR";
            }
            else if (!string.IsNullOrWhiteSpace(formula)) {
                return formulaResult.ToString();
            }
            else if (number != null) {
                formula = null;
                formulaResult = null;
                return number.ToString();
            }
            else {
                number = null;
                formula = null;
                formulaResult = null;
                return "";
            }
        }

    }
}
