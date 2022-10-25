namespace Compilador;

public class Compilador
{
    public string Input { get; set; }
    public Token? CurrentToken { get => _sintatico.CurrentToken; }

    private Lexico _lexico = new();
    private Sintatico _sintatico = new();
    private Semantico _semantico = new();

    public void Compilar()
    {
        _lexico.Input = Input;
        _sintatico.Parse(_lexico, _semantico);
    }
}