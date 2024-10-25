using Antlr4.Runtime.Misc;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator {
    internal class CellCraftCalculatorVisitor : CellCraftCalculatorBaseVisitor<double> {
        Dictionary<string, double> tableIdentifier = new Dictionary<string, double>();

        public override double VisitCompileUnit([NotNull] CellCraftCalculatorParser.CompileUnitContext context) {
            return VisitExpression(context.expression());
        }

        public override double VisitExpression([NotNull] CellCraftCalculatorParser.ExpressionContext context) {
            var left = VisitOperand(context.operand(0));
            var right = VisitOperand(context.operand(1));
            var op = context.operatorToken.Type;

            if (!EvaluateComparison(left, right, op)) {
                return 0.0;
            }  
            return 1.0;
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
            var result = double.Parse(context.GetText());
            Debug.WriteLine(result);
            return result;
        }

        public override double VisitIdentifierOperand([NotNull] CellCraftCalculatorParser.IdentifierOperandContext context) {
            var result = context.GetText();
            double value;

            if (tableIdentifier.TryGetValue(result.ToString(), out value)) {
                return value;
            }
            else {
                return 0.0;
            }
        }

        public override double VisitAdditiveOperand([NotNull] CellCraftCalculatorParser.AdditiveOperandContext context) {
            double left = Visit(context.operand(0));
            double right = Visit(context.operand(1));

            if (context.operatorToken.Type == CellCraftCalculatorLexer.OP_ADD) {
                Debug.WriteLine("{0} + {1}", left, right);
                return left + right;
            }
            else {
                Debug.WriteLine("{0} - {1}", left, right);
                return left - right;
            }
        }

        public override double VisitMultiplicativeOperand([NotNull] CellCraftCalculatorParser.MultiplicativeOperandContext context) {
            double left = Visit(context.operand(0));
            double right = Visit(context.operand(1));

            if (context.operatorToken.Type == CellCraftCalculatorLexer.OP_MULTIPLY) {
                Debug.WriteLine("{0} x {1}", left, right);
                return left * right;
            }
            else {
                Debug.WriteLine("{0} / {1}", left, right);
                return left / right;
            }
        }
    }
}
