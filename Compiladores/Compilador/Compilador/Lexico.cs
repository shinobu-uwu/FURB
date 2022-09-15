namespace Compilador;

public class Lexico
{
    private int Position;
    private string Input;

    public Lexico(string texto)
    {
        Input = texto;
        Position = 0;
    }

    public Lexico()
    {
        Position = 0;
    }

    public Token NextToken()
    {
        if (!HasInput())
            return null;

        var start = Position;

        var state = 0;
        var lastState = 0;
        var endState = -1;
        var end = -1;

        while (HasInput())
        {
            lastState = state;
            state = NextState(NextChar(), state);

            if (state < 0)
                break;

            if (TokenForState(state) < 0) continue;
            endState = state;
            end = Position;
        }

        if (endState < 0 || (endState != state && TokenForState(lastState) == -2))
            throw new LexicalError(ScannerConstants.ScannerError[lastState], start);

        Position = end;

        var token = TokenForState(endState);

        if (token == 0)
            return NextToken();
        else
        {
            var lexeme = Input.Substring(start, end - start);
            token = LookupToken(token, lexeme);
            return new Token((Classe) token, lexeme, start);
        }
    }

    private int NextState(char c, int state)
    {
        var start = ScannerConstants.ScannerTableIndexes[state];
        var end = ScannerConstants.ScannerTableIndexes[state + 1] - 1;

        while (start <= end)
        {
            var half = (start + end) / 2;

            if (ScannerConstants.ScannerTable[half][0] == c)
                return ScannerConstants.ScannerTable[half][1];
            else if (ScannerConstants.ScannerTable[half][0] < c)
                start = half + 1;
            else //(SCANNER_TABLE[half][0] > c)
                end = half - 1;
        }

        return -1;
    }

    private int TokenForState(int state)
    {
        if (state < 0 || state >= ScannerConstants.TokenState.Length)
            return -1;

        return ScannerConstants.TokenState[state];
    }

    public int LookupToken(int child, string key)
    {
        var start = ScannerConstants.SpecialCasesIndexes[child];
        var end = ScannerConstants.SpecialCasesIndexes[child + 1] - 1;

        while (start <= end)
        {
            var half = (start + end) / 2;
            var comp = string.Compare(ScannerConstants.SpecialCasesKeys[half], key, StringComparison.Ordinal);

            if (comp == 0)
            {
                return ScannerConstants.SpecialCasesValues[half];
            }
            else if (comp < 0)
            {
                start = half + 1;
            }
            else //(comp > 0)
            {
                end = half - 1;
            }
        }

        return child;
    }

    private bool HasInput()
    {
        return Position < Input.Length;
    }

    private char NextChar()
    {
        if (HasInput())
            return Input[Position++];

        return unchecked((char) -1);
    }
}