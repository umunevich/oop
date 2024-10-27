using Antlr4.Runtime;
using Antlr4.Runtime.Misc;
namespace Calculator {
    public class ThrowExceptionErrorListener : BaseErrorListener, IAntlrErrorListener<int> {
        public override void SyntaxError([NotNull] IRecognizer recognizer, [Nullable] IToken offendingSymbol, int line, int charPositionInLine, [NotNull] string msg, [Nullable] RecognitionException e) {  
            throw new ArgumentException($"Invalid Expression: {0}", msg, e);
        }

        public void SyntaxError(IRecognizer recognizer, int offendingSybol, int line, int charPositionInLine, string msg, RecognitionException e) {
            throw new ArgumentException($"Invalid Expression: {0}", msg, e);
        }
    }
}
