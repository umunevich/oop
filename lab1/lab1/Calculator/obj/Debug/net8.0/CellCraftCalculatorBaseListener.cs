//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     ANTLR Version: 4.6.6
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from D:\Learning\University2\OOP\oop repo\lab1\lab1\Calculator\CellCraftCalculator.g4 by ANTLR 4.6.6

// Unreachable code detected
#pragma warning disable 0162
// The variable '...' is assigned but its value is never used
#pragma warning disable 0219
// Missing XML comment for publicly visible type or member '...'
#pragma warning disable 1591
// Ambiguous reference in cref attribute
#pragma warning disable 419

namespace Calculator {

using Antlr4.Runtime.Misc;
using IErrorNode = Antlr4.Runtime.Tree.IErrorNode;
using ITerminalNode = Antlr4.Runtime.Tree.ITerminalNode;
using IToken = Antlr4.Runtime.IToken;
using ParserRuleContext = Antlr4.Runtime.ParserRuleContext;

/// <summary>
/// This class provides an empty implementation of <see cref="ICellCraftCalculatorListener"/>,
/// which can be extended to create a listener which only needs to handle a subset
/// of the available methods.
/// </summary>
[System.CodeDom.Compiler.GeneratedCode("ANTLR", "4.6.6")]
[System.CLSCompliant(false)]
public partial class CellCraftCalculatorBaseListener : ICellCraftCalculatorListener {
	/// <summary>
	/// Enter a parse tree produced by the <c>MultiplicativeExpr</c>
	/// labeled alternative in <see cref="CellCraftCalculatorParser.expression"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterMultiplicativeExpr([NotNull] CellCraftCalculatorParser.MultiplicativeExprContext context) { }
	/// <summary>
	/// Exit a parse tree produced by the <c>MultiplicativeExpr</c>
	/// labeled alternative in <see cref="CellCraftCalculatorParser.expression"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitMultiplicativeExpr([NotNull] CellCraftCalculatorParser.MultiplicativeExprContext context) { }

	/// <summary>
	/// Enter a parse tree produced by the <c>IncrementExpr</c>
	/// labeled alternative in <see cref="CellCraftCalculatorParser.expression"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterIncrementExpr([NotNull] CellCraftCalculatorParser.IncrementExprContext context) { }
	/// <summary>
	/// Exit a parse tree produced by the <c>IncrementExpr</c>
	/// labeled alternative in <see cref="CellCraftCalculatorParser.expression"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitIncrementExpr([NotNull] CellCraftCalculatorParser.IncrementExprContext context) { }

	/// <summary>
	/// Enter a parse tree produced by the <c>ExponentialExpr</c>
	/// labeled alternative in <see cref="CellCraftCalculatorParser.expression"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterExponentialExpr([NotNull] CellCraftCalculatorParser.ExponentialExprContext context) { }
	/// <summary>
	/// Exit a parse tree produced by the <c>ExponentialExpr</c>
	/// labeled alternative in <see cref="CellCraftCalculatorParser.expression"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitExponentialExpr([NotNull] CellCraftCalculatorParser.ExponentialExprContext context) { }

	/// <summary>
	/// Enter a parse tree produced by the <c>AdditiveExpr</c>
	/// labeled alternative in <see cref="CellCraftCalculatorParser.expression"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterAdditiveExpr([NotNull] CellCraftCalculatorParser.AdditiveExprContext context) { }
	/// <summary>
	/// Exit a parse tree produced by the <c>AdditiveExpr</c>
	/// labeled alternative in <see cref="CellCraftCalculatorParser.expression"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitAdditiveExpr([NotNull] CellCraftCalculatorParser.AdditiveExprContext context) { }

	/// <summary>
	/// Enter a parse tree produced by the <c>CompareExpr</c>
	/// labeled alternative in <see cref="CellCraftCalculatorParser.expression"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterCompareExpr([NotNull] CellCraftCalculatorParser.CompareExprContext context) { }
	/// <summary>
	/// Exit a parse tree produced by the <c>CompareExpr</c>
	/// labeled alternative in <see cref="CellCraftCalculatorParser.expression"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitCompareExpr([NotNull] CellCraftCalculatorParser.CompareExprContext context) { }

	/// <summary>
	/// Enter a parse tree produced by the <c>NumberExpr</c>
	/// labeled alternative in <see cref="CellCraftCalculatorParser.expression"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterNumberExpr([NotNull] CellCraftCalculatorParser.NumberExprContext context) { }
	/// <summary>
	/// Exit a parse tree produced by the <c>NumberExpr</c>
	/// labeled alternative in <see cref="CellCraftCalculatorParser.expression"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitNumberExpr([NotNull] CellCraftCalculatorParser.NumberExprContext context) { }

	/// <summary>
	/// Enter a parse tree produced by the <c>IdentifierExpr</c>
	/// labeled alternative in <see cref="CellCraftCalculatorParser.expression"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterIdentifierExpr([NotNull] CellCraftCalculatorParser.IdentifierExprContext context) { }
	/// <summary>
	/// Exit a parse tree produced by the <c>IdentifierExpr</c>
	/// labeled alternative in <see cref="CellCraftCalculatorParser.expression"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitIdentifierExpr([NotNull] CellCraftCalculatorParser.IdentifierExprContext context) { }

	/// <summary>
	/// Enter a parse tree produced by the <c>ParenthesizedExpr</c>
	/// labeled alternative in <see cref="CellCraftCalculatorParser.expression"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterParenthesizedExpr([NotNull] CellCraftCalculatorParser.ParenthesizedExprContext context) { }
	/// <summary>
	/// Exit a parse tree produced by the <c>ParenthesizedExpr</c>
	/// labeled alternative in <see cref="CellCraftCalculatorParser.expression"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitParenthesizedExpr([NotNull] CellCraftCalculatorParser.ParenthesizedExprContext context) { }

	/// <summary>
	/// Enter a parse tree produced by <see cref="CellCraftCalculatorParser.compileUnit"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterCompileUnit([NotNull] CellCraftCalculatorParser.CompileUnitContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="CellCraftCalculatorParser.compileUnit"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitCompileUnit([NotNull] CellCraftCalculatorParser.CompileUnitContext context) { }

	/// <summary>
	/// Enter a parse tree produced by <see cref="CellCraftCalculatorParser.expression"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterExpression([NotNull] CellCraftCalculatorParser.ExpressionContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="CellCraftCalculatorParser.expression"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitExpression([NotNull] CellCraftCalculatorParser.ExpressionContext context) { }

	/// <inheritdoc/>
	/// <remarks>The default implementation does nothing.</remarks>
	public virtual void EnterEveryRule([NotNull] ParserRuleContext context) { }
	/// <inheritdoc/>
	/// <remarks>The default implementation does nothing.</remarks>
	public virtual void ExitEveryRule([NotNull] ParserRuleContext context) { }
	/// <inheritdoc/>
	/// <remarks>The default implementation does nothing.</remarks>
	public virtual void VisitTerminal([NotNull] ITerminalNode node) { }
	/// <inheritdoc/>
	/// <remarks>The default implementation does nothing.</remarks>
	public virtual void VisitErrorNode([NotNull] IErrorNode node) { }
}
} // namespace Calculator