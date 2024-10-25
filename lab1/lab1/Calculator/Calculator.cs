using Antlr4.Runtime;
using Antlr4.Runtime.Misc;
using Calculator;
using System.Diagnostics;

namespace Calculator {
    public class Calculator {
        public static double Evaluate(string expression) {
            var lexer = new CellCraftCalculatorLexer(new AntlrInputStream(expression));

            lexer.RemoveErrorListeners();
            lexer.AddErrorListener(new ThrowExceptionErrorListener());

            var tokens = new CommonTokenStream(lexer);
            var parser = new CellCraftCalculatorParser(tokens);

            var tree = parser.compileUnit();

            var visitor = new CellCraftCalculatorVisitor();

            return visitor.VisitCompileUnit(tree);
        }
    }
}