namespace Compilador.UI.Componentes.Botoes;

public sealed class BotaoAbrir : BotaoBarraFerramentas
{
    public BotaoAbrir()
    {
        Text = "Abrir";
        ToolTipText = "Abrir arquivo (ctrl + o)";
    }

    protected override void OnClick(EventArgs e)
    {
        var dialog = new OpenFileDialog();
        dialog.Multiselect = false;

        if (dialog.ShowDialog() == DialogResult.OK)
        {
            var form = FormPrincipal.GetInstancia();
            form.BarraStatus.Text = dialog.FileName;
            form.TextoEditor.Text = File.ReadAllText(dialog.FileName);
            form.BarraStatus.Text = dialog.FileName;
            form.CaminhoArquivoAberto = dialog.FileName;
        }

        base.OnClick(e);
    }
}