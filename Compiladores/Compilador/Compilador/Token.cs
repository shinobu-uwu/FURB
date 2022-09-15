namespace Compilador;

public class Token
{
    public Classe Id { get; set; }
    public string Lexeme { get; set; }
    public int Position { get; set; }

    public Token(Classe id, string lexeme, int position)
    {
        Id = id;
        Lexeme = lexeme;
        Position = position;
    }

    public override string ToString()
    {
        return $"{Id} ({Lexeme}) @ {Position}";
    }
}