using Compilador;

var texto =
    "fun main {\n var lado: int;\n readln (\"digite o lado do quadrado: \", lado)\n area = lado * lado;\n print area);\n }";
var compilador = new Compilador.Compilador();

try
{
    compilador.Input = texto;
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