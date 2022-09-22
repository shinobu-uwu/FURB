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

        // Se o arquivo não estiver salvo mandamos o usuário salvar
        if (form.CaminhoArquivoAberto is null)
        {
            form.BarraFerramentas.BotaoSalvar.PerformClick();
        }

        try
        {
            var compilador = form.Compilador;
            compilador.Input = File.ReadAllText(form.CaminhoArquivoAberto);
            var mensagem = $"{"Linha",-10} {"Classe",-30} {"Lexema",-20}\n";

            foreach (var token in compilador.AnaliseLexica())
            {
                var substring = form.TextoEditor.Text.Substring(0, token.Position);
                var linha = substring.Count(c => c == '\n') + 1;

                mensagem += $"{linha,-10} {FormatadorClasse.FormataClasse(token.Id),-30} {token.Lexeme,-20}\n";
            }

            form.AreaMensagens.EscreverMensagem(mensagem);
            form.AreaMensagens.EscreverMensagem("Programa compilado com sucesso");
        }
        catch (LexicalException exception)
        {
            var substring = form.TextoEditor.Text.Substring(0, exception.Position);
            var linha = substring.Count(c => c == '\n') + 1;
            form.AreaMensagens.EscreverMensagem($"Erro na linha {linha}: {exception.Message}");
        }
        catch (ArgumentNullException) // Ignoramos se o usuário clicar cancelar no dialog de salvar
        {
        }
    }
}