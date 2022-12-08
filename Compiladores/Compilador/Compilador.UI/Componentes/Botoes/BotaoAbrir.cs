namespace Compilador.UI.Componentes.Botoes;

public sealed class BotaoAbrir : BotaoBarraFerramentas
{
    public BotaoAbrir()
    {
        Text = "Abrir [ctrl-o]";
        ToolTipText = "Abrir arquivo (ctrl + o)";
    }

    protected override void OnClick(EventArgs e)
    {
        var dialog = new OpenFileDialog();
        dialog.Multiselect = false;

        if (dialog.ShowDialog() == DialogResult.OK)
        {
            var form = FormPrincipal.GetInstancia();
            form.EditorTexto.Text = File.ReadAllText(dialog.FileName);
            form.AreaMensagens.Clear();
            form.BarraStatus.Text = dialog.FileName;
            form.CaminhoArquivoAberto = dialog.FileName;
        }

        base.OnClick(e);
    }
}