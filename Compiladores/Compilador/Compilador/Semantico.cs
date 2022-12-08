namespace Compilador;

public class Semantico
{
    private const string Int = "int64";
    private const string Float = "float64";
    private const string Char = "char";
    private const string String = "string";
    private const string Boolean = "bool";

    private Stack<string> _tipos = new();
    public List<string> Codigo = new();
    private Dictionary<string, string> _tabelaSimbolos = new();
    private string _operador = "";
    private string _tipoVar = "";
    private Stack<string> _rotulos = new();
    private List<string> _identificadores = new();
    private int _indice = 1;

    public void ExecuteAction(int action, Token token)
    {
        string tipo;
        string tipo1;
        string tipo2;
        string resultado;
        string rotulo;
        int i;

        switch (action)
        {
            case 1:
                ComparaTiposAritmeticos(token);
                Codigo.Add("add");
                break;
            case 2:
                ComparaTiposAritmeticos(token);
                Codigo.Add("sub");
                break;
            case 3:
                ComparaTiposAritmeticos(token);
                Codigo.Add("mul");
                break;
            case 4:
                tipo1 = _tipos.Pop();
                tipo2 = _tipos.Pop();

                if (tipo1 != tipo2)
                {
                    throw new SemanticException("tipos incompatíveis em expressão aritmética");
                }

                _tipos.Push(tipo1);
                Codigo.Add("div");
                break;
            case 5:
                _tipos.Push(Int);
                i = token.Lexeme.IndexOf('d');
                resultado = token.Lexeme;

                if (i != -1)
                {
                    var n1 = token.Lexeme.Substring(0, i);
                    var n2 = token.Lexeme.Substring(i + 1);
                    resultado = (int.Parse(n1) * Math.Pow(10, int.Parse(n2))).ToString();
                }

                Codigo.Add($"ldc.i8 {resultado}");
                Codigo.Add("conv.r8");
                break;
            case 6:
                _tipos.Push(Float);
                i = token.Lexeme.IndexOf('d');
                resultado = token.Lexeme;

                if (i != -1)
                {
                    var n1 = token.Lexeme.Substring(0, i);
                    var n2 = token.Lexeme.Substring(i + 1);
                    resultado = (double.Parse(n1) * Math.Pow(10, double.Parse(n2))).ToString();
                }

                Codigo.Add($"ldc.r8 {token.Lexeme}");
                break;
            case 7:
                ValidaTipoNumerico();
                break;
            case 8:
                ValidaTipoNumerico();
                Codigo.Add("ldc.i8 -1");
                Codigo.Add("conv.r8");
                Codigo.Add("mul");
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

                _tipos.Push(Boolean);

                switch (_operador)
                {
                    case ">":
                        Codigo.Add("cgt");
                        break;
                    case "<":
                        Codigo.Add("clt");
                        break;
                    case "==":
                        Codigo.Add("ceq");
                        break;
                }

                break;
            case 11:
                _tipos.Push(Boolean);
                Codigo.Add("ldc.i4.1");
                break;
            case 12:
                _tipos.Push(Boolean);
                Codigo.Add("ldc.i4.0");
                break;
            case 13:
                tipo = _tipos.Pop();

                if (tipo != Boolean)
                {
                    throw new SemanticException("tipo incompatível em expressão lógica");
                }

                _tipos.Push(Boolean);
                Codigo.Add("ldc.i4.1");
                Codigo.Add("xor");
                break;
            case 14:
                tipo = _tipos.Pop();

                if (tipo == Int)
                {
                    Codigo.Add("conv.i8");
                }

                Codigo.Add($"call void [mscorlib] System.Console::Write({tipo})");
                break;
            case 15:
                Codigo.Add(".assembly extern mscorlib {}");
                Codigo.Add(".assembly _codigo_objeto {}");
                Codigo.Add(".module _codigo_objeto.exe");
                Codigo.Add(".class public _UNICA {");
                Codigo.Add(".method static public void _principal() {");
                Codigo.Add(".entrypoint");
                break;
            case 16:
                Codigo.Add("ret");
                Codigo.Add("}");
                Codigo.Add("}");
                break;
            case 17:
                Codigo.Add("ldstr \"\\n\"");
                Codigo.Add("call void [mscorlib]System.Console::Write(string)");
                break;
            case 18:
                tipo1 = _tipos.Pop();
                tipo2 = _tipos.Pop();

                if (tipo1 != Boolean && tipo2 != Boolean)
                {
                    throw new SemanticException("Tipos incompatíveis", token.Position);
                }

                Codigo.Add("and");
                break;
            case 19:
                tipo1 = _tipos.Pop();
                tipo2 = _tipos.Pop();

                if (tipo1 != Boolean && tipo2 != Boolean)
                {
                    throw new SemanticException("Tipos incompatíveis", token.Position);
                }

                Codigo.Add("or");
                break;
            case 20:
                tipo1 = _tipos.Pop();
                tipo2 = _tipos.Pop();

                if (tipo1 != Int || tipo2 != Int)
                {
                    throw new SemanticException("Tipos incompatíveis", token.Position);
                }

                Codigo.Add("div");
                Codigo.Add("conv.i8");
                break;
            case 21:
                _tipos.Push(Char);
                var caracter = token.Lexeme != @"\s" ? token.Lexeme : " ";
                Codigo.Add($"ldstr \"{caracter}\"");
                break;
            case 22:
                _tipos.Push(String);
                Codigo.Add($"ldstr {token.Lexeme}");
                break;
            case 24:
                Codigo.Add($"brfalse novo_rotulo_{_indice}");
                _rotulos.Push($"novo_rotulo_{_indice}");
                _indice++;
                break;
            case 25:
                rotulo = _rotulos.Pop();
                Codigo.Add($"br novo_rotulo_{_indice}");
                Codigo.Add($"{rotulo}:");
                _rotulos.Push($"novo_rotulo_{_indice}");
                _indice++;
                break;
            case 26:
                rotulo = _rotulos.Pop();
                Codigo.Add($"{rotulo}:");
                break;
            case 27:
                rotulo = $"novo_rotulo_{_indice}";
                Codigo.Add($"{rotulo}:");
                _rotulos.Push(rotulo);
                break;
            case 28:
                rotulo = _rotulos.Pop();
                Codigo.Add($"brtrue {rotulo}");
                break;
            case 30:
                _tipoVar = ConverteNomeTipos(token.Lexeme);
                break;
            case 31:
                foreach (var identificador in _identificadores)
                {
                    Codigo.Add($".locals ({_tipoVar} {identificador})");
                    _tabelaSimbolos[identificador] = _tipoVar;
                }

                _identificadores.Clear();
                break;
            case 32:
                _identificadores.Add(token.Lexeme);
                break;
            case 33:
                Codigo.Add($"ldloc {token.Lexeme}");
                tipo = _tabelaSimbolos[token.Lexeme];
                _tipos.Push(tipo);

                if (tipo == Int)
                {
                    Codigo.Add("conv.r8");
                }

                break;
            case 34:
            {
                var identificador = _identificadores[0];
                _identificadores.RemoveAt(0);
                tipo = _tipos.Pop();

                if (tipo == Int)
                {
                    Codigo.Add("conv.i8");
                }

                Codigo.Add($"stloc {identificador}");
                break;
            }
            case 35:
                foreach (var identificador in _identificadores)
                {
                    tipo = _tabelaSimbolos[identificador];
                    Codigo.Add("call string [mscorlib]System.Console::ReadLine()");

                    if (tipo is Boolean or Int or Float)
                    {
                        var classe = ConverteTipoParaClasse(tipo);
                        Codigo.Add($"call {tipo} [mscorlib]System.{classe}::Parse(string)");
                    }

                    Codigo.Add($"stloc {identificador}");
                }

                _identificadores.Clear();
                break;
        }
    }

