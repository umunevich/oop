grammar CellCraftCalculator;

/*
*	PARSER RULES 
*/

compileUnit : expression EOF ;

expression: 
	operand operatorToken=(OP_EQUAL | OP_LESS | OP_GREATER | OP_LESS_EQUAL | OP_GREATER_EQUAL | OP_NOT_EQUAL) operand #CompareExpr	;

operand : 
	LPAREN operand RPAREN #ParenthesizedOperand
	| operand operatorToken=(OP_ADD | OP_SUBTRACT) operand #AdditiveOperand
	| operand operatorToken=(OP_MULTIPLY | OP_DIVIDE) operand #MultiplicativeOperand
	| operand OP_EXPONENT operand #ExponentialOperand
	| operand operatorToken=(OP_INC | OP_DEC) #IncrementOperand
	| NUMBER #NumberOperand
	| IDENTIFIER #IdentifierOperand
	;

/*
*	LEXER RULES 
*/

NUMBER : INTEGER ('.'INTEGER)?;
IDENTIFIER : [A-Z]+ [1-9][0-9]+ ;

INTEGER : [0-9]+ ;

// Variant 42

// 1
OP_ADD : '+' ;
OP_SUBTRACT : '-' ;
OP_MULTIPLY : '*' ;
OP_DIVIDE : '/' ;

// 4
OP_EXPONENT : '^' ;

// 5
OP_INC : '++' ;
OP_DEC : '--' ;

// 8
OP_EQUAL : '==' ;
OP_LESS : '<' ;
OP_GREATER : '>' ;

// 9
OP_LESS_EQUAL : '<=' ;
OP_GREATER_EQUAL : '>=' ;
OP_NOT_EQUAL : '<>' ;

LPAREN : '(' ;
RPAREN : ')' ;

WS : [ \t\r\n]+ -> skip ;
