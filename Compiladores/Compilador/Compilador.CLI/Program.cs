using Compilador;

var texto =
    "fun main { var lado: int; readln (\"digite o lado do quadrado: \", lado) area = lado * lado; print area); }";
var compilador = new Compilador.Compilador(texto);

try
{
    compilador.Compilar();
}
catch (SyntaticException e)
{
    var substring = texto.Substring(0, e.Position);
    var linha = substring.Count(c => c == '\n') + 1;
    Console.WriteLine(
        $"Erro na linha {linha}: encontrado {compilador.CurrentToken?.Lexeme} {e.Message}"
    );
}