    private string ConverteTipoParaClasse(string tipo)
    {
        return tipo switch
        {
            Boolean => "Boolean",
            Int => "Int64",
            Float => "Double",
            _ => throw new Exception("Tipo não reconhecido")
        };
    }

    private void ValidaTipoNumerico()
    {
        var tipo = _tipos.Pop();

        if (tipo != Float && tipo != Int)
        {
            throw new SemanticException("tipos incompatíveis em expressão aritmética");
        }

        _tipos.Push(tipo);
    }

    private void ComparaTiposAritmeticos(Token token)
    {
        var tipo1 = _tipos.Pop();
        var tipo2 = _tipos.Pop();

        if ((tipo1 != Int && tipo1 != Float) || (tipo2 != Int && tipo2 != Float))
        {
            throw new SemanticException("Operando de tipos incompatíveis", token.Position);
        }

        if (tipo1 == Float || tipo2 == Float)
        {
            _tipos.Push(Float);
        }
        else
        {
            _tipos.Push(Int);
        }
    }

    private string ConverteNomeTipos(string tipo)
    {
        return tipo switch
        {
            "int" => Int,
            "float" => Float,
            "char" => Char,
            "string" => String,
            "bool" => Boolean,
            _ => throw new Exception("Tipo não reconhecido")
        };
    }
}