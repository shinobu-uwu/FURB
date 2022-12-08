namespace Compilador.UI.Componentes.Botoes;

public abstract class BotaoBarraFerramentas : ToolStripButton
{
    protected override Padding DefaultMargin { get; } = new(5, 0, 5, 0);
}