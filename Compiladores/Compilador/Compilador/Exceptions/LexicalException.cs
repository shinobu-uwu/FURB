using Compilador.Exceptions;

namespace Compilador;

public class LexicalException : AnalysisException
{
    public LexicalException(string msg, int position) : base(msg, position)
    {
    }

    public LexicalException(string msg) : base(msg)
    {
    }
}