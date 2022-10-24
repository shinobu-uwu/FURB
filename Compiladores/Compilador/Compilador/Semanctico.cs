using Compilador.Constantes;

namespace Compilador;

public class Semantico
{
    public void ExecuteAction(Classe action, Token token)
    {
        Console.WriteLine("Ação #" + (int)action + ", Token: " + token);
    }
}