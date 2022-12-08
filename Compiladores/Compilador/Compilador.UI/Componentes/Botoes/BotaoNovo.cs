namespace Compilador.UI.Componentes.Botoes;

public sealed class BotaoNovo : BotaoBarraFerramentas
{
    public BotaoNovo()
    {
        Text = "Novo [ctrl-n]";
        ToolTipText = "Criar novo arquivo (ctrl + n)";

        Click += (sender, args) =>
        {
            var form = FormPrincipal.GetInstancia();
            form.BarraStatus.Text = "";
            form.EditorTexto.Text = "";
            form.AreaMensagens.Clear();
            form.CaminhoArquivoAberto = null;
        };
    }
}