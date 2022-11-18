namespace Compilador;

public class Semantico
{
    private Stack<string> _tipos = new();
    private List<string> _codigo = new();
    private string _operador;

    public void ExecuteAction(int action, Token token)
    {
        string tipo;
        string tipo1;
        string tipo2;

        switch (action)
        {
            case 1:
                ComparaTiposAritmeticos();
                _codigo.Add("add");
                break;
            case 2:
                ComparaTiposAritmeticos();
                _codigo.Add("sub");
                break;
            case 3:
                ComparaTiposAritmeticos();
                _codigo.Add("mul");
                break;
            case 4:
                tipo1 = _tipos.Pop();
                tipo2 = _tipos.Pop();

                if (tipo1 != tipo2)
                {
                    throw new SemanticException("tipos incompatíveis em expressão aritmética");
                }

                _tipos.Push(tipo1);
                _codigo.Add("div");
                break;
            case 5:
                _tipos.Push("int64");
                _codigo.Add($"ldc.i8 {token.Lexeme}");
                _codigo.Add("conv.r8");
                break;
            case 6:
                _tipos.Push("float64");
                _codigo.Add($"ldc.r8 {token.Lexeme}");
                break;
            case 7:
                ValidaTipoNumerico();
                break;
            case 8:
                ValidaTipoNumerico();
                _codigo.Add("ldc.i8 -1");
                _codigo.Add("conv.r8");
                _codigo.Add("mul");
                break;
            case 9:
                _operador = token.Lexeme;
                break;
            case 10:
                tipo1 = _tipos.Pop();
                tipo2 = _tipos.Pop();

                if (tipo1 != tipo2)
                {
                    throw new SemanticException("tipos incompatíveis em expressão aritmética");
                }

                _tipos.Push("bool");

                switch (_operador)
                {
                    case ">":
                        _codigo.Add("cgt");
                        break;
                    case "<":
                        _codigo.Add("clt");
                        break;
                    case "==":
                        _codigo.Add("ceq");
                        break;
                }

                break;
            case 11:
                _tipos.Push("bool");
                _codigo.Add("ldc.i4.1");
                break;
            case 12:
                _tipos.Push("bool");
                _codigo.Add("ldc.i4.0");
                break;
            case 13:
                tipo = _tipos.Pop();

                if (tipo != "bool")
                {
                    throw new SemanticException("tipo incompatível em expressão lógica");
                }

                _tipos.Push("bool");
                _codigo.Add("ldc.i4.1");
                _codigo.Add("xor");
                break;
            case 14:
                tipo = _tipos.Pop();
                if (tipo == "int64")
                {
                    _codigo.Add("conv.i8");
                }
                _codigo.Add($"call void [mscorlib] System.Console::Write({tipo})");
                break;
            case 15:
                _codigo.Add(".assembly extern mscorlib {}");
                _codigo.Add(".assembly _codigo_objeto {}");
                _codigo.Add(".module _codigo_objeto.exe");
                _codigo.Add(".class public _UNICA {");
                _codigo.Add(".method static public void _principal() {");
                _codigo.Add(".entrypoint");
                break;
            case 16:
                _codigo.Add("ret");
                _codigo.Add("}");
                _codigo.Add("}");
                break;
        }
    }

    private void ValidaTipoNumerico()
    {
        var tipo = _tipos.Pop();

        if (tipo != "float64" && tipo != "int64")
        {
            throw new SemanticException("tipos incompatíveis em expressão aritmética");
        }

        _tipos.Push(tipo);
    }

    private void ComparaTiposAritmeticos()
    {
        var tipo1 = _tipos.Pop();
        var tipo2 = _tipos.Pop();

        if (tipo1 == "float64" || tipo2 == "float64")
        {
            _tipos.Push("float64");
        }
        else
        {
            _tipos.Push("int64");
        }
    }
}