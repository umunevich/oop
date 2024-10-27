using Antlr4.Runtime.Misc;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Table;
namespace Calculator {
    using Table = Table.Models.Table;

    internal class CellCraftCalculatorVisitor : CellCraftCalculatorBaseVisitor<double> {

        private readonly Dictionary<string, int> identificators;
        public CellCraftCalculatorVisitor(Dictionary<string, int> ids) {
            identificators = ids;
        }
        public override double VisitCompileUnit([NotNull] CellCraftCalculatorParser.CompileUnitContext context) {
            return Visit(context.expression());
        }

        public override double VisitCompareExpr([NotNull] CellCraftCalculatorParser.CompareExprContext context) {
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
            Debug.WriteLine("tyt");
            string result = context.GetText();
            int value;
            if (identificators.TryGetValue(result, out value)) {
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
                if (right == 0) {
                    throw new DivideByZeroException("Divide by zero. ");
                }
                Debug.WriteLine("{0} / {1}", left, right);
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
