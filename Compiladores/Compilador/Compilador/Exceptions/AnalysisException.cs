namespace Compilador.Exceptions;

public class AnalysisException : Exception
{
    public int Position { get; set; }

    public AnalysisException(string msg, int position) : base(msg)
    {
        Position = position;
    }

    public AnalysisException(string msg) : base(msg)
    {
        Position = -1;
    }
}