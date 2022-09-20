using Compilador;
using Compilador.Utils;

var texto = @"
[
isso é um comentário
]
break area (
1.1d10";
var compilador = new Lexico(texto);
Token t;

while ((t = compilador.NextToken()) != null)
{
    var substring = texto.Substring(0, t.Position);
    var linha = substring.Count(c => c == '\n') + 1;
    var classe = FormatadorClasse.FormataClasse(t.Id);

    Console.WriteLine($"{linha} {classe} {t.Lexeme}");
}