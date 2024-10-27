using Antlr4.Runtime.Misc;

namespace Calculator {
    internal class CellCraftCalculatorVisitor : CellCraftCalculatorBaseVisitor<double> {

        private readonly Dictionary<string, int> identificators;

        public CellCraftCalculatorVisitor(Dictionary<string, int> identificators) {
            this.identificators = identificators;
        }

        public override double VisitCompileUnit([NotNull] CellCraftCalculatorParser.CompileUnitContext context) {
            return Visit(context.expression());
        }

        public override double VisitCompareExpr([NotNull] CellCraftCalculatorParser.CompareExprContext context) {
            double left = VisitOperand(context.operand(0));
            double right = VisitOperand(context.operand(1));
            var op = context.operatorToken.Type;

            return EvaluateComparison(left, right, op) ? 1.0 : 0.0;
        }

        private bool EvaluateComparison(double left, double right, dynamic op) {
            return op switch {
                CellCraftCalculatorLexer.OP_EQUAL => left == right,
                CellCraftCalculatorLexer.OP_NOT_EQUAL => left != right,
                CellCraftCalculatorLexer.OP_LESS => left < right,
                CellCraftCalculatorLexer.OP_GREATER => left > right,
                CellCraftCalculatorLexer.OP_LESS_EQUAL => left <= right,
                CellCraftCalculatorLexer.OP_GREATER_EQUAL => left >= right,
                _ => throw new NotImplementedException(),
            };
        }

        public override double VisitOperand([NotNull] CellCraftCalculatorParser.OperandContext context) {
            return Visit(context);
        }

        public override double VisitNumberOperand([NotNull] CellCraftCalculatorParser.NumberOperandContext context) {
            return double.Parse(context.GetText());
        }

        public override double VisitIdentifierOperand([NotNull] CellCraftCalculatorParser.IdentifierOperandContext context) {
            string result = context.GetText();
            if (identificators.TryGetValue(result, out int value)) {
                return value;
            }
            else {
                throw new ArgumentException($"Wrong identifier. Actual is {result}.");
            }
        }

        public override double VisitAdditiveOperand([NotNull] CellCraftCalculatorParser.AdditiveOperandContext context) {
            double left = Visit(context.operand(0));
            double right = Visit(context.operand(1));

            if (context.operatorToken.Type == CellCraftCalculatorLexer.OP_ADD) {
                return left + right;
            }
            else {
                return left - right;
            }
        }

        public override double VisitMultiplicativeOperand([NotNull] CellCraftCalculatorParser.MultiplicativeOperandContext context) {
            double left = Visit(context.operand(0));
            double right = Visit(context.operand(1));

            if (context.operatorToken.Type == CellCraftCalculatorLexer.OP_MULTIPLY) {
                return left * right;
            }
            else {
                if (right == 0) {
                    throw new DivideByZeroException("Divide by zero. ");
                }
                return left / right;
            }
        }

        public override double VisitExponentialOperand([NotNull] CellCraftCalculatorParser.ExponentialOperandContext context) {
            double left = Visit(context.operand(0));
            double right = Visit(context.operand(1));

            return Math.Pow(left, right);
        }

        public override double VisitIncrementOperand([NotNull] CellCraftCalculatorParser.IncrementOperandContext context) {
            double number = Visit(context.operand());
            if (context.operatorToken.Type == CellCraftCalculatorLexer.OP_INC) {
                return number + 1;
            }
            else {
                return number - 1;
            }
        }

        public override double VisitParenthesizedOperand([NotNull] CellCraftCalculatorParser.ParenthesizedOperandContext context) {
            return Visit(context.operand());
        }
    }
}