using Compilador;
using Compilador.Exceptions;

var texto = File.ReadAllText(@"C:\Users\shinobu\Desktop\teste.txt");
Console.WriteLine(texto);
var lexico = new Lexico(texto);
var sintatico = new Sintatico();
var semantico = new Semantico();

try
{
    sintatico.Parse(lexico, semantico);
    File.WriteAllText(@"C:\Users\shinobu\Desktop\teste.il", string.Join('\n', semantico.Codigo));
}
catch (AnalysisException e)
{
    var substring = texto.Substring(0, e.Position);
    var linha = substring.Count(c => c == '\n') + 1;
    Console.WriteLine ($"Erro na linha {linha}: {e.Message}\n{sintatico.CurrentToken}");
    Console.WriteLine(e);
}