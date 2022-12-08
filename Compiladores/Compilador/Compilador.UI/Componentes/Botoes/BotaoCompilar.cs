namespace Compilador.UI.Componentes.Botoes;

public sealed class BotaoCompilar : BotaoBarraFerramentas
{
    public BotaoCompilar()
    {
        Text = "Compilar [F7]";
        ToolTipText = "Compilar arquivo (F7)";
    }

    protected override void OnClick(EventArgs e)
    {
        base.OnClick(e);

        var form = FormPrincipal.GetInstancia();
        var compilador = new Compilador();

        // Se o arquivo não estiver salvo mandamos o usuário salvar
        var arquivoEntrada = form.CaminhoArquivoAberto;
        
        if (arquivoEntrada is null)
        {
            form.BarraFerramentas.BotaoSalvar.PerformClick();
        }

        try
        {
            compilador.Input = File.ReadAllText(arquivoEntrada);
            var programa = compilador.Compilar();
            var arquivoSaida = arquivoEntrada.Replace(".txt", ".il");
            File.WriteAllText(arquivoSaida, programa);
            form.AreaMensagens.EscreverMensagem("Programa compilado com sucesso");
        }
        catch (LexicalException exception)
        {
            var substring = form.EditorTexto.Text.Substring(0, exception.Position);
            var linha = substring.Count(c => c == '\n') + 1;
            form.AreaMensagens.EscreverMensagem($"Erro na linha {linha} - {exception.Message}");
        }
        catch (SyntaticException exception)
        {
            var substring = form.EditorTexto.Text.Substring(0, exception.Position);
            var linha = substring.Count(c => c == '\n') + 1;
            var lexema = compilador.CurrentToken?.Lexeme;

            if (lexema == "$")
            {
                lexema = "EOF";
            }

            form.AreaMensagens.EscreverMensagem(
                $"Erro na linha {linha} - encontrado {lexema} {exception.Message}"
            );
        }
        catch (SemanticException exception)
        {
            var substring = form.EditorTexto.Text.Substring(0, exception.Position);
            var linha = substring.Count(c => c == '\n') + 1;

            form.AreaMensagens.EscreverMensagem(
                $"Erro na linha {linha} - {exception.Message}"
            );
        }
        catch (ArgumentNullException) // Ignoramos se o usuário clicar cancelar no dialog de salvar
        {
        }
    }
}