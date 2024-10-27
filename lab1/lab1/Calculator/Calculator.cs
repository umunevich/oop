using Antlr4.Runtime;
using Antlr4.Runtime.Misc;
using Calculator;
using System.Diagnostics;

namespace Calculator {
    public class Calculator {
        public static double Evaluate(string? expression, Dictionary<string, int> ids) {
            var lexer = new CellCraftCalculatorLexer(new AntlrInputStream(expression));

            lexer.RemoveErrorListeners();
            lexer.AddErrorListener(new ThrowExceptionErrorListener());

            var tokens = new CommonTokenStream(lexer);
            var parser = new CellCraftCalculatorParser(tokens);

            var tree = parser.compileUnit();

            var visitor = new CellCraftCalculatorVisitor(ids);

            return visitor.VisitCompileUnit(tree);
        }
    }
}