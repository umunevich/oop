using Antlr4.Runtime;

namespace Calculator {
    public class Calculator {

        public static double Evaluate(string? expression, Dictionary<string, int> identificators) {

            var lexer = new CellCraftCalculatorLexer(new AntlrInputStream(expression));

            lexer.RemoveErrorListeners();
            lexer.AddErrorListener(new ThrowExceptionErrorListener());

            var tokens = new CommonTokenStream(lexer);
            var parser = new CellCraftCalculatorParser(tokens);

            var tree = parser.compileUnit();

            var visitor = new CellCraftCalculatorVisitor(identificators);

            return visitor.VisitCompileUnit(tree);
        }
    }
}