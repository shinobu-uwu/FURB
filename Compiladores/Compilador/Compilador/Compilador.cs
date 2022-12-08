namespace Compilador;

public class Compilador
{
    public string Input { get; set; }
    public Token? CurrentToken { get => _sintatico.CurrentToken; }

    private Lexico _lexico;
    private Sintatico _sintatico = new();
    private Semantico _semantico = new();

    public string Compilar()
    {
        _lexico = new Lexico(Input);
        _sintatico.Parse(_lexico, _semantico);

        return string.Join('\n', _semantico.Codigo);
    }
}