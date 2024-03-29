using System.Collections;
using Compilador.Constantes;

namespace Compilador;

public class Sintatico
{
    private readonly Stack _stack = new();
    public Token? CurrentToken { get; set; }
    private Token? _previousToken;
    private Lexico _scanner;
    private Semantico _semanticAnalyser;

    private static bool IsTerminal(Classe x)
    {
        return (int)x < ParserConstants.FirstNonTerminal;
    }

    private static bool IsNonTerminal(Classe x)
    {
        return (int)x >= ParserConstants.FirstNonTerminal && (int)x < ParserConstants.FirstSemanticAction;
    }

    private static bool IsSemanticAction(int x)
    {
        return x >= ParserConstants.FirstSemanticAction;
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

            throw new SyntaticException(ParserConstants.ParserError[(int)x], CurrentToken.Position);
        }
            
        if (IsNonTerminal(x))
        {
            if (PushProduction((int)x, (int)a))
            {
                return false;
            }

            throw new SyntaticException(ParserConstants.ParserError[(int)x], CurrentToken.Position);
        }

        _semanticAnalyser.ExecuteAction((int)x - ParserConstants.FirstSemanticAction, _previousToken);
        return false;
    }

    private bool PushProduction(int topStack, int tokenInput)
    {
        var p = ParserConstants.ParserTable[topStack - ParserConstants.FirstNonTerminal][tokenInput - 1];
        
        if (p >= 0)
        {
            var production = ParserConstants.Productions[p];
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
        _stack.Push(ParserConstants.StartSymbol);

        CurrentToken = scanner.NextToken();

        while (!Step())
        {
        }
    }
}