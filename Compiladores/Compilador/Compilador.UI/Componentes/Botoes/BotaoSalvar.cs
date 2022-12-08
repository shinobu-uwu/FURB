namespace Compilador.UI.Componentes.Botoes;

public sealed class BotaoSalvar : BotaoBarraFerramentas
{
    public BotaoSalvar()
    {
        Text = "Salvar [ctrl-s]";
        ToolTipText = "Salvar (ctrl + s)";
    }

    protected override void OnClick(EventArgs e)
    {
        var form = FormPrincipal.GetInstancia();

        if (form.CaminhoArquivoAberto is null)
        {
            var dialog = new SaveFileDialog();

            if (dialog.ShowDialog() == DialogResult.Cancel)
            {
                return;
            }

            form.CaminhoArquivoAberto = dialog.FileName;
            form.BarraStatus.Text = dialog.FileName;
        }

        File.WriteAllText(form.CaminhoArquivoAberto, form.EditorTexto.Text);
        form.AreaMensagens.Clear();

        base.OnClick(e);
    }
}