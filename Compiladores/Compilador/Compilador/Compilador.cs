namespace Compilador;

public class Compilador
{
    public string Input { get; set; }
    public Token? CurrentToken { get => _sintatico.CurrentToken; }

    private Lexico _lexico;
    private Sintatico _sintatico = new();
    private Semantico _semantico = new();

    public Compilador(string input)
    {
        _lexico = new Lexico(input);
    }

    public void Compilar()
    {
        _sintatico.Parse(_lexico, _semantico);
    }
}