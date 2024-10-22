grammar CellCraftCalculator;

/*
*	PARSER RULES 
*/

compileUnit : expression EOF ;

expression: 
	LPAREN expression RPAREN #ParenthesizedExpr
	| expression operatorToken=(OP_ADD | OP_SUBTRACT) expression #AdditiveExpr
	| expression operatorToken=(OP_MULTIPLY | OP_DIVIDE) expression #MultiplicativeExpr
	| expression OP_EXPONENT expression #ExponentialExpr
	| expression operatorToken=(OP_INC | OP_DEC) #IncrementExpr
	| expression operatorToken=(OP_EQUAL | OP_LESS | OP_GREATER | OP_LESS_EQUAL | OP_GREATER_EQUAL | OP_NOT_EQUAL) expression #CompareExpr
	| NUMBER #NumberExpr
	| IDENTIFIER #IdentifierExpr
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

WS : [\t\r\n]+ -> skip ;

