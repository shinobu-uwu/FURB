namespace Compilador.UI.Componentes.Botoes;

public class BotaoColar : BotaoBarraFerramentas
{
    public BotaoColar()
    {
        Text = "Colar [ctrl-v]";
        ToolTipText = "Colar (ctrl + v)";
    }

    protected override void OnClick(EventArgs e)
    {
        var textoEditor = FormPrincipal.GetInstancia().EditorTexto;
        textoEditor.Text = textoEditor.Text.Insert(textoEditor.SelectionStart, Clipboard.GetText());
        
        base.OnClick(e);
    }
}