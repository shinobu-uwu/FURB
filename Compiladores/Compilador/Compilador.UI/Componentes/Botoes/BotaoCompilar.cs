namespace Compilador.UI.Componentes.Botoes;

public sealed class BotaoCompilar : BotaoBarraFerramentas
{
    public BotaoCompilar()
    {
        Text = "Compilar";
        ToolTipText = "Compilar arquivo (F7)";
    }

    protected override void OnClick(EventArgs e)
    {
        base.OnClick(e);

        var form = FormPrincipal.GetInstancia();
        var lexico = form.Lexico;

        try
        {
            Token t;
            while ((t = lexico.NextToken()) is not null)
            {
                var substring = form.TextoEditor.Text.Substring(0, t.Position);
                var linha = substring.Count(c => c == '\n') + 1;

                form.AreaMensagens.EscreverMensagem($"{linha} {t.Id} {t.Lexeme}");
            }
        }
        catch (LexicalError e)
        {
            var substring = form.TextoEditor.Text.Substring(0, e.Position);
            var linha = substring.Count(c => c == '\n') + 1;
            form.AreaMensagens.EscreverMensagem($"Erro na linha {linha}: {e.Message}");

            return;
        }

        form.AreaMensagens.EscreverMensagem("Programa compilado com sucesso");
    }
}