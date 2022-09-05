using Compilador;

var compilador = new Lexico("int a = 3;");
Token t;

while ((t = compilador.NextToken()) != null)
{
    Console.WriteLine(t.Id);
    Console.WriteLine(t.Lexeme);
    Console.WriteLine(t.Position);
    Console.WriteLine();
}