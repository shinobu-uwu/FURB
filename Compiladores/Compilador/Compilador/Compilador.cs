namespace Compilador;

public class Compilador
{
    public string Input { get; set; }

    public IEnumerable<Token?> AnaliseLexica()
    {
        var lexico = new Lexico(Input);
        var tokens = new List<Token?>();
        Token? t;

        while ((t = lexico.NextToken()) is not null)
        {
            tokens.Add(t);
        }

        return tokens;
    }
}