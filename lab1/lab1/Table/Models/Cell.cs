using System.Diagnostics;

namespace Table.Models {
    using Calculator = Calculator.Calculator;

    internal class Cell {

        private string id;
        private int? number;
        private string? formula;
        private bool? formulaResult;

        public int? Number {
            get {
                return number;
            }
            private set {
                number = value;
            }
        }

        public Cell(string id) {
            this.id = id;
        }

        public Cell Write(string content, Dictionary<string, int> ids) {

            if (int.TryParse(content, out int result)) {
                number = result;
                formula = null;
                formulaResult = null;

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

                if (ids.ContainsKey(id)) {
                    ids.Remove(id);
                }
            }
            else {
                number = null;
                formula = null;
                formulaResult = null;

                if (ids.ContainsKey(id)) {
                    ids.Remove(id);
                }
            }
            return this;
        }

        public Cell Calculate(Dictionary<string, int> ids) {

            if (!string.IsNullOrWhiteSpace(formula)) {
                try {
                    if (Calculator.Evaluate(formula, ids) == 1.0) {
                        formulaResult = true;
                    }
                    else {
                        formulaResult = false;
                    }
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
            return "";
        }

        public string ShowUnfocused() {

            if (!string.IsNullOrWhiteSpace(formula)) {
                return formulaResult.ToString();
            }
            else if (number != null) {
                formula = null;
                formulaResult = null;
                return number.ToString();
            }
            else {
                number = null;
                
            }
            return "";
        }

    }
}
