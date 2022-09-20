using Compilador.Exceptions;

namespace Compilador;

public class SyntaticException : AnalysisException
{
    public SyntaticException(string msg, int position) : base(msg, position)
    {
    }

    public SyntaticException(string msg) : base(msg)
    {
    }
}