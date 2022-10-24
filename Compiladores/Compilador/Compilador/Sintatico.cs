using System.Collections;
using Compilador.Constantes;

namespace Compilador;

public class Sintatico
{
    private readonly Stack _stack = new Stack();
    public Token? CurrentToken { get; set; }
    private Token? _previousToken;
    private Lexico _scanner;
    private Semantico _semanticAnalyser;

    private static bool IsTerminal(Classe x)
    {
        return (int)x < ParserConstants.FIRST_NON_TERMINAL;
    }

    private static bool IsNonTerminal(Classe x)
    {
        return (int)x >= ParserConstants.FIRST_NON_TERMINAL && (int)x < ParserConstants.FIRST_SEMANTIC_ACTION;
    }

    private static bool IsSemanticAction(int x)
    {
        return x >= ParserConstants.FIRST_SEMANTIC_ACTION;
    }

    private bool Step()
    {
        if (CurrentToken is null)
        {
            var pos = 0;
            if (_previousToken is not null)
                pos = _previousToken.Position + _previousToken.Lexeme.Length;

            CurrentToken = new Token(Classe.Dollar, "$", pos);
        }

        var x = (Classe)_stack.Pop();
        var a = CurrentToken.Id;

        if (x == Classe.Epsilon)
        {
            return false;
        }
        else
        {
            if (IsTerminal(x))
            {
                if (x == a)
                {
                    if (_stack.Count == 0)
                    {
                        return true;
                    }

                    _previousToken = CurrentToken;
                    CurrentToken = _scanner.NextToken();
                    return false;
                }

                throw new SyntaticException(ParserConstants.PARSER_ERROR[(int)x], CurrentToken.Position);
            }
            
            if (IsNonTerminal(x))
            {
                if (PushProduction((int)x, (int)a))
                {
                    return false;
                }

                throw new SyntaticException(ParserConstants.PARSER_ERROR[(int)x], CurrentToken.Position);
            }

            _semanticAnalyser.ExecuteAction(x - ParserConstants.FIRST_SEMANTIC_ACTION, _previousToken);
            return false;
        }
    }

    private bool PushProduction(int topStack, int tokenInput)
    {
        var p = ParserConstants.PARSER_TABLE[topStack - ParserConstants.FIRST_NON_TERMINAL][tokenInput - 1];
        if (p >= 0)
        {
            var production = ParserConstants.PRODUCTIONS[p];
            //empilha a produção em ordem reversa
            for (var i = production.Length - 1; i >= 0; i--)
            {
                _stack.Push(production[i]);
            }

            return true;
        }

        return false;
    }

    public void Parse(Lexico scanner, Semantico semanticAnalyser)
    {
        this._scanner = scanner;
        this._semanticAnalyser = semanticAnalyser;

        _stack.Clear();
        _stack.Push((int)Classe.Dollar);
        _stack.Push(ParserConstants.START_SYMBOL);

        CurrentToken = scanner.NextToken();

        while (!Step())
        {
        }
    }
}