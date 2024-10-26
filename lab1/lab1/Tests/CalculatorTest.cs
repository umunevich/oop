namespace Tests {
    using System.Data;
    using Xunit.Sdk;
    using Calculator = Calculator.Calculator;
    using ThrowExceptionErrorListener = Calculator.ThrowExceptionErrorListener;
    using Table = Table.Models.Table;
    public class CalculatorTest {

        [Theory]
        [InlineData("3 < 5", 1.0)]
        [InlineData("2 + 8 * 2 <> 4", 1.0)]
        [InlineData("2 >= 2", 1.0)]
        [InlineData("1 + 1 / 3 >= 1 + 1 / 4", 1.0)]
        [InlineData("(3 + 4) * 2 <= 2", 0.0)]
        [InlineData("3++ >= 4", 1.0)]
        [InlineData("4 ^ 3 == 64", 1.0)]

        public void TestComparisons(string formula, double expected) {
            double result = Calculator.Evaluate(formula);
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("4 / 0 <> 3")]
        [InlineData("2 + 3 > 3 / (6 - (2 * 3))")]
        [InlineData("3 / (0 ^ 2) == 3")]
        public void TestDivideByZero(string formula) {
            var exception = Assert.Throws<DivideByZeroException>(() => Calculator.Evaluate(formula));   
        }

        /*[Theory]
        [InlineData("4 + 5")]
        [InlineData("10 * 4 > 3 > 1")]
        public void TestVisitor(string formula) {
            var exception = Assert.Throws<NullReferenceException>(() => Calculator.Evaluate(formula));
        }*/
    }
}