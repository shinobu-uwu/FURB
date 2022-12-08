namespace Compilador.UI.Componentes.Botoes;

public sealed class BotaoCopiar : BotaoBarraFerramentas
{
    public BotaoCopiar()
    {
        Text = "Copiar [ctrl-c]";
        ToolTipText = "Copiar (ctrl + c)";
    }

    protected override void OnClick(EventArgs e)
    {
        var texto = FormPrincipal.GetInstancia().EditorTexto.SelectedText;
        
        if (texto != "")
        {
            Clipboard.SetText(texto);
        }

        base.OnClick(e);
    }
}