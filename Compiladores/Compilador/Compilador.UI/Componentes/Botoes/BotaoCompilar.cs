using Compilador.Utils;

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
        var compilador = new Compilador();

        // Se o arquivo não estiver salvo mandamos o usuário salvar
        if (form.CaminhoArquivoAberto is null)
        {
            form.BarraFerramentas.BotaoSalvar.PerformClick();
        }

        try
        {
            compilador.Input = File.ReadAllText(form.CaminhoArquivoAberto);
            compilador.Compilar();
            form.AreaMensagens.EscreverMensagem("Programa compilado com sucesso");
        }
        catch (LexicalException exception)
        {
            var substring = form.TextoEditor.Text.Substring(0, exception.Position);
            var linha = substring.Count(c => c == '\n') + 1;
            form.AreaMensagens.EscreverMensagem($"Erro na linha {linha}: {exception.Message}");
        }
        catch (SyntaticException exception)
        {
            var substring = form.TextoEditor.Text.Substring(0, exception.Position);
            var linha = substring.Count(c => c == '\n') + 1;
            form.AreaMensagens.EscreverMensagem(
                $"Erro na linha {linha}: encontrado {compilador.CurrentToken?.Lexeme} esperado {exception.Message}"
            );
        }
        catch (ArgumentNullException) // Ignoramos se o usuário clicar cancelar no dialog de salvar
        {
        }
    }
}