using Compilador.Constantes;

namespace Compilador.Utils;

public static class FormatadorClasse
{
    public static string FormataClasse(Classe classe)
    {
        if (classe >= Classe.Boolean && classe <= Classe.While)
        {
            return "Palavra reservada";
        }

        if (classe >= Classe.Token27 && classe <= Classe.Token48)
        {
            return "Símbolo especial";
        }

        if (classe == Classe.Identificador)
        {
            return "Identificador";
        }

        if (classe == Classe.ConstanteInt)
        {
            return "Constante Int";
        }

        if (classe == Classe.ConstanteFloat)
        {
            return "Constante Float";
        }

        if (classe == Classe.ConstanteChar)
        {
            return "Constante Char";
        }

        if (classe == Classe.ConstanteString)
        {
            return "Constante String";
        }

        return "";
    }
}