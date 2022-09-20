using Compilador.Exceptions;

namespace Compilador;

public class SemanticException : AnalysisException
{
    public SemanticException(string msg, int position) : base(msg, position)
    {
    }

    public SemanticException(string msg) : base(msg)
    {
    }
}